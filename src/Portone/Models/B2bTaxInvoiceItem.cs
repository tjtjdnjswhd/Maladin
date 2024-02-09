namespace Portone.Models
{
    /// <summary>
    /// 품목
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class B2bTaxInvoiceItem
    {
        /// <summary>
        /// 날짜를 나타내는 문자열로, &lt;code&gt;yyyy-MM-dd&lt;/code&gt; 형식을 따릅니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("purchaseDate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PurchaseDate { get; set; }

        /// <summary>
        /// 최대 100자
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// 최대 100자
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("spec", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Spec { get; set; }

        /// <summary>
        /// 입력 범위 : -99999999.99 ~ 999999999.99, 10^-quantityScale 단위로 치환됨
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("quantity", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long Quantity { get; set; }

        /// <summary>
        /// 입력 범위 : 0 ~ 2, 기본값: 0
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("quantityScale", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int QuantityScale { get; set; }

        /// <summary>
        /// 입력 범위 : -99999999999999.99 ~ 999999999999999.99
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("unitCostAmount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long UnitCostAmount { get; set; }

        /// <summary>
        /// 입력 범위 : 0 ~ 2, 기본값: 0
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("unitCostAmountScale", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int UnitCostAmountScale { get; set; }

        [Newtonsoft.Json.JsonProperty("supplyCostAmount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long SupplyCostAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("taxAmount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long TaxAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("remark", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Remark { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}