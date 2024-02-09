namespace Portone.Models
{
    /// <summary>
    /// 플랫폼 계좌 상태
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum PlatformAccountStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = @"EXPIRED")]
        EXPIRED = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"UNKNOWN")]
        UNKNOWN = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"VERIFIED")]
        VERIFIED = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"VERIFYING")]
        VERIFYING = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"VERIFY_FAILED")]
        VERIFY_FAILED = 4,
    }
}