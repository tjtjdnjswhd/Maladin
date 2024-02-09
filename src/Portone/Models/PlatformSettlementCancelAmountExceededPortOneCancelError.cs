namespace Portone.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PlatformSettlementCancelAmountExceededPortOneCancelError
    {
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("registeredSettlementCancelAmount", Required = Newtonsoft.Json.Required.Always)]
        public long RegisteredSettlementCancelAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("requestSettlementCancelAmount", Required = Newtonsoft.Json.Required.Always)]
        public long RequestSettlementCancelAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("portOneCancelAmount", Required = Newtonsoft.Json.Required.Always)]
        public long PortOneCancelAmount { get; set; }

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