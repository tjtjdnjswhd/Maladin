namespace Portone.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PlatformPartnerSettlementFilterKeywordInput
    {
        [Newtonsoft.Json.JsonProperty("partnerId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartnerId { get; set; }

        [Newtonsoft.Json.JsonProperty("partnerEmail", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartnerEmail { get; set; }

        [Newtonsoft.Json.JsonProperty("partnerBusinessRegistrationNumber", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartnerBusinessRegistrationNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("partnerMemo", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartnerMemo { get; set; }

        [Newtonsoft.Json.JsonProperty("platformFee", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PlatformFee { get; set; }

        [Newtonsoft.Json.JsonProperty("contractMemo", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ContractMemo { get; set; }

        [Newtonsoft.Json.JsonProperty("additionalFeePolicyId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AdditionalFeePolicyId { get; set; }

        [Newtonsoft.Json.JsonProperty("additionalFeePolicyFee", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AdditionalFeePolicyFee { get; set; }

        [Newtonsoft.Json.JsonProperty("additionalFeePolicyMemo", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AdditionalFeePolicyMemo { get; set; }

        [Newtonsoft.Json.JsonProperty("discountSharePolicyId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DiscountSharePolicyId { get; set; }

        [Newtonsoft.Json.JsonProperty("discountSharePolicyRate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DiscountSharePolicyRate { get; set; }

        [Newtonsoft.Json.JsonProperty("discountSharePolicyMemo", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DiscountSharePolicyMemo { get; set; }

        [Newtonsoft.Json.JsonProperty("productId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ProductId { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}