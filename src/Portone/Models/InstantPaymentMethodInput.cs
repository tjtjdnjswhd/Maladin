namespace Portone.Models
{
    /// <summary>
    /// 수기 결제 수단 입력 정보
    /// <br/>하나의 필드만 입력합니다.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class InstantPaymentMethodInput
    {
        [Newtonsoft.Json.JsonProperty("card", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public InstantPaymentMethodInputCard Card { get; set; }

        [Newtonsoft.Json.JsonProperty("virtualAccount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public InstantPaymentMethodInputVirtualAccount VirtualAccount { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}