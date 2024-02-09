namespace Portone.Models
{
    /// <summary>
    /// 플랫폼 정산 기준일
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum PlatformSettlementCycleDatePolicy
    {
        [System.Runtime.Serialization.EnumMember(Value = @"CALENDAR_DAY")]
        CALENDAR_DAY = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"HOLIDAY_AFTER")]
        HOLIDAY_AFTER = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"HOLIDAY_BEFORE")]
        HOLIDAY_BEFORE = 2,
    }
}