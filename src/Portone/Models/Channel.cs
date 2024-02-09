using Portone.Models.Abstractions;

namespace Portone.Models
{
    /// <summary>
    /// 채널 정보
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Channel
    {
        [Newtonsoft.Json.JsonProperty("channelId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string ChannelId { get; set; }

        [Newtonsoft.Json.JsonProperty("channelName", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string ChannelName { get; set; }

        [Newtonsoft.Json.JsonProperty("pgProvider", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public required PgProvider PgProvider { get; set; }

        [Newtonsoft.Json.JsonProperty("channelType", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public required ChannelType ChannelType { get; set; }

        [Newtonsoft.Json.JsonProperty("pgMerchantId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string PgMerchantId { get; set; }

        [Newtonsoft.Json.JsonProperty("isForPayment", Required = Newtonsoft.Json.Required.Always)]
        public bool IsForPayment { get; set; }

        [Newtonsoft.Json.JsonProperty("isForIdentityCertification", Required = Newtonsoft.Json.Required.Always)]
        public bool IsForIdentityCertification { get; set; }

        [Newtonsoft.Json.JsonProperty("channelKey", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string ChannelKey { get; set; }

        [Newtonsoft.Json.JsonProperty("pgCredential", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ChannelPgCredential PgCredential { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}