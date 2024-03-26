using System.Text.Json.Serialization;

namespace Maladin.Api.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EChallengeKind
    {
        Login,
        Signup,
        Add
    }
}