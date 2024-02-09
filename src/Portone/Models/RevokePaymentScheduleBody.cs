namespace Portone.Models
{
    /// <summary>
    /// 결제 예약 건 취소 요청 입력 정보
    /// <br/>&lt;p&gt;billingKey, scheduleIds 중 하나 이상은 필수로 입력합니다.
    /// <br/>billingKey 만 입력된 경우 -&amp;gt; 해당 빌링키로 예약된 모든 결제 예약 건들이 취소됩니다.
    /// <br/>scheduleIds 만 입력된 경우 -&amp;gt; 입력된 결제 예약 건 아이디에 해당하는 예약 건들이 취소됩니다.
    /// <br/>billingKey, scheduleIds 모두 입력된 경우 -&amp;gt; 입력된 결제 예약 건 아이디에 해당하는 예약 건들이 취소됩니다. 그리고 예약한 빌링키가 입력된 빌링키와 일치하는지 검증합니다.
    /// <br/>위 정책에 따라 선택된 결제 예약 건들 중 하나라도 취소에 실패할 경우, 모든 취소 요청이 실패합니다.&lt;/p&gt;
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class RevokePaymentScheduleBody
    {
        /// <summary>
        /// 접근 권한이 있는 상점 아이디만 입력 가능하며, 미입력시 토큰에 담긴 상점 아이디를 사용합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("storeId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StoreId { get; set; }

        [Newtonsoft.Json.JsonProperty("billingKey", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BillingKey { get; set; }

        [Newtonsoft.Json.JsonProperty("scheduleIds", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ICollection<string> ScheduleIds { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}