using Maladin.Api.Models;

using System.ComponentModel;

namespace Maladin.Api.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<TRead> GetOrderedQuery<TRead>(this IQueryable<TRead> query, OrderByOptions<TRead> orderByOptions, int skip, int take)
        {
            IEnumerable<OrderByPair<TRead>> orderByKeySelectorExpPair = orderByOptions.OrderByKeySelectorExpPair;
            OrderByPair<TRead> firstOrder = orderByKeySelectorExpPair.FirstOrDefault();
            if (firstOrder == default)
            {
                return query;
            }

            IOrderedQueryable<TRead> orderedQuery = firstOrder.Direction switch
            {
                ListSortDirection.Ascending => query.OrderBy(firstOrder.Expression),
                ListSortDirection.Descending => query.OrderByDescending(firstOrder.Expression),
                _ => throw new InvalidEnumArgumentException(nameof(firstOrder.Direction), (int)firstOrder.Direction, typeof(ListSortDirection))
            };

            orderedQuery = orderByKeySelectorExpPair.Skip(1).Aggregate(orderedQuery, (query, orderByPair) => orderByPair.Direction switch
            {
                ListSortDirection.Ascending => query.ThenBy(orderByPair.Expression),
                ListSortDirection.Descending => query.ThenByDescending(orderByPair.Expression),
                _ => throw new InvalidEnumArgumentException(nameof(orderByPair.Direction), (int)orderByPair.Direction, typeof(ListSortDirection))
            });

            return orderedQuery.Skip(skip).Take(take);
        }
    }
}