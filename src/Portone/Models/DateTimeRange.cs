namespace Portone.Models
{
    /// <summary>
    /// 시간 범위
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class DateTimeRange
    {
        [Newtonsoft.Json.JsonProperty("from", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required DateTimeOffset From { get; set; }

        [Newtonsoft.Json.JsonProperty("until", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required DateTimeOffset Until { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}