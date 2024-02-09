namespace Portone.Models
{
    /// <summary>
    /// 현금 영수증 취소 성공 응답
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class CancelCashReceiptResponse
    {
        [Newtonsoft.Json.JsonProperty("cancelledAmount", Required = Newtonsoft.Json.Required.Always)]
        public long CancelledAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("cancelledAt", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public required DateTimeOffset CancelledAt { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}