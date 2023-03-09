using System.Text.Json.Serialization;

namespace Maladin.Service.Models.Internals
{
    internal class PortoneCancelRequest
    {
        [JsonPropertyName("imp_uid")]
        public string? ImpUid { get; set; }

        [JsonPropertyName("merchant_uid")]
        public string? MerchantUid { get; set; }

        [JsonPropertyName("amount")]
        public required int? Amount { get; set; }

        [JsonPropertyName("checksum")]
        public required int Checksum { get; set; }

        [JsonPropertyName("refund_holder")]
        public string? RefundHolder { get; set; }
        
        [JsonPropertyName("refund_bank")]
        public string? RefundBank { get; set; }
        
        [JsonPropertyName("refund_account")]
        public string? RefundAccount { get; set; }
        
        [JsonPropertyName("refund_tel")]
        public string? RefundTel { get; set; }
    }
}