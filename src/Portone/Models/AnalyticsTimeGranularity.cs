namespace Portone.Models
{
    /// <summary>
    /// 조회 시간 단위
    /// <br/>하나의 단위 필드만 선택하여 입력합니다.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class AnalyticsTimeGranularity
    {
        [Newtonsoft.Json.JsonProperty("minute", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public AnalyticsTimeGranularityMinute Minute { get; set; }

        [Newtonsoft.Json.JsonProperty("hour", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public AnalyticsTimeGranularityHour Hour { get; set; }

        [Newtonsoft.Json.JsonProperty("day", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public AnalyticsTimeGranularityDay Day { get; set; }

        [Newtonsoft.Json.JsonProperty("week", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public AnalyticsTimeGranularityWeek Week { get; set; }

        [Newtonsoft.Json.JsonProperty("month", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public AnalyticsTimeGranularityMonth Month { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}