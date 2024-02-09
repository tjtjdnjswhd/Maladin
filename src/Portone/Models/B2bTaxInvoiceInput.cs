namespace Portone.Models
{
    /// <summary>
    /// 세금계산서 생성 요청 정보
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class B2bTaxInvoiceInput
    {
        [Newtonsoft.Json.JsonProperty("taxType", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public required B2bTaxType TaxType { get; set; }

        [Newtonsoft.Json.JsonProperty("serialNum", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SerialNum { get; set; }

        [Newtonsoft.Json.JsonProperty("bookVolume", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int BookVolume { get; set; }

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
        [Newtonsoft.Json.JsonProperty("remarks", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ICollection<string> Remarks { get; set; }

        /// <summary>
        /// 영문 대소문자, 숫자, 특수문자('-','_')만 이용 가능
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("supplierDocumentKey", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SupplierDocumentKey { get; set; }

        [Newtonsoft.Json.JsonProperty("supplier", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required B2bTaxInvoiceCompany Supplier { get; set; }

        /// <summary>
        /// 영문 대소문자, 숫자, 특수문자('-','_')만 이용 가능
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("recipientDocumentKey", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RecipientDocumentKey { get; set; }

        [Newtonsoft.Json.JsonProperty("recipient", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required B2bTaxInvoiceCompany Recipient { get; set; }

        /// <summary>
        /// 공급자 담당자 휴대폰번호 {supplier.contact.mobile_phone_number} 값으로 문자 전송 전송시 포인트 차감되며, 실패시 환불 처리 기본값은 false
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("sendSms", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool SendSms { get; set; }

        [Newtonsoft.Json.JsonProperty("modification", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public B2bModification Modification { get; set; }

        /// <summary>
        /// 최대 99개
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("items", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ICollection<B2bTaxInvoiceItem> Items { get; set; }

        /// <summary>
        /// 최대 3개
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("contacts", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ICollection<B2bTaxInvoiceAdditionalContact> Contacts { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}