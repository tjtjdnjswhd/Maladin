namespace Portone.Models
{
    /// <summary>
    /// 파트너 현황 조회를 위한 입력 정보
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class GetPlatformPartnerDashboardBody
    {
        /// <summary>
        /// true 이면 숨김 처리된 파트너까지 조회하고, false 이면 숨김 처리되지 않은 파트너만 조회합니다. 아무 값도 넘기지 않을 경우 기본값은 false 입니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("includeHidden", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeHidden { get; set; }

        /// <summary>
        /// true 이면 보관된 파트너를 조회하고, false 이면 보관되지 않은 파트너를 조회합니다. 아무 값도 넘기지 않을 경우 기본값은 false 입니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("isArchived", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsArchived { get; set; }

        /// <summary>
        /// true 이면 isForTest 가 true 인 파트너들을 조회하고, false 이면 isForTest 가 false 인 파트너들을 조회합니다. 아무 값도 넘기지 않을 경우 기본값은 false 입니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("isForTest", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsForTest { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}