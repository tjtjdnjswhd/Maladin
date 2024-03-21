using AutoMapper;

using LinqExpressionParser.AspNetCore.Results;

using Maladin.Api.ActionResults;
using Maladin.Api.Extensions;
using Maladin.Api.Models;
using Maladin.Api.Models.Dtos.Read.Abstractions;
using Maladin.Api.Options;
using Maladin.Api.Services;
using Maladin.EFCore;
using Maladin.EFCore.Models.Abstractions;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Options;

using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Maladin.Api.Controllers.Entity
{
    [Route("api/entity/[controller]")]
    [ApiController]
    public abstract class EntityControllerBase<TEntity, TRead, TCreate, TUpdate> : ControllerBase
        where TEntity : EntityBase
        where TRead : ReadBase
        where TCreate : class
        where TUpdate : class
    {
        protected MaladinDbContext DbContext { get; }

        protected DbSet<TEntity> DbSet { get; }

        protected IMapper Mapper { get; }

        protected ILogger Logger { get; }

        protected int MaxReadCount { get; }

        protected CrudOptions<TEntity, TRead, TCreate, TUpdate> CrudOptions { get; }

        protected EntityAuthorizeOptions<TEntity, TRead, TCreate, TUpdate> EntityAuthorizeOptions { get; }

        protected EntityControllerBase(
            MaladinDbContext dbContext,
            IMapper mapper,
            ILogger logger,
            IEntityConfigurationService entityConfiguration,
            IOptions<CrudOptions<TEntity, TRead, TCreate, TUpdate>> crudOptions,
            IOptions<EntityAuthorizeOptions<TEntity, TRead, TCreate, TUpdate>> authorizeOptions)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
            Mapper = mapper;
            Logger = logger;
            CrudOptions = crudOptions.Value;
            EntityAuthorizeOptions = authorizeOptions.Value;

            string entityName = typeof(TEntity).Name;
            MaxReadCount = entityConfiguration.GetMaxReadCount(entityName);
            if (MaxReadCount == 0)
            {
                throw new ArgumentException("Default MaxReadCount value required");
            }
        }

        [HttpGet("{id:int}")]
        public virtual async Task<IActionResult> GetAsync([FromRoute] int id, CancellationToken cancellationToken)
        {
            if (!await EntityAuthorizeOptions.BeforeReadAuthorize.Invoke(HttpContext))
            {
                return User.IsAuthenticated() ? Forbid() : Unauthorized();
            }

            Expression<Func<TEntity, TRead>> readSelectorExp = CrudOptions.EntityToReadExpression.Invoke(HttpContext);
            Expression<Func<TRead, TRead>> readQueryExp = CrudOptions.ReadServerQueryExpression.Invoke(HttpContext);
            TRead? read;
            try
            {
                IQueryable<TEntity> query = DbSet.QueryByDtoExpression(Mapper, includes: CrudOptions.IncludeExpressions.Select(e => e.Invoke(HttpContext)));
                read = await query.Select(readSelectorExp).Select(readQueryExp).FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception e)
            {
                return new DbContextExceptionResult(e);
            }

            if (read is null)
            {
                return NotFound();
            }

            return await EntityAuthorizeOptions.ReadAuthorize.Invoke(HttpContext, read) ? Ok(read) : Forbid();
        }

        [HttpGet]
        public virtual async IAsyncEnumerable<TRead> GetAsync([FromQuery(Name = "filter")] ValueParseResult<TRead, bool> readFilter, [FromQuery][Bind(nameof(Page.Number), nameof(page.Count))] Page page, [FromQuery(Name = "orderBy")] OrderByOptions<TRead> orderByKey, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            if (!await EntityAuthorizeOptions.BeforeReadAuthorize.Invoke(HttpContext))
            {
                ActionResult actionResult = User.IsAuthenticated() ? Forbid() : Unauthorized();
                actionResult.ExecuteResult(ControllerContext);
                yield break;
            }

            IEnumerable<Expression<Func<IQueryable<TRead>, IIncludableQueryable<TRead, object>>>> readIncludeQuerys = CrudOptions.IncludeExpressions.Select(q => q.Invoke(HttpContext));
            IEnumerable<Expression<Func<TRead, bool>>> readFilterQuerys = CrudOptions.ReadFilterExpressions.Select(q => q.Invoke(HttpContext)).Append(readFilter.GetExpression());
            int readCount = Math.Min(MaxReadCount, page.Count);

            IQueryable<TEntity> serverQuery =
                DbSet.QueryByDtoExpression(
                    mapper: Mapper,
                    orderByKeySelectorExpPairs: orderByKey.OrderByKeySelectorExpPair,
                    queryFunc: q => q.Skip(readCount * page.Number).Take(readCount),
                    includes: readIncludeQuerys,
                    filters: readFilterQuerys);
            IEnumerable<Expression<Func<TEntity, bool>>> entityFilters = CrudOptions.EntityFilterExpressions.Select(e => e.Invoke(HttpContext));
            serverQuery = entityFilters.Aggregate(serverQuery, (query, next) => query.Where(next));

            Expression<Func<TEntity, TRead>> entityToReadSelectorExpression = CrudOptions.EntityToReadExpression.Invoke(HttpContext);
            Expression<Func<TRead, TRead>> readQueryExpression = CrudOptions.ReadServerQueryExpression.Invoke(HttpContext);

            IAsyncEnumerable<TRead> dtoQuery;
            try
            {
                dtoQuery = serverQuery.Select(entityToReadSelectorExpression).Select(readQueryExpression).AsAsyncEnumerable();
            }
            catch (Exception e)
            {
                new DbContextExceptionResult(e).ExecuteResult(ControllerContext);
                yield break;
            }

            dtoQuery = CrudOptions.ReadClientQueryFunc.Invoke(HttpContext, dtoQuery);
            await foreach (var dto in dtoQuery.WithCancellation(cancellationToken))
            {
                yield return dto;
            }
        }

        [HttpPost]
        public virtual async Task<IActionResult> PostAsync([FromBody] TCreate dto, CancellationToken cancellationToken)
        {
            if (!await EntityAuthorizeOptions.CreateAuthorize.Invoke(HttpContext, dto))
            {
                return User.IsAuthenticated() ? Forbid() : Unauthorized();
            }

            TEntity entity;
            try
            {
                entity = CrudOptions.CreateFunc.Invoke(HttpContext, dto);
                DbSet.Add(entity);
                await DbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                return new DbContextExceptionResult(e);
            }

            return CreatedAtAction("Get", new { entity.Id }, null);
        }

        [HttpPut("{id:int}")]
        public virtual async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] TUpdate dto, CancellationToken cancellationToken)
        {
            if (!await EntityAuthorizeOptions.UpdateAuthorize.Invoke(HttpContext, id, dto))
            {
                return User.IsAuthenticated() ? Forbid() : Unauthorized();
            }

            TEntity? entity;
            try
            {
                entity = await DbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
                if (entity is null)
                {
                    return NotFound();
                }

                CrudOptions.UpdateFunc.Invoke(HttpContext, entity, dto);
                await DbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                return new DbContextExceptionResult(e);
            }

            return CreatedAtAction("Get", new { entity.Id }, null);
        }

        [HttpDelete("{id:int}")]
        public virtual async Task<IActionResult> DeleteAsync([FromRoute] int id, CancellationToken cancellationToken)
        {
            if (!await EntityAuthorizeOptions.DeleteAuthorize.Invoke(HttpContext, id))
            {
                return User.IsAuthenticated() ? Forbid() : Unauthorized();
            }

            try
            {
                var transaction = DbContext.Database.BeginTransaction();
                int count = await DbSet.Where(e => e.Id == id).ExecuteDeleteAsync(cancellationToken);

                switch (count)
                {
                    case 0:
                        return NotFound();
                    case 1:
                        transaction.Commit();
                        return NoContent();
                    default:
                        transaction.Rollback();
                        return BadRequest();
                }
            }
            catch (Exception e)
            {
                return new DbContextExceptionResult(e);
            }
        }
    }
}