using System.Diagnostics;

namespace ReferenceExpression
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public record struct TypePair(Type Source, Type Dest)
    {
        private readonly string DebuggerDisplay => $"Source: {Source.FullName}, Dest: {Dest.FullName}";
    }
}