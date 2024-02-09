namespace Portone.Models
{
    /// <summary>
    /// 세금계산서 역발행 요청 취소 정보
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class CancelB2bTaxInvoiceRequestBody
    {
        [Newtonsoft.Json.JsonProperty("brn", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string Brn { get; set; }

        [Newtonsoft.Json.JsonProperty("documentKey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string DocumentKey { get; set; }

        /// <summary>
        /// 기본 값은 RECIPIENT이며 SUPPLIER, RECIPIENT을 지원합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("documentKeyType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public B2bTaxInvoiceDocumentKeyType DocumentKeyType { get; set; }

        [Newtonsoft.Json.JsonProperty("memo", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Memo { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}