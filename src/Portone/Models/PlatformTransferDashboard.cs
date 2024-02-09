namespace Portone.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PlatformTransferDashboard
    {
        [Newtonsoft.Json.JsonProperty("totalSettlementAmount", Required = Newtonsoft.Json.Required.Always)]
        public long TotalSettlementAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("totalSettlementFeeAmount", Required = Newtonsoft.Json.Required.Always)]
        public long TotalSettlementFeeAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("totalOrderAmount", Required = Newtonsoft.Json.Required.Always)]
        public long TotalOrderAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("settlementStartDateRange", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateRange SettlementStartDateRange { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}