namespace Portone.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class CreatePlatformOrderCancelTransferBody
    {
        [Newtonsoft.Json.JsonProperty("partnerId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string PartnerId { get; set; }

        [Newtonsoft.Json.JsonProperty("paymentId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string PaymentId { get; set; }

        [Newtonsoft.Json.JsonProperty("cancellationId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string CancellationId { get; set; }

        [Newtonsoft.Json.JsonProperty("memo", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Memo { get; set; }

        [Newtonsoft.Json.JsonProperty("orderDetail", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CreatePlatformOrderCancelTransferBodyOrderDetail OrderDetail { get; set; }

        [Newtonsoft.Json.JsonProperty("discounts", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required ICollection<CreatePlatformOrderCancelTransferBodyDiscount> Discounts { get; set; }

        /// <summary>
        /// 날짜를 나타내는 문자열로, &lt;code&gt;yyyy-MM-dd&lt;/code&gt; 형식을 따릅니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("settlementStartDate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SettlementStartDate { get; set; }

        [Newtonsoft.Json.JsonProperty("externalCancellationDetail", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CreatePlatformOrderCancelTransferBodyExternalCancellationDetail ExternalCancellationDetail { get; set; }

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