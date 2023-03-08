using System.Text.Json.Serialization;

namespace Maladin.Service.Models.Internals
{
    internal class PortoneAccessTokenRequest
    {
        public PortoneAccessTokenRequest(string impKey, string impSecret)
        {
            ImpKey = impKey;
            ImpSecret = impSecret;
        }

        [JsonPropertyName("imp_key")]
        public string ImpKey { get; set; }

        [JsonPropertyName("imp_secret")]
        public string ImpSecret { get; set; }
    }
}