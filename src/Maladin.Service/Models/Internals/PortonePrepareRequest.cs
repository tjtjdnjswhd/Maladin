using System.Text.Json.Serialization;

namespace Maladin.Service.Models.Internals
{
    internal class PortonePrepareRequest
    {
        public PortonePrepareRequest(string merchantUid, int amount)
        {
            MerchantUid = merchantUid;
            Amount = amount;
        }

        [JsonPropertyName("merchant_uid")]
        public string MerchantUid { get; set; }
        
        [JsonPropertyName("amount")]
        public int Amount { get; set; }
    }
}
