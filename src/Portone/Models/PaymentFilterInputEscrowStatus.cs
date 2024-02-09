namespace Portone.Models
{
    /// <summary>
    /// 에스크로 상태
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum PaymentFilterInputEscrowStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = @"CANCELLED")]
        CANCELLED = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"CONFIRMED")]
        CONFIRMED = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"DELIVERED")]
        DELIVERED = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"REGISTERED")]
        REGISTERED = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"REJECTED")]
        REJECTED = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"REJECT_CONFIRMED")]
        REJECT_CONFIRMED = 5,
    }
}