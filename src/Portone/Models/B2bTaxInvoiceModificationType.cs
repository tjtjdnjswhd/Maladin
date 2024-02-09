namespace Portone.Models
{
    /// <summary>
    /// 수정 사유
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum B2bTaxInvoiceModificationType
    {
        [System.Runtime.Serialization.EnumMember(Value = @"CANCELLATION_OF_CONTRACT")]
        CANCELLATION_OF_CONTRACT = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"CHANGE_IN_SUPPLY_COST")]
        CHANGE_IN_SUPPLY_COST = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"CORRECTION_OF_ENTRY_ERRORS")]
        CORRECTION_OF_ENTRY_ERRORS = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"DUPLICATE_ISSUANCE_DUE_TO_ERROR")]
        DUPLICATE_ISSUANCE_DUE_TO_ERROR = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"POST_ISSUANCE_LOCAL_LETTER_OF_CREDIT")]
        POST_ISSUANCE_LOCAL_LETTER_OF_CREDIT = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"RETURN")]
        RETURN = 5,
    }
}