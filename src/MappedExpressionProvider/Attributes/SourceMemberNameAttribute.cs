namespace MappedExpressionProvider.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class SourceMemberNameAttribute(string sourceMemberName) : Attribute
    {
        public string SourceMemberName { get; } = sourceMemberName;
    }
}