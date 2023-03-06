using Maladin.Service.Models;

using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Maladin.Service.Converters
{
    public class PortonePaymentResponseConverter : JsonConverter<PortonePaymentResponse>
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

        private static void DeserializeProperty<T>(ref Utf8JsonReader reader, T obj)
        {
            Debug.Assert(reader.TokenType is JsonTokenType.StartObject or JsonTokenType.PropertyName);
            Dictionary<string, PropertyInfo> propertyInfoByJsonPropertyName = obj!.GetType().GetProperties()
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

                if (propertyInfo.PropertyType.IsClass && propertyInfo.PropertyType != typeof(string) && !propertyInfo.PropertyType.IsArray)
                {
                    DeserializeProperty(ref reader, propertyInfo.GetValue(obj));
                    continue;
                }

                while (!IsPointValues(ref reader))
                {
                    reader.Read();
                }

                object? value = ParseValue(ref reader, propertyInfo.PropertyType);

                if (propertyInfo.PropertyType.IsArray)
                {
                    propertyInfo.SetValue(obj, value, null);
                }
                else
                {
                    propertyInfo.SetValue(obj, value);
                    reader.Read();
                }

            }
        }

        private static object? ParseValue(ref Utf8JsonReader reader, Type type)
        {
            if (type.IsEnum)
            {
                return reader.GetString();
            }
            else if (type.IsArray)
            {
                Debug.Assert(reader.TokenType == JsonTokenType.StartArray);
                reader.Read();
                Type elementType = type.GetElementType()!;
                System.Collections.ArrayList array = new();

                while (reader.TokenType != JsonTokenType.EndArray)
                {
                    object element;
                    if (elementType == typeof(string))
                    {
                        element = elementType.GetConstructor(new Type[] { typeof(char[]) })!.Invoke(new object[] { reader.GetString()!.ToCharArray() });
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
            else if (type == typeof(sbyte))
            {
                return reader.GetSByte();
            }
            else if (type == typeof(byte))
            {
                return reader.GetByte();
            }
            else if (type == typeof(bool))
            {
                return reader.GetBoolean();
            }
            else if (type == typeof(char))
            {
                return reader.GetString()![0];
            }
            else if (type == typeof(string))
            {
                return reader.GetString();
            }
            else if (type == typeof(float) || type == typeof(double))
            {
                return reader.GetDouble();
            }
            else if (type == typeof(decimal))
            {
                return reader.GetDecimal();
            }
            else if (type == typeof(short))
            {
                return reader.GetInt16();
            }
            else if (type == typeof(int))
            {
                return reader.GetInt32();
            }
            else if (type == typeof(long))
            {
                return reader.GetInt64();
            }
            else if (type == typeof(ushort))
            {
                return reader.GetUInt16();
            }
            else if (type == typeof(uint))
            {
                return reader.GetUInt32();
            }
            else if (type == typeof(ulong))
            {
                return reader.GetUInt64();
            }
            else if (type == typeof(DateTime))
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
            else if (type == typeof(DateTimeOffset))
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