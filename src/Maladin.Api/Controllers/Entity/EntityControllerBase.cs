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
using Microsoft.Extensions.Options;

using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Maladin.Api.Controllers.Entity
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class EntityControllerBase<TEntity, TRead, TCreate, TUpdate> : ControllerBase
        where TEntity : EntityBase
        where TRead : ReadBase
        where TCreate : class
        where TUpdate : class
    {
        protected MaladinDbContext DbContext { get; }

        protected DbSet<TEntity> DbSet { get; }

        protected ILogger Logger { get; }

        protected int MaxReadCount { get; }

        protected CrudOptions<TEntity, TRead, TCreate, TUpdate> CrudOptions { get; }

        protected EntityActionFilterOptions<TEntity, TRead, TCreate, TUpdate> ActionFilterOptions { get; }

        protected OrderByOptions<TRead> DefaultOrderByOptions => new([new(e => e.Id, ListSortDirection.Ascending)]);

        protected EntityControllerBase(
            MaladinDbContext dbContext,
            ILogger logger,
            IEntityConfigurationService entityConfiguration,
            IOptions<CrudOptions<TEntity, TRead, TCreate, TUpdate>> crudOptions,
            IOptions<EntityActionFilterOptions<TEntity, TRead, TCreate, TUpdate>> actionFilterOptions)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
            Logger = logger;
            CrudOptions = crudOptions.Value;
            ActionFilterOptions = actionFilterOptions.Value;

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
            if ((await ActionFilterOptions.BeforeRead.Invoke(HttpContext)) is IActionResult actionResult)
            {
                return actionResult;
            }

            IEnumerable<Expression<Func<TEntity, bool>>> filterExpressions = CrudOptions.FilterExpressions.Select(e => e.Invoke(HttpContext));
            TRead? read;
            try
            {
                IQueryable<TEntity> query = filterExpressions.Aggregate<Expression<Func<TEntity, bool>>, IQueryable<TEntity>>(DbSet, (query, filter) => query.Where(filter));
                read = await query.Select(CrudOptions.ProjectionExpression).FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            }
            catch (Exception e)
            {
                return new DbContextExceptionResult(e);
            }

            if (read is null)
            {
                return NotFound();
            }

            return (await ActionFilterOptions.AfterRead.Invoke(HttpContext, read)) ?? Ok(read);
        }

        [HttpGet]
        public virtual async IAsyncEnumerable<TRead> GetAsync([FromQuery(Name = "filter")] ValueParseResult<TRead, bool>? readFilter, [FromQuery][Bind(nameof(Page.Number), nameof(Page.Count))] Page? page, [FromQuery(Name = "orderBy")] OrderByOptions<TRead>? orderByOptions, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            if ((await ActionFilterOptions.BeforeRead.Invoke(HttpContext)) is IActionResult actionResult)
            {
                await actionResult.ExecuteResultAsync(ControllerContext);
                yield break;
            }

            IEnumerable<Expression<Func<TEntity, bool>>> filters = CrudOptions.FilterExpressions.Select(f => f.Invoke(HttpContext));
            IQueryable<TEntity> entityQuery = filters.Aggregate<Expression<Func<TEntity, bool>>, IQueryable<TEntity>>(DbSet, (q, filter) => q.Where(filter));
            IQueryable<TRead> referenceQuery = entityQuery.Select(CrudOptions.ReferenceExpression);
            if (readFilter is not null)
            {
                referenceQuery = referenceQuery.Where(readFilter.GetExpression());
            }

            (int skip, int take) = GetSkipTake(page);
            IQueryable<TRead> readQuery = referenceQuery.Select(CrudOptions.ReferenceToProjectionExpression);
            IQueryable<TRead> orderedQuery = readQuery.GetOrderedQuery(orderByOptions ?? DefaultOrderByOptions, skip, take);

            IAsyncEnumerable<TRead> dtoQuery;
            try
            {
                dtoQuery = orderedQuery.AsAsyncEnumerable();
            }
            catch (Exception e)
            {
                new DbContextExceptionResult(e).ExecuteResult(ControllerContext);
                yield break;
            }

            await foreach (var dto in dtoQuery.WhereAwait(async r => (await ActionFilterOptions.AfterRead.Invoke(HttpContext, r)) is null).WithCancellation(cancellationToken))
            {
                yield return dto;
            }
        }

        [HttpPost]
        public virtual async Task<IActionResult> PostAsync([FromBody] TCreate dto, CancellationToken cancellationToken)
        {
            if ((await ActionFilterOptions.BeforeCreate.Invoke(HttpContext, dto)) is IActionResult actionResult)
            {
                return actionResult;
            }

            TEntity entity;
            try
            {
                entity = CrudOptions.CreateFunc.Invoke(dto);
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
            if ((await ActionFilterOptions.BeforeUpdate.Invoke(HttpContext, id, dto)) is IActionResult actionResult)
            {
                return actionResult;
            }

            TEntity? entity;
            try
            {
                entity = await DbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
                if (entity is null)
                {
                    return NotFound();
                }

                CrudOptions.UpdateFunc.Invoke(entity, dto);
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
            if ((await ActionFilterOptions.BeforeDelete.Invoke(HttpContext, id)) is IActionResult actionResult)
            {
                return actionResult;
            }

            try
            {
                using var transaction = DbContext.Database.BeginTransaction();
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

        protected (int skip, int take) GetSkipTake(Page? page)
        {
            int take = page is null ? MaxReadCount : Math.Min(MaxReadCount, page.Count);
            int skip = (page?.Number - 1 ?? 0) * take;
            return (skip, take);
        }
    }
}