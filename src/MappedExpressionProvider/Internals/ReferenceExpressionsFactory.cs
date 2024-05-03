using MappedExpressionProvider.Attributes;
using MappedExpressionProvider.Exceptions;

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

namespace MappedExpressionProvider.Internals
{
    internal class ReferenceExpressionsFactory
    {
        private readonly Dictionary<TypePair, LambdaExpression> _defaultExpressions;
        private readonly int _maxDepth;
        private readonly bool _mapRecursion;

        public ReferenceExpressionsFactory(Dictionary<TypePair, LambdaExpression> defaultExpressions, int maxDepth, bool mapRecursion)
        {
            Debug.Assert(defaultExpressions.All(e => e.Value.Parameters.Count == 1));
            _defaultExpressions = defaultExpressions;
            _maxDepth = maxDepth;
            _mapRecursion = mapRecursion;
        }

        public Dictionary<TypePair, LambdaExpression> Create()
        {
            Dictionary<TypePair, LambdaExpression> result = _defaultExpressions.ToDictionary(pair => pair.Key, pair => CreateRecursive(pair.Value, []));
            return result;
        }

        private LambdaExpression CreateRecursive(LambdaExpression destMapExp, HashSet<Type> mappedDestTypes, int depth = 0)
        {
            const string IEnumerableName = "IEnumerable`1";

            if (depth >= _maxDepth)
            {
                return destMapExp;
            }

            mappedDestTypes.Add(destMapExp.ReturnType);
            MembetInitGetVisitor membetInitGetVisitor = new();
            List<MemberInitExpression> oldDestInitExpressions = membetInitGetVisitor.GetMemberInitExpressions(destMapExp);
            Dictionary<MemberInitExpression, MemberInitExpression> oldNewInitExpressions = oldDestInitExpressions.ToDictionary(oldDestInitExp => oldDestInitExp, oldDestInitExp =>
            {
                Type destType = oldDestInitExp.Type;

                MemberInfo[] unInitDestMembers = destType.FindMembers(
                    memberType: MemberTypes.Property | MemberTypes.Field,
                    bindingAttr: BindingFlags.Public | BindingFlags.Instance,
                    filter: (m, _) => !(m.IsDefined(typeof(ExcludeReferenceAttribute)) || oldDestInitExp.Bindings.Any(b => b.Member.MetadataToken == m.MetadataToken && b.Member.Module.Equals(m.Module))),
                    filterCriteria: null);

                ParameterExpression sourceParameterExp = destMapExp.Parameters.Single();
                Type sourceType = sourceParameterExp.Type;
                MemberInfo[] sourceMemberInfos = sourceType.FindMembers(MemberTypes.Field | MemberTypes.Property, BindingFlags.Public | BindingFlags.Instance, null, null);

                List<MemberBinding> newBindings = [];
                foreach (var destMemberInfo in unInitDestMembers)
                {
                    Type destMemberType = GetMemberClrType(destMemberInfo);

                    bool isEnforce = destMemberInfo.IsDefined(typeof(EnforceReferenceMapAttribute));
                    string sourceMemberName = destMemberInfo.GetCustomAttribute<SourceMemberNameAttribute>()?.SourceMemberName ?? destMemberInfo.Name;
                    MemberInfo? sourceMemberInfo = sourceMemberInfos.FirstOrDefault(m => m.Name.Equals(sourceMemberName, StringComparison.OrdinalIgnoreCase));
                    if (sourceMemberInfo is null)
                    {
                        ThrowEnforceExceptionIf(isEnforce, "Member '{0}' not defined from '{1}'", sourceMemberName, destType.FullName!);
                        continue;
                    }

                    MemberExpression sourceMemberAccess = Expression.MakeMemberAccess(sourceParameterExp, sourceMemberInfo);
                    Type sourceMemberType = GetMemberClrType(sourceMemberInfo);

                    if (destMemberType.GetInterface(IEnumerableName) is Type destMemberiEnumerable)
                    {
                        Type sourceMemberiEnumerable = sourceMemberType.GetInterface(IEnumerableName)
                            ?? throw new InvalidExpressionException($"{destType.FullName}.{destMemberInfo.Name} is IEnumerable but {sourceType.FullName}.{sourceMemberName} is not IEnumerable");

                        Type destElementType = destMemberiEnumerable.GenericTypeArguments[0];
                        Type sourceElementType = sourceMemberiEnumerable.GenericTypeArguments[0];

                        TypePair typePair = new(sourceElementType, destElementType);
                        if (!_mapRecursion && mappedDestTypes.Contains(destElementType))
                        {
                            continue;
                        }

                        if (!_defaultExpressions.TryGetValue(typePair, out LambdaExpression? defaultExpression))
                        {
                            ThrowEnforceExceptionIf(isEnforce, "Expression {0} to {1} not exist", sourceElementType.FullName!, destElementType.FullName!);
                            continue;
                        }

                        defaultExpression = CreateRecursive(defaultExpression, mappedDestTypes, depth + 1);
                        ParameterExpression oldParameter = defaultExpression.Parameters.Single();

                        ParameterExpression newParameter = Expression.Parameter(sourceElementType, oldParameter.Name);
                        ParameterReplaceVisitor parameterReplace = new(oldParameter, newParameter);
                        defaultExpression = (LambdaExpression)parameterReplace.Visit(defaultExpression);

                        MethodCallExpression selectExp = Expression.Call(typeof(Enumerable), nameof(Enumerable.Select), [sourceElementType, destElementType], sourceMemberAccess, defaultExpression);
                        MemberBinding memberBinding;
                        if (destMemberType.IsArray)
                        {
                            memberBinding = Expression.Bind(destMemberInfo, Expression.Call(typeof(Enumerable), nameof(Enumerable.ToArray), [destElementType], selectExp));
                        }
                        else if (destMemberType == typeof(List<>).MakeGenericType(destElementType))
                        {
                            memberBinding = Expression.Bind(destMemberInfo, Expression.Call(typeof(Enumerable), nameof(Enumerable.ToList), [destElementType], selectExp));
                        }
                        else if (destMemberType == typeof(HashSet<>).MakeGenericType(destElementType))
                        {
                            memberBinding = Expression.Bind(destMemberInfo, Expression.Call(typeof(Enumerable), nameof(Enumerable.ToHashSet), [destElementType], selectExp));
                        }
                        else
                        {
                            memberBinding = Expression.Bind(destMemberInfo, selectExp);
                        }

                        newBindings.Add(memberBinding);
                    }
                    else
                    {
                        if (!_mapRecursion && mappedDestTypes.Contains(destMemberType))
                        {
                            continue;
                        }

                        TypePair typePair = new(sourceMemberType, destMemberType);
                        if (!_defaultExpressions.TryGetValue(typePair, out LambdaExpression? defaultExpression))
                        {
                            ThrowEnforceExceptionIf(isEnforce, "Expression {0} to {1} not exist", sourceMemberType.FullName!, destMemberType.FullName!);
                            continue;
                        }

                        defaultExpression = CreateRecursive(defaultExpression, mappedDestTypes, depth + 1);
                        ParameterExpression oldParameter = defaultExpression.Parameters.Single();
                        ParameterReplaceVisitor parameterReplaceVisitor = new(oldParameter, sourceMemberAccess);
                        Expression parameterReplacedExpression = parameterReplaceVisitor.Visit(defaultExpression.Body);

                        MemberBinding memberBinding = Expression.Bind(destMemberInfo, parameterReplacedExpression);
                        newBindings.Add(memberBinding);
                    }
                }

                MemberInitExpression newDestMemberInitExp = Expression.MemberInit(oldDestInitExp.NewExpression, oldDestInitExp.Bindings.Concat(newBindings));
                return newDestMemberInitExp;
            });

            MemberInitReplaceVisitor memberInitReplaceVisitor = new(oldNewInitExpressions);
            LambdaExpression newDestMemberLambdaExp = (LambdaExpression)memberInitReplaceVisitor.Visit(destMapExp);
            return newDestMemberLambdaExp;
        }

        private static void ThrowEnforceExceptionIf([DoesNotReturnIf(true)] bool isEnforce, string message, params object[] args)
        {
            if (isEnforce)
            {
                throw new EnforceReferenceException(string.Format(message, args));
            }
        }

        private static Type GetMemberClrType(MemberInfo member)
        {
            Type? result = member switch
            {
                FieldInfo field => field.FieldType,
                PropertyInfo property => property.PropertyType,
                _ => null
            };
            Debug.Assert(result is not null);
            return result;
        }
    }
}