using AutoMapper;

using LinqExpressionParser.AspNetCore.Results;

using Maladin.Api.ActionResults;
using Maladin.Api.Extensions;
using Maladin.Api.Models;
using Maladin.EFCore;
using Maladin.EFCore.Models.Abstractions;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Reflection;
using System.Runtime.CompilerServices;

namespace Maladin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class EntityController<TEntity, TReadDto, TCreateDto, TUpdateDto> : ControllerBase
        where TEntity : EntityBase
        where TReadDto : class
        where TCreateDto : class
        where TUpdateDto : class
    {
        protected abstract int MaxReadCount { get; }

        protected MaladinDbContext DbContext { get; }

        protected DbSet<TEntity> DbSet { get; }

        protected IMapper Mapper { get; }

        protected EntityController(MaladinDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
            Mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public virtual async Task<IActionResult> GetAsync([FromRoute] int id, CancellationToken cancellationToken)
        {
            if (!await IsReadAllowedAsync(cancellationToken))
            {
                return User.Identity?.IsAuthenticated ?? false ? Forbid() : Unauthorized();
            }

            TEntity? entity;
            try
            {
                entity = await DbSet.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
            }
            catch (Exception e)
            {
                return new DbContextExceptionResult(e);
            }

            if (entity is null)
            {
                return NotFound();
            }

            TReadDto dto = Mapper.Map<TEntity, TReadDto>(entity);
            return await IsReadAllowedAsync(dto, cancellationToken) ? Ok(dto) : Forbid();
        }

        [HttpGet]
        public virtual async IAsyncEnumerable<TReadDto> GetAsync([FromQuery] ValueParseResult<TEntity, bool> filter, [FromQuery] Page page, [EnumeratorCancellation] CancellationToken cancellationToken, [FromQuery] string orderBy = nameof(EntityBase.Id))
        {
            if (!await IsReadAllowedAsync(cancellationToken))
            {
                ActionResult actionResult = User.Identity?.IsAuthenticated ?? false ? Forbid() : Unauthorized();
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

            IAsyncEnumerable<TReadDto> asyncDtoQuery;
            try
            {
                IQueryable<TEntity> serverQuery = QueryServer(DbSet, filter, page, orderByProperty);
                IAsyncEnumerable<TReadDto> dtoQuery = Mapper.ProjectTo<TReadDto>(serverQuery).AsAsyncEnumerable();
                asyncDtoQuery = QueryClient(dtoQuery, cancellationToken);
            }
            catch (Exception e)
            {
                new DbContextExceptionResult(e).ExecuteResult(ControllerContext);
                yield break;
            }

            await foreach (var dto in asyncDtoQuery.WithCancellation(cancellationToken))
            {
                if (await IsReadAllowedAsync(dto, cancellationToken))
                {
                    yield return dto;
                }
            }
        }

        [HttpPost]
        public virtual async Task<IActionResult> PostAsync([FromBody] TCreateDto dto, CancellationToken cancellationToken)
        {
            if (!await IsCreateAllowedAsync(dto, cancellationToken))
            {
                return User.Identity?.IsAuthenticated ?? false ? Forbid() : Unauthorized();
            }

            TEntity entity = Create(dto);

            throw new NotImplementedException();
        }

        [HttpPut("{id:int}")]
        public virtual async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] TUpdateDto dto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id:int}")]
        public virtual async Task<IActionResult> DeleteAsync([FromRoute] int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected virtual IQueryable<TEntity> QueryServer(IQueryable<TEntity> query, ValueParseResult<TEntity, bool> filter, Page page, PropertyInfo orderByProperty)
        {
            int count = Math.Min(MaxReadCount, page.Count);
            return query.Where(filter.GetExpression()).OrderBy(orderByProperty).Skip(count * page.Number).Take(count);
        }

        protected virtual IAsyncEnumerable<TReadDto> QueryClient(IAsyncEnumerable<TReadDto> query, CancellationToken cancellationToken) => query;

        protected abstract ValueTask<bool> IsReadAllowedAsync(CancellationToken cancellationToken);

        protected abstract ValueTask<bool> IsReadAllowedAsync(TReadDto dto, CancellationToken cancellationToken);

        protected abstract ValueTask<bool> IsCreateAllowedAsync(TCreateDto dto, CancellationToken cancellationToken);

        protected abstract ValueTask<bool> IsUpdateAllowedAsync(int Id, TUpdateDto dto, CancellationToken cancellationToken);

        protected abstract ValueTask<bool> IsDeleteAllowedAsync(int id, CancellationToken cancellationToken);

        protected abstract TEntity Create(TCreateDto create);
    }
}