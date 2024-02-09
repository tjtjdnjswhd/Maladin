namespace Portone.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class B2bTaxInvoice
    {
        [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string Status { get; set; }

        [Newtonsoft.Json.JsonProperty("taxType", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public required B2bTaxType TaxType { get; set; }

        [Newtonsoft.Json.JsonProperty("serialNum", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SerialNum { get; set; }

        /// <summary>
        /// 입력 범위(4자리) : 0 ~ 9999
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("bookVolume", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int BookVolume { get; set; }

        /// <summary>
        /// 입력 범위(4자리) : 0 ~ 9999
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("bookIssue", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int BookIssue { get; set; }

        /// <summary>
        /// 날짜를 나타내는 문자열로, &lt;code&gt;yyyy-MM-dd&lt;/code&gt; 형식을 따릅니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("writeDate", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string WriteDate { get; set; }

        [Newtonsoft.Json.JsonProperty("purposeType", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public required B2bTaxInvoicePurposeType PurposeType { get; set; }

        [Newtonsoft.Json.JsonProperty("supplyCostTotalAmount", Required = Newtonsoft.Json.Required.Always)]
        public long SupplyCostTotalAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("taxTotalAmount", Required = Newtonsoft.Json.Required.Always)]
        public long TaxTotalAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("totalAmount", Required = Newtonsoft.Json.Required.Always)]
        public long TotalAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("cashAmount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long CashAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("checkAmount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long CheckAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("creditAmount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long CreditAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("noteAmount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long NoteAmount { get; set; }

        /// <summary>
        /// 최대 3개
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("remarks", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required ICollection<string> Remarks { get; set; }

        [Newtonsoft.Json.JsonProperty("supplierDocumentKey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string SupplierDocumentKey { get; set; }

        [Newtonsoft.Json.JsonProperty("supplier", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required B2bTaxInvoiceCompany Supplier { get; set; }

        [Newtonsoft.Json.JsonProperty("recipientDocumentKey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string RecipientDocumentKey { get; set; }

        [Newtonsoft.Json.JsonProperty("recipient", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required B2bTaxInvoiceCompany Recipient { get; set; }

        [Newtonsoft.Json.JsonProperty("sendSms", Required = Newtonsoft.Json.Required.Always)]
        public bool SendSms { get; set; }

        [Newtonsoft.Json.JsonProperty("modification", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public B2bModification Modification { get; set; }

        /// <summary>
        /// 최대 99개
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("items", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required ICollection<B2bTaxInvoiceItem> Items { get; set; }

        /// <summary>
        /// 최대 3개
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("contacts", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required ICollection<B2bTaxInvoiceAdditionalContact> Contacts { get; set; }

        [Newtonsoft.Json.JsonProperty("statusUpdatedAt", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required DateTimeOffset StatusUpdatedAt { get; set; }

        [Newtonsoft.Json.JsonProperty("issuedAt", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required DateTimeOffset IssuedAt { get; set; }

        /// <summary>
        /// 세금계산서 발행(전자서명) 시점에 자동으로 부여
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("ntsApproveNumber", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string NtsApproveNumber { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}