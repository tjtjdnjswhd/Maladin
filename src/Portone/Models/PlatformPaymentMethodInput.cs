namespace Portone.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PlatformPaymentMethodInput
    {
        [Newtonsoft.Json.JsonProperty("card", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlatformPaymentMethodCardInput Card { get; set; }

        [Newtonsoft.Json.JsonProperty("transfer", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlatformPaymentMethodTransferInput Transfer { get; set; }

        [Newtonsoft.Json.JsonProperty("virtualAccount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlatformPaymentMethodVirtualAccountInput VirtualAccount { get; set; }

        [Newtonsoft.Json.JsonProperty("giftCertificate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlatformPaymentMethodGiftCertificateInput GiftCertificate { get; set; }

        [Newtonsoft.Json.JsonProperty("mobile", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlatformPaymentMethodMobileInput Mobile { get; set; }

        [Newtonsoft.Json.JsonProperty("easyPay", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlatformPaymentMethodEasyPayInput EasyPay { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}