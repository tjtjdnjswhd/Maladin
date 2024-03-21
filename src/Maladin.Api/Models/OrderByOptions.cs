using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

namespace Maladin.Api.Models
{
    public class OrderByOptions<T> : IParsable<OrderByOptions<T>>, IValidatableObject
    {
        private static readonly Dictionary<string, Expression<Func<T, object>>> _cachedOrderByKeySelectorExp = new(StringComparer.OrdinalIgnoreCase);

        public OrderByOptions(IEnumerable<OrderByPair<T>> orderByKeySelectorExpPair)
        {
            OrderByKeySelectorExpPair = orderByKeySelectorExpPair;
        }

#pragma warning disable CS8618 // 생성자를 종료할 때 null을 허용하지 않는 필드에 null이 아닌 값을 포함해야 합니다. null 허용으로 선언해 보세요.
        private OrderByOptions(IEnumerable<string> invalidPropertyNames)
        {
            _invalidPropertyNames = invalidPropertyNames;
        }
#pragma warning restore CS8618 // 생성자를 종료할 때 null을 허용하지 않는 필드에 null이 아닌 값을 포함해야 합니다. null 허용으로 선언해 보세요.

        private readonly IEnumerable<string>? _invalidPropertyNames;

        public IEnumerable<OrderByPair<T>> OrderByKeySelectorExpPair { get; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (_invalidPropertyNames is not null)
            {
                yield return new ValidationResult($"Invalid property name. names: {string.Join(", ", _invalidPropertyNames)}");
            }
        }

        public static OrderByOptions<T> Parse(string s, IFormatProvider? provider)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(s, nameof(s));
            if (!TryParse(s, provider, out OrderByOptions<T>? result))
            {
                throw new FormatException();
            }

            return result;
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out OrderByOptions<T> result)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                result = null;
                return false;
            }

            List<string> invalidPropertyNames = [];
            List<OrderByPair<T>> orderByKeySelectorPairs = [];

            bool isValid = true;
            string[] orderByPropertyNamePairs = s.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            foreach (var split in orderByPropertyNamePairs.Select(p => p.Split(' ')))
            {
                Debug.Assert(split.Length != 0);
                string propertyName = split[0];
                PropertyInfo? propertyInfo = typeof(T).GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (propertyInfo is null)
                {
                    isValid = false;
                    invalidPropertyNames.Add(propertyName);
                    continue;
                }

                if (isValid)
                {
                    ListSortDirection direction = split.Length == 1 ? ListSortDirection.Ascending : split[1].Equals("desc", StringComparison.OrdinalIgnoreCase) ? ListSortDirection.Descending : ListSortDirection.Ascending;
                    if (_cachedOrderByKeySelectorExp.TryGetValue(propertyName, out var cachedExp))
                    {
                        orderByKeySelectorPairs.Add((cachedExp, direction));
                        continue;
                    }

                    ParameterExpression parameterExp = Expression.Parameter(typeof(T));
                    Expression<Func<T, object>> orderByKeySelectorExp = Expression.Lambda<Func<T, object>>(Expression.Property(parameterExp, propertyInfo), parameterExp);
                    _cachedOrderByKeySelectorExp.Add(propertyName, orderByKeySelectorExp);
                    orderByKeySelectorPairs.Add((orderByKeySelectorExp, direction));
                }
            }

            result = isValid ? new(orderByKeySelectorPairs) : new(invalidPropertyNames);
            return true;
        }
    }
}