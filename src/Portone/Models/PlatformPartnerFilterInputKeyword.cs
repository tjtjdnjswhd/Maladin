namespace Portone.Models
{
    /// <summary>
    /// 파트너 검색 키워드 입력 정보
    /// <br/>검색 키워드 적용을 위한 옵션으로, 명시된 키워드를 포함하는 파트너만 조회합니다. 하나의 하위 필드에만 값을 명시하여 요청합니다.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PlatformPartnerFilterInputKeyword
    {
        /// <summary>
        /// 해당 값이 포함된 id 를 가진 파트너만 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// 해당 값이 포함된 이름 을 가진 파트너만 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// 해당 값이 포함된 이메일 주소를 가진 파트너만 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("email", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Email { get; set; }

        /// <summary>
        /// 해당 값이 포함된 사업자등록번호를 가진 파트너만 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("businessRegistrationNumber", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BusinessRegistrationNumber { get; set; }

        /// <summary>
        /// 해당 값이 포함된 기본 계약 아이디를 가진 파트너만 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("defaultContractId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DefaultContractId { get; set; }

        /// <summary>
        /// 해당 값이 포함된 메모를 가진 파트너만 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("memo", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Memo { get; set; }

        /// <summary>
        /// 해당 값이 포함된 계좌번호를 가진 파트너만 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("accountNumber", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AccountNumber { get; set; }

        /// <summary>
        /// 해당 값이 포함된 계좌 예금주명을 가진 파트너만 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("accountHolder", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AccountHolder { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}