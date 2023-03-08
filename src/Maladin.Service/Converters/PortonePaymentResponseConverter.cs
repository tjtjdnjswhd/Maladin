using Maladin.Service.Models;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Maladin.Service.Converters
{
    internal class PortonePaymentResponseConverter : JsonConverter<PortonePaymentResponse>
    {
        public override PortonePaymentResponse? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            while (reader.TokenType != JsonTokenType.PropertyName)
            {
                reader.Read();
            }

            PortonePaymentResponse result = new();
            DeserializeProperty(ref reader, result);

            while (reader.Read()) ;
            return result;
        }

        public override void Write(Utf8JsonWriter writer, PortonePaymentResponse value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        private static void DeserializeProperty<T>(ref Utf8JsonReader reader, T obj) where T : class
        {
            Debug.Assert(reader.TokenType is JsonTokenType.StartObject or JsonTokenType.PropertyName);
            Dictionary<string, PropertyInfo> propertyInfoByJsonPropertyName = obj.GetType().GetProperties()
                .ToDictionary(p => p.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? p.Name, p => p);

            foreach (string name in propertyInfoByJsonPropertyName.Keys)
            {
                if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    reader.Read(); // value
                }

                if (reader.TokenType == JsonTokenType.Null)
                {
                    reader.Read();
                    continue;
                }

                PropertyInfo propertyInfo = propertyInfoByJsonPropertyName[name];
                Type propertyType = propertyInfo.PropertyType;

                if (propertyType.IsClass && propertyType != typeof(string) && !propertyType.IsArray)
                {
                    DeserializeProperty(ref reader, propertyInfo.GetValue(obj)!);
                    continue;
                }

                while (!IsPointValues(ref reader))
                {
                    reader.Read();
                }

                object? value = ParseValue(ref reader, propertyType);

                propertyInfo.SetValue(obj, value);

                if (!propertyType.IsArray)
                {
                    reader.Read();
                }
            }
        }

        private static object? ParseValue(ref Utf8JsonReader reader, Type type)
        {
            Debug.Assert(IsPointValues(ref reader));

            Type target = Nullable.GetUnderlyingType(type) ?? type;

            if (target.IsEnum)
            {
                Enum.TryParse(target, reader.GetString(), true, out object? result);
                return result;
            }
            else if (target.IsArray)
            {
                Debug.Assert(reader.TokenType == JsonTokenType.StartArray);
                reader.Read();

                Type elementType = target.GetElementType()!;
                System.Collections.ArrayList array = new();

                while (reader.TokenType != JsonTokenType.EndArray)
                {
                    object element;

                    if (elementType == typeof(string))
                    {
                        element = reader.GetString()!;
                    }
                    else if (elementType.IsClass)
                    {
                        element = elementType.GetConstructor(Array.Empty<Type>())!.Invoke(null);
                        DeserializeProperty(ref reader, element);
                    }
                    else
                    {
                        element = ParseValue(ref reader, elementType)!;
                    }

                    array.Add(element);

                    reader.Read();
                }
                reader.Read();

                return array.ToArray(elementType);
            }
            else if (target == typeof(sbyte))
            {
                return reader.GetSByte();
            }
            else if (target == typeof(byte))
            {
                return reader.GetByte();
            }
            else if (target == typeof(bool))
            {
                return reader.GetBoolean();
            }
            else if (target == typeof(char))
            {
                return reader.GetString()![0];
            }
            else if (target == typeof(string))
            {
                return reader.GetString();
            }
            else if (target == typeof(float) || target == typeof(double))
            {
                return reader.GetDouble();
            }
            else if (target == typeof(decimal))
            {
                return reader.GetDecimal();
            }
            else if (target == typeof(short))
            {
                return reader.GetInt16();
            }
            else if (target == typeof(int))
            {
                return reader.GetInt32();
            }
            else if (target == typeof(long))
            {
                return reader.GetInt64();
            }
            else if (target == typeof(ushort))
            {
                return reader.GetUInt16();
            }
            else if (target == typeof(uint))
            {
                return reader.GetUInt32();
            }
            else if (target == typeof(ulong))
            {
                return reader.GetUInt64();
            }
            else if (target == typeof(DateTime))
            {
                if (reader.TokenType is JsonTokenType.String)
                {
                    return DateTime.Parse(reader.GetString()!);
                }
                else
                {
                    return DateTime.FromBinary(reader.GetInt64());
                }
            }
            else if (target == typeof(DateTimeOffset))
            {
                if (reader.TokenType is JsonTokenType.String)
                {
                    return reader.GetDateTimeOffset();
                }
                else
                {
                    return DateTimeOffset.FromUnixTimeSeconds(reader.GetInt64());
                }
            }

            return null;
        }

        private static bool IsPointValues(ref Utf8JsonReader reader)
        {
            return reader.TokenType is JsonTokenType.StartArray or JsonTokenType.Number or JsonTokenType.String or JsonTokenType.True or JsonTokenType.False or JsonTokenType.Null;
        }
    }
}