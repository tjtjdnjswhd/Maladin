namespace Portone.Models
{
    /// <summary>
    /// 추가 수수료 정책 다건 조회를 위한 필터 조건
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PlatformAdditionalFeePolicyFilterInput
    {
        /// <summary>
        /// true 이면 숨김 처리된 추가 수수료 정책까지 조회하고, false 이면 숨김 처리되지 않은 추가 수수료 정책만 조회합니다. 아무 값도 넘기지 않을 경우 기본값은 false 입니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("includeHidden", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeHidden { get; set; }

        /// <summary>
        /// true 이면 보관된 추가 수수료 정책의 필터 옵션을 조회하고, false 이면 보관되지 않은 추가 수수료 정책의 필터 옵션을 조회합니다. 아무 값도 넘기지 않을 경우 기본값은 false 입니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("isArchived", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsArchived { get; set; }

        [Newtonsoft.Json.JsonProperty("ids", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ICollection<string> Ids { get; set; }

        /// <summary>
        /// 하나 이상의 값이 존재하는 경우 해당 리스트에 포함되는 부가세 부담 주체에 해당하는 추가 수수료 정책만 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("vatPayers", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore, ItemConverterType = typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ICollection<PlatformPayer> VatPayers { get; set; }

        [Newtonsoft.Json.JsonProperty("keyword", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlatformAdditionalFeePolicyFilterInputKeyword Keyword { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}