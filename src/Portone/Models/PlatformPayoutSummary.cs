namespace Portone.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PlatformPayoutSummary
    {
        [Newtonsoft.Json.JsonProperty("partnerCount", Required = Newtonsoft.Json.Required.Always)]
        public int PartnerCount { get; set; }

        [Newtonsoft.Json.JsonProperty("totalSettlementAmount", Required = Newtonsoft.Json.Required.Always)]
        public long TotalSettlementAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("paidOutPartnerSettlementCount", Required = Newtonsoft.Json.Required.Always)]
        public int PaidOutPartnerSettlementCount { get; set; }

        [Newtonsoft.Json.JsonProperty("totalPartnerSettlementCount", Required = Newtonsoft.Json.Required.Always)]
        public int TotalPartnerSettlementCount { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}