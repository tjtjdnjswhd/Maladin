namespace Portone.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PayoutPartnerSettlementsResponse
    {
        [Newtonsoft.Json.JsonProperty("items", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required ICollection<PlatformPayoutPartnerSettlement> Items { get; set; }

        [Newtonsoft.Json.JsonProperty("page", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required PageInfo Page { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}