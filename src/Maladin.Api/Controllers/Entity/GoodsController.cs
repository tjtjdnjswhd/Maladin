using LinqExpressionParser.AspNetCore.Results;

using Maladin.Api.Models;
using Maladin.Api.Models.Dtos.Create.Abstractions;
using Maladin.Api.Models.Dtos.Read;
using Maladin.Api.Models.Dtos.Read.Abstractions;
using Maladin.Api.Models.Dtos.Update.Abstractions;
using Maladin.Api.Options;
using Maladin.Api.Services;
using Maladin.EFCore;
using Maladin.EFCore.Models;
using Maladin.EFCore.Models.Abstractions;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Maladin.Api.Controllers.Entity
{
    public class GoodsController(MaladinDbContext dbContext, ILogger<GoodsController> logger, IEntityConfigurationService configuration, IOptions<CrudOptions<Goods, GoodsRead, GoodsCreate, GoodsUpdate>> crudOptions, IOptions<EntityActionFilterOptions<Goods, GoodsRead, GoodsCreate, GoodsUpdate>> actionFilterOptions/*, IOptions<GoodsReadOptions> goodsReadOptions*/)
        : EntityControllerBase<Goods, GoodsRead, GoodsCreate, GoodsUpdate>(dbContext, logger, configuration, crudOptions, actionFilterOptions)
    {
        public override async IAsyncEnumerable<GoodsRead> GetAsync([FromQuery(Name = "filter")] ValueParseResult<GoodsRead, bool>? readFilter, [Bind([nameof(Page.Number), nameof(Page.Count)]), FromQuery] Page? page, [FromQuery(Name = "orderBy")] OrderByOptions<GoodsRead>? orderByKey, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            if ((await ActionFilterOptions.BeforeRead(HttpContext)) is IActionResult actionResult)
            {
                await actionResult.ExecuteResultAsync(ControllerContext);
                yield break;
            }

            IEnumerable<Expression<Func<Goods, bool>>> filters = CrudOptions.FilterExpressions.Select(f => f.Invoke(HttpContext));
            IQueryable<Goods> filteredQuery = filters.Aggregate<Expression<Func<Goods, bool>>, IQueryable<Goods>>(DbSet, (q, filter) => q.Where(filter));
            IQueryable<GoodsRead> readQuery = filteredQuery.Select(CrudOptions.ReferenceExpression);
            if (readFilter is not null)
            {
                readQuery.Where(readFilter.GetExpression());
            }

            IQueryable<GoodsRead> orderedQuery = OrderBy(readQuery, orderByKey, page);
            IQueryable<AA> idWithIndexQuery = orderedQuery.Select((g, index) => new AA(g.Id, index));

            IQueryable<GoodsRead> resultQuery = idWithIndexQuery.Join(DbSet, i => i.Id, g => g.Id, (i, g) => new
            {
                i.Rank,
                goods = g is BookDisplay ? new BookDisplayRead()
                {
                    Id = g.Id,
                    Name = g.Name,
                    Overview = g.Overview,
                    Price = g.Price,
                    CategoryId = g.CategoryId,
                    PageCount = ((BookDisplay)g).PageCount,
                    PaperSize = ((BookDisplay)g).PaperSize,
                    PublishedAt = ((BookDisplay)g).PublishedAt,
                    CoverUrl = ((BookDisplay)g).CoverUrl,
                    AuthorId = ((BookDisplay)g).AuthorId,
                    BookId = ((BookDisplay)g).BookId,
                    PublisherId = ((BookDisplay)g).PublisherId,
                    TranslatorId = ((BookDisplay)g).TranslatorId,
                }
                :
                g is Pencil ? new PencilRead()
                {
                    Id = g.Id,
                    Name = g.Name,
                    Overview = g.Overview,
                    Price = g.Price,
                    CategoryId = g.CategoryId,
                    Maker = ((Pencil)g).Maker
                }
                :
                new GoodsRead()
                {
                    Id = g.Id,
                    Name = g.Name,
                    Overview = g.Overview,
                    Price = g.Price,
                    CategoryId = g.CategoryId
                }
            })
            .OrderBy(a => a.Rank)
            .Select(a => a.goods);

            await foreach (var goods in resultQuery.AsAsyncEnumerable().WhereAwait(async g => (await ActionFilterOptions.AfterRead.Invoke(HttpContext, g)) is null).WithCancellation(cancellationToken))
            {
                yield return goods;
            }
        }

        private record AA(int Id, int Rank);
    }
}