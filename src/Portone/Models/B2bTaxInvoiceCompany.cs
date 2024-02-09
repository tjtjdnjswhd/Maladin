namespace Portone.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class B2bTaxInvoiceCompany
    {
        /// <summary>
        /// &lt;ul&gt;
        /// <br/>&lt;li&gt;를 제외한 10자리&lt;/li&gt;
        /// <br/>&lt;/ul&gt;
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("brn", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string Brn { get; set; }

        /// <summary>
        /// 4자리 고정
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("taxRegistrationId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TaxRegistrationId { get; set; }

        /// <summary>
        /// 최대 200자
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// 최대 100자
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("ceoName", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CeoName { get; set; }

        /// <summary>
        /// 최대 300자
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("address", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Address { get; set; }

        /// <summary>
        /// 최대 100자
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("businessType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BusinessType { get; set; }

        /// <summary>
        /// 최대 100자
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("businessClass", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BusinessClass { get; set; }

        [Newtonsoft.Json.JsonProperty("contact", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public B2bTaxInvoiceContact Contact { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}