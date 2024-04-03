using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace MappedExpressionProvider
{
    public class MappedExpressionProvider(ReadOnlyDictionary<TypePair, LambdaExpression> defaultExpressions, ReadOnlyDictionary<TypePair, LambdaExpression> referenceExpressions, ReadOnlyDictionary<Type, LambdaExpression> destToDestExpressions)
    {
        private readonly ReadOnlyDictionary<TypePair, LambdaExpression> _defaultExpressions = defaultExpressions;
        private readonly ReadOnlyDictionary<TypePair, LambdaExpression> _referenceExpressions = referenceExpressions;
        private readonly ReadOnlyDictionary<Type, LambdaExpression> _destToDestExpressions = destToDestExpressions;

        public bool TryGetExpression<TSource, TDest>(bool withReference, [NotNullWhen(true)] out Expression<Func<TSource, TDest>>? result)
        {
            ReadOnlyDictionary<TypePair, LambdaExpression> expressions = withReference ? _referenceExpressions : _defaultExpressions;
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

        public bool TryGetExpression(Type source, Type dest, bool withReference, [NotNullWhen(true)] out LambdaExpression? result)
        {
            ReadOnlyDictionary<TypePair, LambdaExpression> expressions = withReference ? _referenceExpressions : _defaultExpressions;
            return expressions.TryGetValue(new TypePair(source, dest), out result);
        }

        public bool TryGetExpression<TDest>([NotNullWhen(true)] out Expression<Func<TDest, TDest>>? result)
        {
            if (_destToDestExpressions.TryGetValue(typeof(TDest), out var value))
            {
                result = (Expression<Func<TDest, TDest>>)value;
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        public bool TryGetExpression(Type dest, out LambdaExpression? result)
        {
            return _destToDestExpressions.TryGetValue(dest, out result);
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDest"></typeparam>
        /// <param name="withReference"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public Expression<Func<TSource, TDest>> Get<TSource, TDest>(bool withReference)
        {
            return (Expression<Func<TSource, TDest>>)Get(typeof(TSource), typeof(TDest), withReference);
        }

        /// <summary>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <param name="withReference"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public LambdaExpression Get(Type source, Type dest, bool withReference)
        {
            ReadOnlyDictionary<TypePair, LambdaExpression> expressions = withReference ? _referenceExpressions : _defaultExpressions;
            return expressions[new TypePair(source, dest)];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TDest"></typeparam>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public Expression<Func<TDest, TDest>> Get<TDest>()
        {
            return (Expression<Func<TDest, TDest>>)_destToDestExpressions[typeof(TDest)];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dest"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public LambdaExpression Get(Type dest)
        {
            return _destToDestExpressions[dest];
        }
    }
}