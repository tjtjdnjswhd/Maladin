namespace Portone.Models
{
    /// <summary>
    /// 계약 다건 조회를 위한 필터 조건
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PlatformContractFilterInput
    {
        /// <summary>
        /// 하나 이상의 값이 존재하는 경우 해당 리스트에 포함되는 중개 수수료를 가진 계약만 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("platformFees", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ICollection<PlatformFeeInput> PlatformFees { get; set; }

        /// <summary>
        /// 하나 이상의 값이 존재하는 경우 해당 리스트에 포함되는 수수료 부담 주체를 가진 계약만 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("platformFeePayers", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore, ItemConverterType = typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ICollection<PlatformPayer> PlatformFeePayers { get; set; }

        /// <summary>
        /// 하나 이상의 값이 존재하는 경우 해당 리스트에 포함되는 정산 주기 계산 방식을 가진 계약만 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("cycleTypes", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore, ItemConverterType = typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ICollection<PlatformSettlementCycleType> CycleTypes { get; set; }

        /// <summary>
        /// 하나 이상의 값이 존재하는 경우 해당 리스트에 포함되는 정산 기준일을 가진 계약만 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("datePolicies", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore, ItemConverterType = typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ICollection<PlatformSettlementCycleDatePolicy> DatePolicies { get; set; }

        /// <summary>
        /// true 이면 숨김 처리된 계약까지 조회하고, false 이면 숨김 처리되지 않은 계약만 조회합니다. 아무 값도 넘기지 않을 경우 기본값은 false 입니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("includeHidden", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeHidden { get; set; }

        /// <summary>
        /// true 이면 보관된 계약을 조회하고, false 이면 보관되지 않은 계약을 조회합니다. 아무 값도 넘기지 않을 경우 기본값은 false 입니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("isArchived", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsArchived { get; set; }

        [Newtonsoft.Json.JsonProperty("keyword", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlatformContractFilterInputKeyword Keyword { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}