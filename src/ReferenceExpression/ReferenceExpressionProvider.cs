using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace ReferenceExpression
{
    public class ReferenceExpressionProvider(ReadOnlyDictionary<TypePair, LambdaExpression> referenceMapExpressions, ReadOnlyDictionary<TypePair, LambdaExpression> defaultExpressions)
    {
        private readonly ReadOnlyDictionary<TypePair, LambdaExpression> _referenceMapExpressions = referenceMapExpressions;
        private readonly ReadOnlyDictionary<TypePair, LambdaExpression> _defaultExpressions = defaultExpressions;

        public bool TryGetMapExpression<TSource, TDest>(bool withReference, [NotNullWhen(true)] out Expression<Func<TSource, TDest>>? result)
        {
            ReadOnlyDictionary<TypePair, LambdaExpression> expressions = withReference ? _referenceMapExpressions : _defaultExpressions;
            if (expressions.TryGetValue(new TypePair(typeof(TSource), typeof(TDest)), out LambdaExpression? value))
            {
                result = (Expression<Func<TSource, TDest>>)value;
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        public bool TryGetMapExpression(Type source, Type dest, bool withReference, [NotNullWhen(true)] out LambdaExpression? result)
        {
            ReadOnlyDictionary<TypePair, LambdaExpression> expressions = withReference ? _referenceMapExpressions : _defaultExpressions;
            return expressions.TryGetValue(new TypePair(source, dest), out result);
        }
    }
}