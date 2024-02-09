namespace Portone.Models
{
    /// <summary>
    /// 플랫폼 업데이트를 위한 입력 정보
    /// <br/>값이 명시되지 않은 필드는 업데이트하지 않습니다.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class UpdatePlatformBody
    {
        [Newtonsoft.Json.JsonProperty("roundType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PlatformRoundType RoundType { get; set; }

        [Newtonsoft.Json.JsonProperty("settlementFormula", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public UpdatePlatformBodySettlementFormula SettlementFormula { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}