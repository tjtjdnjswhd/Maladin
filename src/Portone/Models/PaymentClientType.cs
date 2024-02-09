namespace Portone.Models
{
    /// <summary>
    /// 결제가 발생한 클라이언트 환경
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum PaymentClientType
    {
        [System.Runtime.Serialization.EnumMember(Value = @"API")]
        API = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"SDK_MOBILE")]
        SDK_MOBILE = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"SDK_PC")]
        SDK_PC = 2,
    }
}