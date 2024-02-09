namespace Portone.Models
{
    /// <summary>
    /// 고객사의 결제수단 트렌드 차트 정보
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class AnalyticsPaymentMethodTrendChart
    {
        /// <summary>
        /// (timestamp, paymentMethod) 를 기준으로 오름차순 정렬되어 주어집니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("stats", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required ICollection<AnalyticsPaymentMethodTrendChartStat> Stats { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}