namespace Portone.Models
{
    /// <summary>
    /// 카드 인증 관련 정보
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class CardCredential
    {
        [Newtonsoft.Json.JsonProperty("number", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string Number { get; set; }

        [Newtonsoft.Json.JsonProperty("expiryYear", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string ExpiryYear { get; set; }

        [Newtonsoft.Json.JsonProperty("expiryMonth", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string ExpiryMonth { get; set; }

        [Newtonsoft.Json.JsonProperty("birthOrBusinessRegistrationNumber", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BirthOrBusinessRegistrationNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("passwordTwoDigits", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PasswordTwoDigits { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}