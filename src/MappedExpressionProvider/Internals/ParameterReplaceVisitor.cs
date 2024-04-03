using System.Linq.Expressions;

namespace MappedExpressionProvider.Internals
{
    internal class ParameterReplaceVisitor(ParameterExpression oldParameter, Expression newExp) : ExpressionVisitor
    {
        private readonly ParameterExpression _oldParameter = oldParameter;
        private readonly Expression _newExp = newExp;

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node == _oldParameter ? _newExp : base.VisitParameter(node);
        }
    }
}