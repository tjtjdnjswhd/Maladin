namespace Portone.Models
{
    /// <summary>
    /// 결제 예약 건 상태
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum PaymentScheduleStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = @"FAILED")]
        FAILED = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"REVOKED")]
        REVOKED = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"SCHEDULED")]
        SCHEDULED = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"STARTED")]
        STARTED = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"SUCCEEDED")]
        SUCCEEDED = 4,
    }
}