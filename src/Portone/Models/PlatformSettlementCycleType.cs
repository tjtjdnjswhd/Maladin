namespace Portone.Models
{
    /// <summary>
    /// 플랫폼 정산 주기 계산 방식
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum PlatformSettlementCycleType
    {
        [System.Runtime.Serialization.EnumMember(Value = @"DAILY")]
        DAILY = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"MANUAL_DATES")]
        MANUAL_DATES = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"MONTHLY")]
        MONTHLY = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"WEEKLY")]
        WEEKLY = 3,
    }
}