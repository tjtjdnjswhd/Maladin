using System.Linq.Expressions;
using System.Reflection;

namespace Maladin.Api.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, PropertyInfo orderByProperty)
        {
            ParameterExpression parameterExp = Expression.Parameter(typeof(T));
            LambdaExpression keySelectorExp =
                Expression.Lambda(
                    Expression.Property(parameterExp, orderByProperty), parameterExp);

            return query.Provider.CreateQuery<T>(
                Expression.Call(
                    type: typeof(Queryable),
                    methodName: nameof(Queryable.OrderBy),
                    typeArguments: [query.ElementType, keySelectorExp.Body.Type],
                    query.Expression, Expression.Quote(keySelectorExp)));
        }
    }
}