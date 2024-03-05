using AutoMapper;
using AutoMapper.EntityFrameworkCore;

using LinqExpressionParser.AspNetCore.Results;

using Maladin.Api.ActionResults;
using Maladin.Api.Extensions;
using Maladin.Api.Helpers;
using Maladin.Api.Models;
using Maladin.Api.Options;
using Maladin.EFCore;
using Maladin.EFCore.Models.Abstractions;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using System.Reflection;
using System.Runtime.CompilerServices;

namespace Maladin.Api.Controllers.Entity
{
    [Route("api/entity/[controller]")]
    [ApiController]
    public abstract class EntityControllerBase<TEntity, TRead, TCreate, TUpdate> : ControllerBase
        where TEntity : EntityBase
        where TRead : class
        where TCreate : class
        where TUpdate : class
    {
        protected int MaxReadCount { get; }

        protected MaladinDbContext DbContext { get; }

        protected DbSet<TEntity> DbSet { get; }

        protected IMapper Mapper { get; }

        protected ILogger Logger { get; }

        protected EntityAuthorizeOptions<TEntity, TRead, TCreate, TUpdate> EntityAuthorizeOptions { get; }

        protected EntityControllerBase(MaladinDbContext dbContext, IMapper mapper, ILogger logger, IConfiguration configuration, IOptions<EntityAuthorizeOptions<TEntity, TRead, TCreate, TUpdate>> entityAuthorizeOptions)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
            Mapper = mapper;
            Logger = logger;
            EntityAuthorizeOptions = entityAuthorizeOptions.Value;

            string entityName = typeof(TEntity).Name;
            MaxReadCount = EntityConfigurationHelper.GetMaxReadCount(configuration, entityName);
            if (MaxReadCount == 0)
            {
                MaxReadCount = EntityConfigurationHelper.GetMaxReadCount(configuration);
                if (MaxReadCount == 0)
                {
                    throw new ArgumentException("Default MaxReadCount value required");
                }
            }
        }

        [HttpGet("{id:int}")]
        public virtual async Task<IActionResult> GetAsync([FromRoute] int id, CancellationToken cancellationToken)
        {
            if (!await EntityAuthorizeOptions.BeforeReadAuthorize.Invoke(HttpContext))
            {
                return User.IsAuthenticated() ? Forbid() : Unauthorized();
            }

            TEntity? entity;
            try
            {
                entity = await DbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception e)
            {
                return new DbContextExceptionResult(e);
            }

            if (entity is null)
            {
                return NotFound();
            }

            TRead dto = Mapper.Map<TEntity, TRead>(entity);
            return await EntityAuthorizeOptions.ReadAuthorize.Invoke(HttpContext, dto) ? Ok(dto) : Forbid();
        }

        [HttpGet]
        public virtual async IAsyncEnumerable<TRead> GetAsync([FromQuery] ValueParseResult<TEntity, bool> filter, [FromQuery] Page page, [EnumeratorCancellation] CancellationToken cancellationToken, [FromQuery] string orderBy = nameof(EntityBase.Id))
        {
            if (!await EntityAuthorizeOptions.BeforeReadAuthorize.Invoke(HttpContext))
            {
                ActionResult actionResult = User.IsAuthenticated() ? Forbid() : Unauthorized();
                actionResult.ExecuteResult(ControllerContext);
                yield break;
            }

            PropertyInfo? orderByProperty = typeof(TEntity).GetProperty(orderBy, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (orderByProperty is null)
            {
                ModelState.AddModelError(nameof(orderBy), "orderBy value must be property name of entity");
                BadRequest(ModelState).ExecuteResult(ControllerContext);
                yield break;
            }

            IAsyncEnumerable<TRead> asyncDtoQuery;
            try
            {
                IQueryable<TEntity> serverQuery = QueryServer(DbSet, filter, page, orderByProperty);
                IAsyncEnumerable<TRead> dtoQuery = Mapper.ProjectTo<TRead>(serverQuery).AsAsyncEnumerable();
                asyncDtoQuery = QueryClient(dtoQuery, cancellationToken);
            }
            catch (Exception e)
            {
                new DbContextExceptionResult(e).ExecuteResult(ControllerContext);
                yield break;
            }

            await foreach (var dto in asyncDtoQuery.WithCancellation(cancellationToken))
            {
                if (await EntityAuthorizeOptions.ReadAuthorize.Invoke(HttpContext, dto))
                {
                    yield return dto;
                }
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
                entity = await DbSet.Persist(Mapper).InsertOrUpdateAsync(dto, cancellationToken);
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

            TEntity entity;
            try
            {
                entity = await DbSet.Persist(Mapper).InsertOrUpdateAsync(dto, cancellationToken);
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

        protected virtual IQueryable<TEntity> QueryServer(IQueryable<TEntity> query, ValueParseResult<TEntity, bool> filter, Page page, PropertyInfo orderByProperty)
        {
            int count = Math.Min(MaxReadCount, page.Count);
            return query.Where(filter.GetExpression()).OrderBy(orderByProperty).Skip(count * page.Number).Take(count).AsNoTracking();
        }

        protected virtual IAsyncEnumerable<TRead> QueryClient(IAsyncEnumerable<TRead> query, CancellationToken cancellationToken) => query;
    }
}