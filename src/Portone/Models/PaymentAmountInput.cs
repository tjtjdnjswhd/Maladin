namespace Portone.Models
{
    /// <summary>
    /// 금액 세부 입력 정보
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PaymentAmountInput
    {
        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.Always)]
        public long Total { get; set; }

        [Newtonsoft.Json.JsonProperty("taxFree", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long TaxFree { get; set; }

        /// <summary>
        /// &lt;p&gt;가맹점에서 직접 계산이 필요한 경우 입력합니다.
        /// <br/>입력하지 않으면 면세 금액을 제외한 금액의 1/11 로 자동 계산됩니다.&lt;/p&gt;
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("vat", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long Vat { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}