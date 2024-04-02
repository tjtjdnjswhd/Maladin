namespace ReferenceExpression.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ExcludeReferenceAttribute : Attribute
    {
    }
}