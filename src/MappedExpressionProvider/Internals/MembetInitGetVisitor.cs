using System.Linq.Expressions;

namespace MappedExpressionProvider.Internals
{
    public class MembetInitGetVisitor : ExpressionVisitor
    {
#pragma warning disable CS8618 // 생성자를 종료할 때 null을 허용하지 않는 필드에 null이 아닌 값을 포함해야 합니다. null 허용으로 선언해 보세요.
        private List<MemberInitExpression> _result;
#pragma warning restore CS8618 // 생성자를 종료할 때 null을 허용하지 않는 필드에 null이 아닌 값을 포함해야 합니다. null 허용으로 선언해 보세요.

        public List<MemberInitExpression> GetMemberInitExpressions(Expression expression)
        {
            _result = [];
            Visit(expression);
            return _result;
        }

        protected override Expression VisitMemberInit(MemberInitExpression node)
        {
            _result.Add(node);
            return base.VisitMemberInit(node);
        }
    }
}