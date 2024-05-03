using MappedExpressionProvider.Exceptions;
using MappedExpressionProvider.Internals;

using System.Linq.Expressions;

namespace MappedExpressionProvider
{
    public class MappedExpressionProviderBuilder
    {
        private readonly Dictionary<TypePair, LambdaExpression> _expressions = [];

        public void Add<TSource, TDest>(Expression<Func<TSource, TDest>> expression)
        {
            _expressions.Add(new TypePair(typeof(TSource), typeof(TDest)), expression);
        }

        public void Add(LambdaExpression expression)
        {
            if (expression.Parameters.Count != 1)
            {
                throw new InvalidExpressionException("Lambda expression must have single parameter");
            }
            _expressions.Add(new TypePair(expression.Parameters.First().Type, expression.ReturnType), expression);
        }

        public MappedExpressionProvider Build(int maxDepth, bool referenceRecursion)
        {
            ReferenceExpressionsFactory referenceExpressionsFactory = new(_expressions, maxDepth, referenceRecursion);
            Dictionary<TypePair, LambdaExpression> referenceExpressions = referenceExpressionsFactory.Create();

            DestToDestExpressionsFactory destToDestExpressionFactory = new(_expressions);
            Dictionary<Type, LambdaExpression> destToDestExpressions = destToDestExpressionFactory.Create();

            return new MappedExpressionProvider(new(_expressions), new(referenceExpressions), new(destToDestExpressions));
        }
    }
}