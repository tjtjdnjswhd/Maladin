namespace Portone.Models
{
    /// <summary>
    /// 웹훅 전송 상태
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum PaymentWebhookStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = @"FAILED_NOT_OK_RESPONSE")]
        FAILED_NOT_OK_RESPONSE = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"FAILED_UNEXPECTED_ERROR")]
        FAILED_UNEXPECTED_ERROR = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"SUCCEEDED")]
        SUCCEEDED = 2,
    }
}