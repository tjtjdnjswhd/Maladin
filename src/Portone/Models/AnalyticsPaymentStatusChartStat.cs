namespace Portone.Models
{
    /// <summary>
    /// 각 상태의 건수와 금액, 사분위수를 나타냅니다.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class AnalyticsPaymentStatusChartStat
    {
        [Newtonsoft.Json.JsonProperty("paymentStatus", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public required PaymentStatus PaymentStatus { get; set; }

        [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
        public long Amount { get; set; }

        [Newtonsoft.Json.JsonProperty("count", Required = Newtonsoft.Json.Required.Always)]
        public long Count { get; set; }

        [Newtonsoft.Json.JsonProperty("averageRatio", Required = Newtonsoft.Json.Required.Always)]
        public long AverageRatio { get; set; }

        [Newtonsoft.Json.JsonProperty("firstQuantile", Required = Newtonsoft.Json.Required.Always)]
        public long FirstQuantile { get; set; }

        [Newtonsoft.Json.JsonProperty("median", Required = Newtonsoft.Json.Required.Always)]
        public long Median { get; set; }

        [Newtonsoft.Json.JsonProperty("thirdQuantile", Required = Newtonsoft.Json.Required.Always)]
        public long ThirdQuantile { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}