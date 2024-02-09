namespace Portone.Models
{
    /// <summary>
    /// API key 로그인 성공 응답
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class LoginViaApiKeyResponse
    {
        /// <summary>
        /// 하루의 유효기간을 가지고 있습니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("accessToken", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string AccessToken { get; set; }

        /// <summary>
        /// 일주일의 유효기간을 가지고 있으며, 리프레시 토큰을 통해 유효기간이 연장된 새로운 엑세스 토큰을 발급받을 수 있습니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("refreshToken", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string RefreshToken { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}