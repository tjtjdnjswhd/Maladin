namespace Portone.Models
{
    /// <summary>
    /// 고객사의 해외 결제 사용 여부
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class AnalyticsOverseasPaymentUsage
    {
        [Newtonsoft.Json.JsonProperty("isUsing", Required = Newtonsoft.Json.Required.Always)]
        public bool IsUsing { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}