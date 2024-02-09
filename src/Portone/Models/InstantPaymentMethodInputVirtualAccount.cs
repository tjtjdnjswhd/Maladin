namespace Portone.Models
{
    /// <summary>
    /// 가상계좌 수단 정보 입력 정보
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class InstantPaymentMethodInputVirtualAccount
    {
        [Newtonsoft.Json.JsonProperty("bank", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public required Bank Bank { get; set; }

        [Newtonsoft.Json.JsonProperty("expiry", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required InstantPaymentMethodInputVirtualAccountExpiry Expiry { get; set; }

        [Newtonsoft.Json.JsonProperty("option", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required InstantPaymentMethodInputVirtualAccountOption Option { get; set; }

        [Newtonsoft.Json.JsonProperty("cashReceipt", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required InstantPaymentMethodInputVirtualAccountCashReceiptInfo CashReceipt { get; set; }

        [Newtonsoft.Json.JsonProperty("remitteeName", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RemitteeName { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}