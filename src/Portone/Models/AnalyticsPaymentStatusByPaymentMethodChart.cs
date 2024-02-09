namespace Portone.Models
{
    /// <summary>
    /// 고객사의 결제 수단 별 결제 상태 차트 정보
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class AnalyticsPaymentStatusByPaymentMethodChart
    {
        [Newtonsoft.Json.JsonProperty("stats", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required ICollection<AnalyticsPaymentStatusByPaymentMethodChartStat> Stats { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}