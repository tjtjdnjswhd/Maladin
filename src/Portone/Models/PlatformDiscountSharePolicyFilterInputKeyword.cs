namespace Portone.Models
{
    /// <summary>
    /// 검색 키워드 입력 정보
    /// <br/>검색 키워드 적용을 위한 옵션으로, 명시된 키워드를 포함하는 할인 분담 정책만 조회합니다. 하위 필드는 명시된 값 중 한 가지만 적용됩니다.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PlatformDiscountSharePolicyFilterInputKeyword
    {
        /// <summary>
        /// 해당 값이 포함된 id 를 가진 할인 분담 정책만 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// 해당 값이 포함된 메모를 가진 할인 분담 정책만 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("memo", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Memo { get; set; }

        /// <summary>
        /// 해당 키워드가 포함된 정보를 가진 할인 분담 정책만 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("all", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string All { get; set; }

        /// <summary>
        /// 해당 값이 포함된 name 을 가진 할인 분담만 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}