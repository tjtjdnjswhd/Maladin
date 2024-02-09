namespace Portone.Models
{
    /// <summary>
    /// 에스크로 배송 정보 등록 입력 정보
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class EscrowLogisticsRegisterBody
    {
        /// <summary>
        /// 접근 권한이 있는 상점 아이디만 입력 가능하며, 미입력시 토큰에 담긴 상점 아이디를 사용합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("storeId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StoreId { get; set; }

        [Newtonsoft.Json.JsonProperty("sender", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PaymentEscrowSenderInput Sender { get; set; }

        [Newtonsoft.Json.JsonProperty("receiver", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PaymentEscrowReceiverInput Receiver { get; set; }

        [Newtonsoft.Json.JsonProperty("logistics", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required PaymentLogistics Logistics { get; set; }

        /// <summary>
        /// 에스크로 구매 확정 시 이메일로 알림을 보낼지 여부입니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("sendEmail", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool SendEmail { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}