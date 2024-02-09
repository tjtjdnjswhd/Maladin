namespace Portone.Models
{
    /// <summary>
    /// 가맹점의 결제수단 트렌드 조회를 위한 입력 정보
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class GetAnalyticsPaymentMethodTrendChartBody
    {
        [Newtonsoft.Json.JsonProperty("from", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required DateTimeOffset From { get; set; }

        [Newtonsoft.Json.JsonProperty("until", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required DateTimeOffset Until { get; set; }

        /// <summary>
        /// 입력된 통화로 발생한 결제내역만 응답에 포함됩니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public required Currency Currency { get; set; }

        /// <summary>
        /// true 이면 결제취소내역은 응답에 포함 및 반영되지 않습니다. false 또는 값을 명시하지 않은 경우 결제취소내역이 응답에 반영됩니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("excludeCancelled", Required = Newtonsoft.Json.Required.Always)]
        public bool ExcludeCancelled { get; set; }

        /// <summary>
        /// 시간별, 월별 단위만 지원됩니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("timeGranularity", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required AnalyticsTimeGranularity TimeGranularity { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}