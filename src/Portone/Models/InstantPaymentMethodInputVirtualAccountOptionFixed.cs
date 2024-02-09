namespace Portone.Models
{
    /// <summary>
    /// 고정식 가상계좌 발급 유형
    /// <br/>pgAccountId, accountNumber 유형 중 한 개의 필드만 입력합니다.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class InstantPaymentMethodInputVirtualAccountOptionFixed
    {
        /// <summary>
        /// &lt;p&gt;가맹점이 가상계좌번호를 직접 관리하지 않고 PG사가 pgAccountId에 매핑되는 가상계좌번호를 내려주는 방식입니다.
        /// <br/>동일한 pgAccountId로 가상계좌 발급 요청시에는 항상 같은 가상계좌번호가 내려옵니다.&lt;/p&gt;
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("pgAccountId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PgAccountId { get; set; }

        /// <summary>
        /// PG사가 일정 개수만큼의 가상계좌번호를 발급하여 가맹점에게 미리 전달하고 가맹점이 그 중 하나를 선택하여 사용하는 방식입니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("accountNumber", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AccountNumber { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}