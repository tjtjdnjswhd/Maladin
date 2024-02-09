namespace Portone.Models
{
    /// <summary>
    /// 특정 시점의 건별 평균 거래액, 고객 당 평균 거래액을 나타냅니다.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class AnalyticsAverageAmountChartStat
    {
        [Newtonsoft.Json.JsonProperty("timestamp", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required DateTimeOffset Timestamp { get; set; }

        [Newtonsoft.Json.JsonProperty("paymentAverageAmount", Required = Newtonsoft.Json.Required.Always)]
        public long PaymentAverageAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("customerAverageAmount", Required = Newtonsoft.Json.Required.Always)]
        public long CustomerAverageAmount { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}