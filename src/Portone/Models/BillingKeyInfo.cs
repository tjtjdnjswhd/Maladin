using Portone.Models.Abstractions;

namespace Portone.Models
{
    /// <summary>
    /// 빌링키 정보
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class BillingKeyInfo
    {
        [Newtonsoft.Json.JsonProperty("billingKey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string BillingKey { get; set; }

        [Newtonsoft.Json.JsonProperty("merchantId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string MerchantId { get; set; }

        [Newtonsoft.Json.JsonProperty("storeId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string StoreId { get; set; }

        /// <summary>
        /// 추후 슈퍼빌링키 기능 제공 시 여러 결제수단 정보가 담길 수 있습니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("methods", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ICollection<BillingKeyPaymentMethod> Methods { get; set; }

        /// <summary>
        /// 추후 슈퍼빌링키 기능 제공 시 여러 채널 정보가 담길 수 있습니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("channels", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required ICollection<SelectedChannel> Channels { get; set; }

        [Newtonsoft.Json.JsonProperty("customer", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required Customer Customer { get; set; }

        [Newtonsoft.Json.JsonProperty("customData", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CustomData { get; set; }

        [Newtonsoft.Json.JsonProperty("issueId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IssueId { get; set; }

        [Newtonsoft.Json.JsonProperty("issueName", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IssueName { get; set; }

        [Newtonsoft.Json.JsonProperty("issuedAt", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required DateTimeOffset IssuedAt { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}