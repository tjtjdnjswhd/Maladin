namespace Portone.Models
{
    /// <summary>
    /// 파트너 현황 조회 성공 응답
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PlatformPartnerDashboard
    {
        [Newtonsoft.Json.JsonProperty("totalCount", Required = Newtonsoft.Json.Required.Always)]
        public int TotalCount { get; set; }

        [Newtonsoft.Json.JsonProperty("upcomingSettledCount", Required = Newtonsoft.Json.Required.Always)]
        public int UpcomingSettledCount { get; set; }

        /// <summary>
        /// 정산이 예정되어 있지 않은 경우 값이 주어지지 않습니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("upcomingSettlementDate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UpcomingSettlementDate { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}