using ReferenceExpression.Exceptions;
using ReferenceExpression.Internals;

using System.Linq.Expressions;

namespace ReferenceExpression
{
    public class ReferenceExpressionProviderBuilder
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
                throw new InvalidReferenceException("Lambda expression must have single parameter");
            }
            _expressions.Add(new TypePair(expression.Parameters.First().Type, expression.ReturnType), expression);
        }

        public ReferenceExpressionProvider Build(int maxDepth, bool referenceRecursion)
        {
            ReferenceExpressionsFactory factory = new(_expressions, maxDepth, referenceRecursion);
            Dictionary<TypePair, LambdaExpression> referenceExpressions = factory.CreateReferenceExpressions();
            return new ReferenceExpressionProvider(new(referenceExpressions), new(_expressions));
        }
    }
}