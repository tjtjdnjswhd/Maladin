using System.Text.Json.Serialization;

namespace Maladin.Api.Models.Dtos
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EGoodsKind
    {
        BookDisplay,
        Pencil,
        Unknown
    }
}