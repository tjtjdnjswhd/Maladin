namespace Portone.Models
{
    /// <summary>
    /// 입금 만료 기한
    /// <br/>validHours와 dueDate 둘 중 하나의 필드만 입력합니다.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class InstantPaymentMethodInputVirtualAccountExpiry
    {
        /// <summary>
        /// 시간 단위로 입력합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("validHours", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int ValidHours { get; set; }

        [Newtonsoft.Json.JsonProperty("dueDate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateTimeOffset DueDate { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}