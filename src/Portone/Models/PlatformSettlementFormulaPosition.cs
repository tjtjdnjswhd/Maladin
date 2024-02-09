namespace Portone.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PlatformSettlementFormulaPosition
    {
        [Newtonsoft.Json.JsonProperty("startLine", Required = Newtonsoft.Json.Required.Always)]
        public int StartLine { get; set; }

        [Newtonsoft.Json.JsonProperty("startIndex", Required = Newtonsoft.Json.Required.Always)]
        public int StartIndex { get; set; }

        [Newtonsoft.Json.JsonProperty("endLine", Required = Newtonsoft.Json.Required.Always)]
        public int EndLine { get; set; }

        [Newtonsoft.Json.JsonProperty("endIndex", Required = Newtonsoft.Json.Required.Always)]
        public int EndIndex { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}