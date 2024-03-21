using System.ComponentModel;
using System.Linq.Expressions;

namespace Maladin.Api.Models
{
    public record struct OrderByPair<T>(Expression<Func<T, object>> Expression, ListSortDirection Direction)
    {
        public static implicit operator (Expression<Func<T, object>>, ListSortDirection)(OrderByPair<T> value)
        {
            return (value.Expression, value.Direction);
        }

        public static implicit operator OrderByPair<T>((Expression<Func<T, object>>, ListSortDirection) value)
        {
            return new OrderByPair<T>(value.Item1, value.Item2);
        }
    }
}