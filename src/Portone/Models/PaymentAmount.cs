namespace Portone.Models
{
    /// <summary>
    /// 결제 금액 세부 정보
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PaymentAmount
    {
        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.Always)]
        public long Total { get; set; }

        [Newtonsoft.Json.JsonProperty("taxFree", Required = Newtonsoft.Json.Required.Always)]
        public long TaxFree { get; set; }

        [Newtonsoft.Json.JsonProperty("vat", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long Vat { get; set; }

        [Newtonsoft.Json.JsonProperty("supply", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long Supply { get; set; }

        /// <summary>
        /// 카드사 프로모션, 아임포트 프로모션, 적립형 포인트 결제, 쿠폰 할인 등을 포함합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("discount", Required = Newtonsoft.Json.Required.Always)]
        public long Discount { get; set; }

        [Newtonsoft.Json.JsonProperty("paid", Required = Newtonsoft.Json.Required.Always)]
        public long Paid { get; set; }

        [Newtonsoft.Json.JsonProperty("cancelled", Required = Newtonsoft.Json.Required.Always)]
        public long Cancelled { get; set; }

        [Newtonsoft.Json.JsonProperty("cancelledTaxFree", Required = Newtonsoft.Json.Required.Always)]
        public long CancelledTaxFree { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}