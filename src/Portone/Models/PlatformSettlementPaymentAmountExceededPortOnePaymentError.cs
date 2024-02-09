namespace Portone.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PlatformSettlementPaymentAmountExceededPortOnePaymentError
    {
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("registeredSettlementPaymentAmount", Required = Newtonsoft.Json.Required.Always)]
        public long RegisteredSettlementPaymentAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("requestSettlementPaymentAmount", Required = Newtonsoft.Json.Required.Always)]
        public long RequestSettlementPaymentAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("portOnePaymentAmount", Required = Newtonsoft.Json.Required.Always)]
        public long PortOnePaymentAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Message { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}