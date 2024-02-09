namespace Portone.Models
{
    /// <summary>
    /// 사업자 과세 유형
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum B2bCompanyStateTaxationType
    {
        [System.Runtime.Serialization.EnumMember(Value = @"ASSIGNED_ID_NUMBER")]
        ASSIGNED_ID_NUMBER = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"NORMAL")]
        NORMAL = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"SIMPLE")]
        SIMPLE = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"SIMPLE_TAX_INVOICE_ISSUER")]
        SIMPLE_TAX_INVOICE_ISSUER = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"TAX_FREE")]
        TAX_FREE = 4,
    }
}