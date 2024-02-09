namespace Portone.Models
{
    /// <summary>
    /// 세금계산서가 삭제 가능한 상태가 아닌 경우
    /// <br/>삭제 가능한 상태는 &lt;code&gt;REGISTERED&lt;/code&gt;, &lt;code&gt;ISSUE_REFUSED&lt;/code&gt;, &lt;code&gt;REQUEST_CANCELLED_BY_RECIPIENT&lt;/code&gt;, &lt;code&gt;ISSUE_CANCELLED_BY_SUPPLIER&lt;/code&gt;, &lt;code&gt;SENDING_FAILED&lt;/code&gt; 입니다.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class B2bTaxInvoiceNonDeletableStatusError
    {
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Message { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}