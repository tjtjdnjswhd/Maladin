using Portone.Models.Abstractions;

namespace Portone.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PlatformOrderCancelTransferSummary : PlatformTransferSummary
    {
        [Newtonsoft.Json.JsonProperty("storeId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string StoreId { get; set; }

        [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required PlatformOrderSettlementAmount Amount { get; set; }

        [Newtonsoft.Json.JsonProperty("payment", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required PlatformTransferSummaryPayment Payment { get; set; }
    }
}