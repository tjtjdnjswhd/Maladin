namespace Portone.Models
{
    /// <summary>
    /// 결제 건 정렬 기준
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum PaymentSortBy
    {
        [System.Runtime.Serialization.EnumMember(Value = @"REQUESTED_AT")]
        REQUESTED_AT = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"STATUS_CHANGED_AT")]
        STATUS_CHANGED_AT = 1,
    }
}