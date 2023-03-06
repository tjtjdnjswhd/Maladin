using System.Text.Json.Serialization;

namespace Maladin.Service.Models
{
    public class PortoneCancelRequest
    {
        [JsonPropertyName("imp_uid")]
        public required string ImpUid { get; set; }

        [JsonPropertyName("merchant_uid")]
        public string? MerchantUid { get; set; }

        [JsonPropertyName("amount")]
        public int? Amount { get; set; }

        [JsonPropertyName("checksum")]
        public required int Checksum { get; set; }

        [JsonPropertyName("reason")]
        public string? Reason { get; set; }
    }
}
