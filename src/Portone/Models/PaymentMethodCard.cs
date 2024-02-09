using Newtonsoft.Json;
using Portone.Models.Abstractions;

namespace Portone.Models
{
    /// <summary>
    /// 결제 수단 카드 정보
    /// <br/>
    /// </summary>
    public class PaymentMethodCard : PaymentMethodEasyPayMethod, PaymentMethod
    {
        [JsonProperty("type", Required = Required.Always)]
        public string Type { get; set; }

        [JsonProperty("card")]
        public Card Card { get; set; }

        [JsonProperty("approvalNumber")]
        public string ApprovalNumber { get; set; }

        [JsonProperty("installment")]
        public PaymentInstallment Installment { get; set; }

        [JsonProperty("pointUsed")]
        public bool PointUsed { get; set; }
    }
}