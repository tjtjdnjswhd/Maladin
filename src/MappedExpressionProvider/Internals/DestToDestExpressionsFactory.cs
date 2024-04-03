using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace MappedExpressionProvider.Internals
{
    internal class DestToDestExpressionsFactory
    {
        private readonly Dictionary<TypePair, LambdaExpression> _defaultExpressions;

        public DestToDestExpressionsFactory(Dictionary<TypePair, LambdaExpression> defaultExpressions)
        {
            Debug.Assert(defaultExpressions.All(e => e.Value.Parameters.Count == 1));
            _defaultExpressions = defaultExpressions;
        }

        public Dictionary<Type, LambdaExpression> Create()
        {
            Dictionary<Type, LambdaExpression> result = _defaultExpressions.ToDictionary(pair => pair.Key.Dest, pair =>
            {
                Expression body = pair.Value.Body;
                LambdaExpression destToDestLambda;
                Type destType = pair.Key.Dest;
                ParameterExpression parameterExpression = Expression.Parameter(destType);

                if (body is MemberInitExpression memberInitExpression)
                {
                    IEnumerable<MemberInfo> initedMembers = memberInitExpression.Bindings.Select(b => b.Member);

                    IEnumerable<MemberBinding> bindings = initedMembers.Select(m => Expression.Bind(m, Expression.MakeMemberAccess(parameterExpression, m)));

                    MemberInitExpression destToDestInitExpression = Expression.MemberInit(memberInitExpression.NewExpression, bindings);
                    destToDestLambda = Expression.Lambda(destToDestInitExpression, parameterExpression);
                }
                else if (body is ConditionalExpression conditionalExpression)
                {
                    //TODO: 삼항 연산자일 때 구현
                    //재귀 필요
                    throw new NotImplementedException();
                }
                else
                {
                    throw new NotImplementedException();
                }

                return destToDestLambda;
            });

            return result;
        }
    }
}