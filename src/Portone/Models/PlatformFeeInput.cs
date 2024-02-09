namespace Portone.Models
{
    /// <summary>
    /// 수수료 계산 방식을 특정하기 위한 입력 정보
    /// <br/>&lt;p&gt;정률 수수료를 설정하고 싶은 경우 &lt;code&gt;fixedRate&lt;/code&gt; 필드에, 정액 수수료를 설정하고 싶은 경우 &lt;code&gt;fixedAmount&lt;/code&gt; 필드에 값을 명시해 요청합니다.
    /// <br/>두 필드 모두 값이 들어있지 않은 경우 요청이 거절됩니다.&lt;/p&gt;
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PlatformFeeInput
    {
        [Newtonsoft.Json.JsonProperty("fixedRate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int FixedRate { get; set; }

        [Newtonsoft.Json.JsonProperty("fixedAmount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long FixedAmount { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}