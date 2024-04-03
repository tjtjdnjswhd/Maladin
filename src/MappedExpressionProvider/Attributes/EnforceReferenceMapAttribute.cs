namespace MappedExpressionProvider.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class EnforceReferenceMapAttribute : Attribute
    {
    }
}