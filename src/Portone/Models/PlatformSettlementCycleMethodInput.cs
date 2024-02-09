namespace Portone.Models
{
    /// <summary>
    /// 플랫폼 정산 주기 계산 방식 입력 정보
    /// <br/>하나의 하위 필드에만 값을 명시하여 요청합니다.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PlatformSettlementCycleMethodInput
    {
        [Newtonsoft.Json.JsonProperty("daily", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlatformSettlementCycleMethodDailyInput Daily { get; set; }

        [Newtonsoft.Json.JsonProperty("weekly", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlatformSettlementCycleMethodWeeklyInput Weekly { get; set; }

        [Newtonsoft.Json.JsonProperty("monthly", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlatformSettlementCycleMethodMonthlyInput Monthly { get; set; }

        [Newtonsoft.Json.JsonProperty("manualDates", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlatformSettlementCycleMethodManualDatesInput ManualDates { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}