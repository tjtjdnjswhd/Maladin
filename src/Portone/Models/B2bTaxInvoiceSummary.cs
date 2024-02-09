namespace Portone.Models
{
    /// <summary>
    /// 세금계산서 요약
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class B2bTaxInvoiceSummary
    {
        [Newtonsoft.Json.JsonProperty("taxType", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public required B2bTaxType TaxType { get; set; }

        [Newtonsoft.Json.JsonProperty("supplyCostTotalAmount", Required = Newtonsoft.Json.Required.Always)]
        public long SupplyCostTotalAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("taxTotalAmount", Required = Newtonsoft.Json.Required.Always)]
        public long TaxTotalAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("purposeType", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public required B2bTaxInvoicePurposeType PurposeType { get; set; }

        [Newtonsoft.Json.JsonProperty("supplierBrn", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string SupplierBrn { get; set; }

        [Newtonsoft.Json.JsonProperty("supplierName", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string SupplierName { get; set; }

        [Newtonsoft.Json.JsonProperty("supplierDocumentKey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string SupplierDocumentKey { get; set; }

        [Newtonsoft.Json.JsonProperty("recipientBrn", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string RecipientBrn { get; set; }

        [Newtonsoft.Json.JsonProperty("recipientName", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string RecipientName { get; set; }

        [Newtonsoft.Json.JsonProperty("recipientDocumentKey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string RecipientDocumentKey { get; set; }

        [Newtonsoft.Json.JsonProperty("recipientBusinessStatus", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public B2bCompanyStateBusinessStatus RecipientBusinessStatus { get; set; }

        /// <summary>
        /// 상태가 CLOSED, SUSPENDED 상태인 경우에만 결과값 반환
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("recipientClosedSuspendedDate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RecipientClosedSuspendedDate { get; set; }

        [Newtonsoft.Json.JsonProperty("issuedAt", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateTimeOffset IssuedAt { get; set; }

        [Newtonsoft.Json.JsonProperty("openedAt", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateTimeOffset OpenedAt { get; set; }

        [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public required B2bTaxInvoiceStatus Status { get; set; }

        [Newtonsoft.Json.JsonProperty("statusUpdatedAt", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required DateTimeOffset StatusUpdatedAt { get; set; }

        /// <summary>
        /// 세금계산서 발행(전자서명) 시점에 자동으로 부여
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("ntsApproveNumber", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NtsApproveNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("ntsResult", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NtsResult { get; set; }

        [Newtonsoft.Json.JsonProperty("ntsSentAt", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateTimeOffset NtsSentAt { get; set; }

        [Newtonsoft.Json.JsonProperty("ntsResultReceivedAt", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateTimeOffset NtsResultReceivedAt { get; set; }

        /// <summary>
        /// 국세청 발급 결과 코드로 영문 3자리 + 숫자 3자리로 구성됨
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("ntsResultCode", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NtsResultCode { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}