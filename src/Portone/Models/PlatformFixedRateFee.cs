using Portone.Models.Abstractions;

namespace Portone.Models
{
    /// <summary>
    /// 정률 수수료
    /// <br/>총 금액에 정해진 비율을 곱한 만큼의 수수료를 책정합니다.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PlatformFixedRateFee : PlatformFee
    {
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required string Type { get; set; }

        /// <summary>
        /// 총 금액 대비 수수료 비율을 의미하며, 밀리 퍼센트 단위 (10^-5) 의 음이 아닌 정수입니다. &lt;code&gt;총 금액 * rate * 10^5&lt;/code&gt; (&lt;code&gt;rate * 10^3 %&lt;/code&gt;) 만큼 수수료를 책정합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("rate", Required = Newtonsoft.Json.Required.Always)]
        public int Rate { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}