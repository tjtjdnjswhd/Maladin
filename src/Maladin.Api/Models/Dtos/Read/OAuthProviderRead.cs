using Maladin.Api.Models.Dtos.Read.Abstractions;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Maladin.Api.Models.Dtos.Read
{
    public class OAuthProviderRead : ReadBase
    {
        [Required(AllowEmptyStrings = false)]
        public required string Name { get; set; }

        [JsonIgnore]
        public List<OAuthIdRead>? OAuthIds { get; private set; }
    }
}