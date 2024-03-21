using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;

using Maladin.Api.Models;

using Microsoft.EntityFrameworkCore.Query;

using System.ComponentModel;
using System.Linq.Expressions;

namespace Maladin.Api.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<TEntity> QueryByDtoExpression<TEntity, TDto>(
            this IQueryable<TEntity> query,
            IMapper mapper,
            IEnumerable<OrderByPair<TDto>>? orderByKeySelectorExpPairs = null,
            Expression<Func<IQueryable<TDto>, IQueryable<TDto>>>? queryFunc = null,
            IEnumerable<Expression<Func<IQueryable<TDto>, IIncludableQueryable<TDto, object>>>>? includes = null,
            params Expression<Func<TDto, bool>>[] filters)
        {
            return QueryByDtoExpression(query, mapper, orderByKeySelectorExpPairs, queryFunc, includes, filters.AsEnumerable());
        }

        public static IQueryable<TEntity> QueryByDtoExpression<TEntity, TDto>(
            this IQueryable<TEntity> query,
            IMapper mapper,
            IEnumerable<OrderByPair<TDto>>? orderByKeySelectorExpPairs = null,
            Expression<Func<IQueryable<TDto>, IQueryable<TDto>>>? queryFunc = null,
            IEnumerable<Expression<Func<IQueryable<TDto>, IIncludableQueryable<TDto, object>>>>? includes = null,
            IEnumerable<Expression<Func<TDto, bool>>>? filters = null)
        {
            Func<IQueryable<TEntity>, IQueryable<TEntity>>? entityQueryFunc = queryFunc is null ? null : mapper.MapExpression<Expression<Func<IQueryable<TEntity>, IQueryable<TEntity>>>>(queryFunc).Compile();
            IEnumerable<OrderByPair<TEntity>>? entityOrderByKeySelectorPairs = orderByKeySelectorExpPairs?.Select(pair => new OrderByPair<TEntity>(mapper.MapExpression<Expression<Func<TEntity, object>>>(pair.Expression), pair.Direction));
            IEnumerable<Expression<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>>>? entityIncludes = includes is null ? null : mapper.MapIncludesList<Expression<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>>>(includes);
            IEnumerable<Expression<Func<TEntity, bool>>>? entityFilters = filters is null ? null : mapper.MapExpressionList<Expression<Func<TEntity, bool>>>(filters);

            if (entityOrderByKeySelectorPairs?.FirstOrDefault() is (Expression<Func<TEntity, object>>, ListSortDirection) firstOrderByKeySelectorExpPair && firstOrderByKeySelectorExpPair != default)
            {
                query = firstOrderByKeySelectorExpPair.Direction switch
                {
                    ListSortDirection.Ascending => query.OrderBy(firstOrderByKeySelectorExpPair.Expression),
                    ListSortDirection.Descending => query.OrderByDescending(firstOrderByKeySelectorExpPair.Expression),
                    _ => throw new InvalidEnumArgumentException(null, (int)firstOrderByKeySelectorExpPair.Direction, typeof(ListSortDirection))
                };

                query = entityOrderByKeySelectorPairs
                    .Skip(1)
                    .Aggregate((IOrderedQueryable<TEntity>)query, (q, pair) => pair.Direction switch
                    {
                        ListSortDirection.Ascending => q.ThenBy(pair.Expression),
                        ListSortDirection.Descending => q.ThenByDescending(pair.Expression),
                        _ => throw new InvalidEnumArgumentException(null, (int)pair.Direction, typeof(ListSortDirection))
                    });
            }

            if (entityQueryFunc is not null)
            {
                query = entityQueryFunc.Invoke(query);
            }

            if (entityIncludes is not null)
            {
                query = entityIncludes.Aggregate(query, (q, exp) => exp.Compile().Invoke(q));
            }

            if (entityFilters is not null)
            {
                foreach (var filter in entityFilters)
                {
                    query = query.Where(filter);
                }
            }

            return query;
        }
    }
}