namespace Portone.Models
{
    /// <summary>
    /// 할부 정보
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PaymentInstallment
    {
        [Newtonsoft.Json.JsonProperty("month", Required = Newtonsoft.Json.Required.Always)]
        public int Month { get; set; }

        [Newtonsoft.Json.JsonProperty("isInterestFree", Required = Newtonsoft.Json.Required.Always)]
        public bool IsInterestFree { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}