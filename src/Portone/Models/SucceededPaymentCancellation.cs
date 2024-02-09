using Portone.Models.Abstractions;

namespace Portone.Models
{
    /// <summary>
    /// 취소 완료 상태
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class SucceededPaymentCancellation : PaymentCancellation
    {
        [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string Status { get; set; }

        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("pgCancellationId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PgCancellationId { get; set; }

        [Newtonsoft.Json.JsonProperty("totalAmount", Required = Newtonsoft.Json.Required.Always)]
        public long TotalAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("taxFreeAmount", Required = Newtonsoft.Json.Required.Always)]
        public long TaxFreeAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("vatAmount", Required = Newtonsoft.Json.Required.Always)]
        public long VatAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("easyPayDiscountAmount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long EasyPayDiscountAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("reason", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string Reason { get; set; }

        [Newtonsoft.Json.JsonProperty("cancelledAt", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateTimeOffset CancelledAt { get; set; }

        [Newtonsoft.Json.JsonProperty("requestedAt", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required DateTimeOffset RequestedAt { get; set; }

        [Newtonsoft.Json.JsonProperty("receiptUrl", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ReceiptUrl { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}