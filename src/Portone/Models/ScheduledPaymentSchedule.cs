using Portone.Models.Abstractions;

namespace Portone.Models
{
    /// <summary>
    /// 결제 예약 완료 상태
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class ScheduledPaymentSchedule : PaymentSchedule
    {
        [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string Status { get; set; }

        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("merchantId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string MerchantId { get; set; }

        [Newtonsoft.Json.JsonProperty("storeId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string StoreId { get; set; }

        [Newtonsoft.Json.JsonProperty("paymentId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string PaymentId { get; set; }

        [Newtonsoft.Json.JsonProperty("billingKey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string BillingKey { get; set; }

        [Newtonsoft.Json.JsonProperty("orderName", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string OrderName { get; set; }

        [Newtonsoft.Json.JsonProperty("isCulturalExpense", Required = Newtonsoft.Json.Required.Always)]
        public bool IsCulturalExpense { get; set; }

        [Newtonsoft.Json.JsonProperty("isEscrow", Required = Newtonsoft.Json.Required.Always)]
        public bool IsEscrow { get; set; }

        [Newtonsoft.Json.JsonProperty("customer", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required Customer Customer { get; set; }

        [Newtonsoft.Json.JsonProperty("customData", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string CustomData { get; set; }

        [Newtonsoft.Json.JsonProperty("totalAmount", Required = Newtonsoft.Json.Required.Always)]
        public long TotalAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("taxFreeAmount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long TaxFreeAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public required Currency Currency { get; set; }

        [Newtonsoft.Json.JsonProperty("installmentMonth", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int InstallmentMonth { get; set; }

        [Newtonsoft.Json.JsonProperty("noticeUrls", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ICollection<string> NoticeUrls { get; set; }

        [Newtonsoft.Json.JsonProperty("products", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ICollection<PaymentProduct> Products { get; set; }

        [Newtonsoft.Json.JsonProperty("timeToPay", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required DateTimeOffset TimeToPay { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}