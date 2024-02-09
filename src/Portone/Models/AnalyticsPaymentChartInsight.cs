namespace Portone.Models
{
    /// <summary>
    /// 고객사의 결제 현황 인사이트 정보
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class AnalyticsPaymentChartInsight
    {
        [Newtonsoft.Json.JsonProperty("highestDateInMonth", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long HighestDateInMonth { get; set; }

        [Newtonsoft.Json.JsonProperty("lowestDateInMonth", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long LowestDateInMonth { get; set; }

        [Newtonsoft.Json.JsonProperty("highestDayInWeek", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public DayOfWeek HighestDayInWeek { get; set; }

        [Newtonsoft.Json.JsonProperty("lowestDayInWeek", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public DayOfWeek LowestDayInWeek { get; set; }

        [Newtonsoft.Json.JsonProperty("highestHourInDay", Required = Newtonsoft.Json.Required.Always)]
        public long HighestHourInDay { get; set; }

        [Newtonsoft.Json.JsonProperty("lowestHourInDay", Required = Newtonsoft.Json.Required.Always)]
        public long LowestHourInDay { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}