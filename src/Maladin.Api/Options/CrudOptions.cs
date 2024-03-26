using Microsoft.EntityFrameworkCore.Query;

using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Maladin.Api.Options
{
    public delegate Expression<Func<TSource, TResult>> ExpressionGetDelegate<TSource, TResult>(HttpContext httpContext);

    public class CrudOptions<TEntity, TRead, TCreate, TUpdate>
    {
        private static readonly Func<HttpContext, IAsyncEnumerable<TRead>, IAsyncEnumerable<TRead>> _defaultReadClientQueryFunc = (_, q) => q;

        [Required]
        public required ExpressionGetDelegate<TEntity, TRead> EntityToReadExpression { get; set; }

        [Required]
        public IEnumerable<ExpressionGetDelegate<TEntity, bool>> EntityFilterExpressions { get; set; } = [];

        [Required]
        public IEnumerable<ExpressionGetDelegate<TRead, bool>> ReadFilterExpressions { get; set; } = [];

        [Required]
        public IEnumerable<ExpressionGetDelegate<IQueryable<TRead>, IIncludableQueryable<TRead, object>>> IncludeExpressions { get; set; } = [];

        [Required]
        public required Func<HttpContext, IAsyncEnumerable<TRead>, IAsyncEnumerable<TRead>> ReadClientQueryFunc { get; set; } = _defaultReadClientQueryFunc;

        [Required]
        public required Func<TCreate, TEntity> CreateFunc { get; set; }

        [Required]
        public required Action<TEntity, TUpdate> UpdateFunc { get; set; }
    }
}