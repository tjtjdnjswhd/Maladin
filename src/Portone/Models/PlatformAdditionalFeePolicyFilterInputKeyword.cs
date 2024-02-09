namespace Portone.Models
{
    /// <summary>
    /// 검색 키워드 입력 정보
    /// <br/>검색 키워드 적용을 위한 옵션으로, 명시된 키워드를 포함하는 추가 수수료 정책만 조회합니다. 하위 필드는 명시된 값 중 한 가지만 적용됩니다.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PlatformAdditionalFeePolicyFilterInputKeyword
    {
        /// <summary>
        /// 해당 값이 포함된 name 을 가진 추가 수수료 정책만 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// 해당 값이 포함된 id 를 가진 추가 수수료 정책만 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// 해당 값과 같은 수수료 를 가진 추가 수수료 정책만 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("fee", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Fee { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}