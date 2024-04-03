using Maladin.Api.Models.Dtos.Read.Abstractions;
using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Maladin.Api.Models.Dtos.Read
{
    public class OAuthIdRead : ReadBase
    {
        [Required(AllowEmptyStrings = false)]
        public required string NameIdentifier { get; set; }

        [EntityId]
        public required int ProviderId { get; set; }

        [EntityId]
        public required int UserId { get; set; }

        [JsonIgnore]
        public OAuthProviderRead? Provider { get; private set; }

        [JsonIgnore]
        public UserRead? User { get; private set; }
    }
}