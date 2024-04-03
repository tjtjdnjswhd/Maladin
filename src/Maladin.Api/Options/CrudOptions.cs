using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Maladin.Api.Options
{
    public delegate Expression<Func<TSource, TResult>> ExpressionGetDelegate<TSource, TResult>(HttpContext httpContext);

    public class CrudOptions<TEntity, TRead, TCreate, TUpdate>
    {
        [Required]
        public required Expression<Func<TEntity, TRead>> ReferenceExpression { get; set; }

        [Required]
        public required Expression<Func<TRead, TRead>> ReferenceToProjectionExpression { get; set; }

        [Required]
        public required Expression<Func<TEntity, TRead>> ProjectionExpression { get; set; }

        [Required]
        public IEnumerable<ExpressionGetDelegate<TEntity, bool>> FilterExpressions { get; set; } = [];

        [Required]
        public required Func<HttpContext, IAsyncEnumerable<TRead>, IAsyncEnumerable<TRead>> ReadClientQueryFunc { get; set; }

        [Required]
        public required Func<TCreate, TEntity> CreateFunc { get; set; }

        [Required]
        public required Action<TEntity, TUpdate> UpdateFunc { get; set; }
    }
}