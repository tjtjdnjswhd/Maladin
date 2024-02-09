using Portone.Models.Abstractions;

namespace Portone.Models
{
    public class PlatformSettlementFormulaInvalidFunction : PlatformSettlementFormulaError
    {
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("position", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required PlatformSettlementFormulaPosition Position { get; set; }
    }
}