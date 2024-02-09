using Portone.Models.Abstractions;

namespace Portone.Models
{
    /// <summary>
    /// 가상계좌 상세 정보
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PaymentMethodVirtualAccount : PaymentMethod
    {
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("bank", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Bank { get; set; }

        [Newtonsoft.Json.JsonProperty("accountNumber", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string AccountNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("accountType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PaymentMethodVirtualAccountType AccountType { get; set; }

        [Newtonsoft.Json.JsonProperty("remitteeName", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RemitteeName { get; set; }

        [Newtonsoft.Json.JsonProperty("remitterName", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RemitterName { get; set; }

        [Newtonsoft.Json.JsonProperty("expiredAt", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateTimeOffset ExpiredAt { get; set; }

        [Newtonsoft.Json.JsonProperty("issuedAt", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateTimeOffset IssuedAt { get; set; }

        [Newtonsoft.Json.JsonProperty("refundStatus", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PaymentMethodVirtualAccountRefundStatus RefundStatus { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}