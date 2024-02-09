namespace Portone.Models
{
    /// <summary>
    /// 금액 부담 주체
    /// <br/>플랫폼에서 발생한 결제 수수료, 부가세 등 금액을 부담하는 주체를 나타냅니다.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum PlatformPayer
    {
        [System.Runtime.Serialization.EnumMember(Value = @"MERCHANT")]
        MERCHANT = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"PARTNER")]
        PARTNER = 1,
    }
}