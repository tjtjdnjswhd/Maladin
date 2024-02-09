namespace Portone.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public enum B2bTaxInvoiceStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = @"BEFORE_SENDING")]
        BEFORE_SENDING = 0,

        [System.Runtime.Serialization.EnumMember(Value = @"ISSUANCE_CANCELLED_BY_SUPPLIER")]
        ISSUANCE_CANCELLED_BY_SUPPLIER = 1,

        [System.Runtime.Serialization.EnumMember(Value = @"ISSUED")]
        ISSUED = 2,

        [System.Runtime.Serialization.EnumMember(Value = @"REGISTERED")]
        REGISTERED = 3,

        [System.Runtime.Serialization.EnumMember(Value = @"REQUESTED")]
        REQUESTED = 4,

        [System.Runtime.Serialization.EnumMember(Value = @"REQUEST_CANCELLED_BY_RECIPIENT")]
        REQUEST_CANCELLED_BY_RECIPIENT = 5,

        [System.Runtime.Serialization.EnumMember(Value = @"REQUEST_REFUSED")]
        REQUEST_REFUSED = 6,

        [System.Runtime.Serialization.EnumMember(Value = @"SENDING")]
        SENDING = 7,

        [System.Runtime.Serialization.EnumMember(Value = @"SENDING_COMPLETED")]
        SENDING_COMPLETED = 8,

        [System.Runtime.Serialization.EnumMember(Value = @"SENDING_FAILED")]
        SENDING_FAILED = 9,

        [System.Runtime.Serialization.EnumMember(Value = @"WAITING_SENDING")]
        WAITING_SENDING = 10,
    }
}