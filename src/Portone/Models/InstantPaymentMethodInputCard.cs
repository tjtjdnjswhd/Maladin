namespace Portone.Models
{
    /// <summary>
    /// 카드 수단 정보 입력 정보
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class InstantPaymentMethodInputCard
    {
        [Newtonsoft.Json.JsonProperty("credential", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required CardCredential Credential { get; set; }

        [Newtonsoft.Json.JsonProperty("installmentMonth", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int InstallmentMonth { get; set; }

        [Newtonsoft.Json.JsonProperty("useFreeInstallmentPlan", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool UseFreeInstallmentPlan { get; set; }

        [Newtonsoft.Json.JsonProperty("useFreeInterestFromMerchant", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool UseFreeInterestFromMerchant { get; set; }

        [Newtonsoft.Json.JsonProperty("useCardPoint", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool UseCardPoint { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}