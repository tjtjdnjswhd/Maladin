namespace Portone.Models
{
    /// <summary>
    /// 할인 분담 정책 다건 조회를 위한 필터 조건
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PlatformDiscountSharePolicyFilterInput
    {
        /// <summary>
        /// true 이면 숨김 처리된 할인 분담 정책까지 조회하고, false 이면 숨김 처리되지 않은 할인 분담 정책만 조회합니다. 아무 값도 넘기지 않을 경우 기본값은 false 입니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("includeHidden", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeHidden { get; set; }

        /// <summary>
        /// true 이면 보관된 할인 분담 정책을 조회하고, false 이면 보관되지 않은 할인 분담 정책을 조회합니다. 아무 값도 넘기지 않을 경우 기본값은 false 입니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("isArchived", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsArchived { get; set; }

        /// <summary>
        /// 하나 이상의 값이 존재하는 경우 해당 리스트에 포함되는 파트너 분담율을 가진 할인 분담 정책만 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("partnerShareRates", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ICollection<int> PartnerShareRates { get; set; }

        /// <summary>
        /// 하나 이상의 값이 존재하는 경우, 해당 리스트에 포함되는 아이디를 가진 할인 분담 정책만 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("ids", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ICollection<string> Ids { get; set; }

        [Newtonsoft.Json.JsonProperty("keyword", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlatformDiscountSharePolicyFilterInputKeyword Keyword { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}