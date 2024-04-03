using System.Linq.Expressions;

namespace MappedExpressionProvider.Internals
{
    public class MemberInitReplaceVisitor(Dictionary<MemberInitExpression, MemberInitExpression> oldNewExpressions) : ExpressionVisitor
    {
        private readonly Dictionary<MemberInitExpression, MemberInitExpression> _oldNewExpressions = oldNewExpressions;

        protected override Expression VisitMemberInit(MemberInitExpression node)
        {
            if (_oldNewExpressions.TryGetValue(node, out MemberInitExpression? newExp))
            {
                return newExp;
            }
            else
            {
                return node;
            }
        }
    }
}