using AutoMapper;

using LinqExpressionParser.AspNetCore.Results;

using Maladin.EFCore;
using Maladin.EFCore.Models.Abstractions;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Runtime.CompilerServices;

namespace Maladin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class EntityController<TEntity, TDto> : ControllerBase
        where TEntity : EntityBase
        where TDto : class
    {
        protected MaladinDbContext DbContext { get; }

        protected DbSet<TEntity> DbSet { get; }

        protected IMapper Mapper { get; }

        protected ILogger Logger { get; }

        protected EntityController(MaladinDbContext dbContext, IMapper mapper, ILogger logger)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
            Mapper = mapper;
            Logger = logger;
        }

        [HttpGet("{id:int}")]
        public virtual async Task<IActionResult> GetAsync([FromRoute] int id, CancellationToken cancellationToken)
        {
            if (!await IsAllowedAsync(cancellationToken))
            {
                return User.Identity?.IsAuthenticated switch
                {
                    true => Forbid(),
                    _ => Unauthorized()
                };
            }

            TEntity? entity = await DbSet.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
            if (entity is null)
            {
                return NotFound();
            }

            TDto dto = Mapper.Map<TEntity, TDto>(entity);
            if (await IsAllowedAsync(dto, cancellationToken))
            {
                return Ok(dto);
            }
            else
            {
                return Forbid();
            }
        }

        [HttpGet]
        public virtual async IAsyncEnumerable<TDto> GetAsync(ValueParseResult<TEntity, bool> filter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            if (!await IsAllowedAsync(cancellationToken))
            {
                HttpContext.Response.StatusCode = User.Identity?.IsAuthenticated switch
                {
                    true => StatusCodes.Status403Forbidden,
                    _ => StatusCodes.Status401Unauthorized
                };

                yield break;
            }

            IQueryable<TEntity> serverQuery = ServerQuery(DbSet, filter);
            IQueryable<TDto> dtoQuery = Mapper.ProjectTo<TDto>(serverQuery);
            IAsyncEnumerable<TDto> asyncDtoQuery = ClientQuery(dtoQuery);

            await foreach (var dto in asyncDtoQuery.WithCancellation(cancellationToken))
            {
                if (await IsAllowedAsync(dto, cancellationToken))
                {
                    yield return dto;
                }
            }
        }

        protected abstract ValueTask<bool> IsAllowedAsync(CancellationToken cancellationToken);

        protected abstract ValueTask<bool> IsAllowedAsync(TDto dto, CancellationToken cancellationToken);

        protected abstract IQueryable<TEntity> ServerQuery(IQueryable<TEntity> query, ValueParseResult<TEntity, bool> filter);

        protected abstract IAsyncEnumerable<TDto> ClientQuery(IQueryable<TDto> query);
    }
}