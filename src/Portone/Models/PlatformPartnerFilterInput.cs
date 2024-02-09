namespace Portone.Models
{
    /// <summary>
    /// 파트너 필터 입력 정보
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PlatformPartnerFilterInput
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
        /// 하나 이상의 값이 존재하는 경우 해당 리스트에 포함되는 태그를 하나 이상 가지는 파트너만 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("tags", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ICollection<string> Tags { get; set; }

        /// <summary>
        /// 하나 이상의 값이 존재하는 경우,  해당 리스트에 포함되는 계좌 은행을 가진 파트너만 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("banks", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore, ItemConverterType = typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ICollection<Bank> Banks { get; set; }

        /// <summary>
        /// 하나 이상의 값이 존재하는 경우,  해당 리스트에 포함되는 계좌 통화를 가진 파트너만 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("accountCurrencies", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore, ItemConverterType = typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ICollection<Currency> AccountCurrencies { get; set; }

        /// <summary>
        /// 하나 이상의 값이 존재하는 경우,  해당 리스트에 포함되는 아이디를 가진 파트너만 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("ids", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ICollection<string> Ids { get; set; }

        [Newtonsoft.Json.JsonProperty("keyword", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlatformPartnerFilterInputKeyword Keyword { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}