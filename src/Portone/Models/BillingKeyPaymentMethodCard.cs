using Newtonsoft.Json;
using Portone.Models.Abstractions;

namespace Portone.Models
{
    /// <summary>
    /// 카드 정보
    /// <br/>
    /// </summary>
    public class BillingKeyPaymentMethodCard : BillingKeyPaymentMethod, IBillingKeyPaymentMethodEasyPayMethod
    {
        [JsonProperty("type", Required = Required.Always)]
        public string Type { get; set; }

        [JsonProperty("card", Required = Required.Always)]
        public Card Card { get; set; }
    }
}