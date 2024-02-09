using Portone.Models.Abstractions;

namespace Portone.Models
{
    /// <summary>
    /// 정산 주기
    /// <br/>지체일, 정산일, 기준일로 구성되며, 해당 요소들의 조합으로 실제 정산일을 계산합니다.
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PlatformSettlementCycle
    {
        /// <summary>
        /// 정산시작일(통상 주문완료일)로부터 더해진 다음 날짜로부터 가장 가까운 날에 정산이 됩니다. 최소 1 에서 최대 10 까지 지정할 수 있습니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("lagDays", Required = Newtonsoft.Json.Required.Always)]
        public int LagDays { get; set; }

        [Newtonsoft.Json.JsonProperty("datePolicy", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public required PlatformSettlementCycleDatePolicy DatePolicy { get; set; }

        [Newtonsoft.Json.JsonProperty("method", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public required PlatformSettlementCycleMethod Method { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}