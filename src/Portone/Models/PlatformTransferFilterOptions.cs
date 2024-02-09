namespace Portone.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PlatformTransferFilterOptions
    {
        [Newtonsoft.Json.JsonProperty("partnerTags", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required ICollection<string> PartnerTags { get; set; }

        [Newtonsoft.Json.JsonProperty("contractIds", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required ICollection<string> ContractIds { get; set; }

        [Newtonsoft.Json.JsonProperty("additionalFeePolicyIds", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required ICollection<string> AdditionalFeePolicyIds { get; set; }

        [Newtonsoft.Json.JsonProperty("discountSharePolicyIds", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required ICollection<string> DiscountSharePolicyIds { get; set; }

        [Newtonsoft.Json.JsonProperty("paymentChannels", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required ICollection<PlatformPaymentChannel> PaymentChannels { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}