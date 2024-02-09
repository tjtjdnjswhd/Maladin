using Portone.Models.Abstractions;

namespace Portone.Models
{
    /// <summary>
    /// 에스크로 정보
    /// <br/>V1 결제 건의 경우 타입이 REGISTERED 로 고정됩니다.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class BeforeRegisteredPaymentEscrow : PaymentEscrow
    {
        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}