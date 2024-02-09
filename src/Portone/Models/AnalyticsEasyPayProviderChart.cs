namespace Portone.Models
{
    /// <summary>
    /// 고객사의 간편결제사별 결제 현황 차트 정보
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class AnalyticsEasyPayProviderChart
    {
        [Newtonsoft.Json.JsonProperty("stats", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required ICollection<AnalyticsEasyPayProviderChartStat> Stats { get; set; }

        [Newtonsoft.Json.JsonProperty("remainderStats", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required ICollection<AnalyticsEasyPayProviderChartRemainderStat> RemainderStats { get; set; }

        [Newtonsoft.Json.JsonProperty("summary", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required AnalyticsEasyPayProviderChartSummary Summary { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}