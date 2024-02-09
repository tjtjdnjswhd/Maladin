namespace Portone.Models
{
    /// <summary>
    /// 결제 건 다건 조회를 위한 입력 정보
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class GetPaymentsBody
    {
        /// <summary>
        /// 미 입력 시 number: 0, size: 10 으로 기본값이 적용됩니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("page", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PageInput Page { get; set; }

        /// <summary>
        /// V1 결제 건의 경우 일부 필드에 대해 필터가 적용되지 않을 수 있습니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("filter", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PaymentFilterInput Filter { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}