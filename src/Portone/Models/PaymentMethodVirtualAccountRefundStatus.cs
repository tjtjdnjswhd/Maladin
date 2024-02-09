namespace Portone.Models
{
    /// <summary>
    /// 가상계좌 환불 상태
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum PaymentMethodVirtualAccountRefundStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = @"COMPLETED")]
        COMPLETED = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"FAILED")]
        FAILED = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"PARTIAL_REFUND_FAILED")]
        PARTIAL_REFUND_FAILED = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"PENDING")]
        PENDING = 3,
    }
}