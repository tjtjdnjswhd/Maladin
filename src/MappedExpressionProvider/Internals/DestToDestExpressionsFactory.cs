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
                Type destType = pair.Key.Dest;
                ParameterExpression parameterExpression = Expression.Parameter(destType);
                Expression newBody = ChangeDestObjectExpression(parameterExpression, body);

                LambdaExpression destToDestLambda = Expression.Lambda(newBody, parameterExpression);
                return destToDestLambda;
            });

            return result;
        }

        private static Expression ChangeDestObjectExpression(Expression destObjectExpression, Expression expression)
        {
            return expression switch
            {
                MemberInitExpression memberInitExpression => GetDestToDestMemberInit(destObjectExpression, memberInitExpression),
                ConditionalExpression conditionalExpression => GetDestToDestConditionalRecursive(destObjectExpression, conditionalExpression),
                UnaryExpression unaryExpression when unaryExpression.NodeType is ExpressionType.Convert => ChangeDestObjectExpression(destObjectExpression, unaryExpression.Operand),
                _ => throw new NotImplementedException()
            };
        }

        private static MemberInitExpression GetDestToDestMemberInit(Expression destObjectExpression, MemberInitExpression sourceToDestInitExpression)
        {
            IEnumerable<MemberInfo> initedMembers = sourceToDestInitExpression.Bindings.Select(b => b.Member);

            Expression memberBelong = destObjectExpression.Type == sourceToDestInitExpression.Type ? destObjectExpression : Expression.Convert(destObjectExpression, sourceToDestInitExpression.Type);
            IEnumerable<MemberBinding> bindings = initedMembers.Select(m => Expression.Bind(m, Expression.MakeMemberAccess(memberBelong, m)));

            MemberInitExpression destToDestInitExpression = Expression.MemberInit(sourceToDestInitExpression.NewExpression, bindings);
            return destToDestInitExpression;
        }

        private static ConditionalExpression GetDestToDestConditionalRecursive(Expression destObjectExpression, ConditionalExpression conditionalExpression)
        {
            Expression testExpression = conditionalExpression.Test is TypeBinaryExpression ? Expression.TypeIs(destObjectExpression, destObjectExpression.Type) : conditionalExpression.Test;
            Expression ifTrue = ChangeDestObjectExpression(destObjectExpression, conditionalExpression.IfTrue);
            Expression ifFalse = ChangeDestObjectExpression(destObjectExpression, conditionalExpression.IfFalse);

            return Expression.Condition(testExpression, ifTrue, ifFalse, destObjectExpression.Type);
        }
    }
}