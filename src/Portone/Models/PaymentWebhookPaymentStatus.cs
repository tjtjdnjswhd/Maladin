namespace Portone.Models
{
    /// <summary>
    /// 웹훅 발송 시 결제 건 상태
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum PaymentWebhookPaymentStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = @"CANCELLED")]
        CANCELLED = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"FAILED")]
        FAILED = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"PAID")]
        PAID = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"PARTIAL_CANCELLED")]
        PARTIAL_CANCELLED = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"READY")]
        READY = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"VIRTUAL_ACCOUNT_ISSUED")]
        VIRTUAL_ACCOUNT_ISSUED = 5,
    }
}