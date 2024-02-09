using Portone.Models.Abstractions;

namespace Portone.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class UpdatePlatformPayoutPartnerSettlementResponse
    {
        [Newtonsoft.Json.JsonProperty("payoutPartnerSettlement", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required PlatformPayoutPartnerSettlement PayoutPartnerSettlement { get; set; }

        [Newtonsoft.Json.JsonProperty("payout", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required PlatformPayout Payout { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}