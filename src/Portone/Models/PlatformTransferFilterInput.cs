namespace Portone.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PlatformTransferFilterInput
    {
        [Newtonsoft.Json.JsonProperty("settlementStartDateRange", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateRange SettlementStartDateRange { get; set; }

        [Newtonsoft.Json.JsonProperty("settlementDateRange", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateRange SettlementDateRange { get; set; }

        [Newtonsoft.Json.JsonProperty("partnerTags", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ICollection<string> PartnerTags { get; set; }

        [Newtonsoft.Json.JsonProperty("contractIds", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ICollection<string> ContractIds { get; set; }

        [Newtonsoft.Json.JsonProperty("discountSharePolicyIds", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ICollection<string> DiscountSharePolicyIds { get; set; }

        [Newtonsoft.Json.JsonProperty("additionalFeePolicyIds", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ICollection<string> AdditionalFeePolicyIds { get; set; }

        [Newtonsoft.Json.JsonProperty("paymentMethodTypes", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore, ItemConverterType = typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ICollection<PaymentMethodType> PaymentMethodTypes { get; set; }

        [Newtonsoft.Json.JsonProperty("channelKeys", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ICollection<string> ChannelKeys { get; set; }

        [Newtonsoft.Json.JsonProperty("types", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore, ItemConverterType = typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ICollection<PlatformTransferType> Types { get; set; }

        [Newtonsoft.Json.JsonProperty("statuses", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore, ItemConverterType = typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ICollection<PlatformTransferStatus> Statuses { get; set; }

        [Newtonsoft.Json.JsonProperty("keyword", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlatformTransferFilterInputKeyword Keyword { get; set; }

        [Newtonsoft.Json.JsonProperty("isForTest", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsForTest { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}