namespace Portone.Models
{
    /// <summary>
    /// 에스크로 구매 확정 입력 정보
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class ConfirmEscrowBody
    {
        /// <summary>
        /// 접근 권한이 있는 상점 아이디만 입력 가능하며, 미입력시 토큰에 담긴 상점 아이디를 사용합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("storeId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StoreId { get; set; }

        /// <summary>
        /// &lt;p&gt;구매확정요청 주체가 가맹점 관리자인지 구매자인지 구분하기 위한 필드입니다.
        /// <br/>네이버페이 전용 파라미터이며, 구분이 모호한 경우 가맹점 관리자(true)로 입력합니다.&lt;/p&gt;
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("fromStore", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool FromStore { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}