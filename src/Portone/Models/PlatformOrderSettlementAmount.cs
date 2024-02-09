namespace Portone.Models
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PlatformOrderSettlementAmount
    {
        [Newtonsoft.Json.JsonProperty("settlement", Required = Newtonsoft.Json.Required.Always)]
        public long Settlement { get; set; }

        [Newtonsoft.Json.JsonProperty("payment", Required = Newtonsoft.Json.Required.Always)]
        public long Payment { get; set; }

        [Newtonsoft.Json.JsonProperty("order", Required = Newtonsoft.Json.Required.Always)]
        public long Order { get; set; }

        [Newtonsoft.Json.JsonProperty("platformFee", Required = Newtonsoft.Json.Required.Always)]
        public long PlatformFee { get; set; }

        [Newtonsoft.Json.JsonProperty("platformFeeVat", Required = Newtonsoft.Json.Required.Always)]
        public long PlatformFeeVat { get; set; }

        [Newtonsoft.Json.JsonProperty("additionalFee", Required = Newtonsoft.Json.Required.Always)]
        public long AdditionalFee { get; set; }

        [Newtonsoft.Json.JsonProperty("additionalFeeVat", Required = Newtonsoft.Json.Required.Always)]
        public long AdditionalFeeVat { get; set; }

        [Newtonsoft.Json.JsonProperty("discount", Required = Newtonsoft.Json.Required.Always)]
        public long Discount { get; set; }

        [Newtonsoft.Json.JsonProperty("discountShare", Required = Newtonsoft.Json.Required.Always)]
        public long DiscountShare { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}