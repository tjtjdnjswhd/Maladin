using Portone.Models.Abstractions;

namespace Portone.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PlatformManualTransferSummary : PlatformTransferSummary
    {
        [Newtonsoft.Json.JsonProperty("settlementAmount", Required = Newtonsoft.Json.Required.Always)]
        public long SettlementAmount { get; set; }
    }
}