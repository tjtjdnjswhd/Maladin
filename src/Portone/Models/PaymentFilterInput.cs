namespace Portone.Models
{
    /// <summary>
    /// 결제 건 다건 조회를 위한 입력 정보
    /// <br/>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.0.1.0 (NJsonSchema v11.0.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class PaymentFilterInput
    {
        [Newtonsoft.Json.JsonProperty("merchantId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MerchantId { get; set; }

        /// <summary>
        /// Merchant 사용자만 사용가능하며, 지정되지 않은 경우 가맹점 전체 결제 건을 조회합니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("storeId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StoreId { get; set; }

        [Newtonsoft.Json.JsonProperty("timestampType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PaymentTimestampType TimestampType { get; set; }

        /// <summary>
        /// 값을 입력하지 않으면 end의 90일 전으로 설정됩니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("from", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateTimeOffset From { get; set; }

        /// <summary>
        /// 값을 입력하지 않으면 현재 시점으로 설정됩니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("until", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateTimeOffset Until { get; set; }

        /// <summary>
        /// 값을 입력하지 않으면 결제상태 필터링이 적용되지 않습니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore, ItemConverterType = typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ICollection<PaymentStatus> Status { get; set; }

        /// <summary>
        /// 값을 입력하지 않으면 결제수단 필터링이 적용되지 않습니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("methods", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore, ItemConverterType = typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ICollection<PaymentMethodType> Methods { get; set; }

        /// <summary>
        /// 값을 입력하지 않으면 결제대행사 필터링이 적용되지 않습니다.
        /// <br/>
        /// </summary>
        [Newtonsoft.Json.JsonProperty("pgProvider", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore, ItemConverterType = typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ICollection<PgProvider> PgProvider { get; set; }

        [Newtonsoft.Json.JsonProperty("isTest", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsTest { get; set; }

        [Newtonsoft.Json.JsonProperty("isScheduled", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsScheduled { get; set; }

        [Newtonsoft.Json.JsonProperty("sortBy", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PaymentSortBy SortBy { get; set; }

        [Newtonsoft.Json.JsonProperty("sortOrder", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PaymentSortOrder SortOrder { get; set; }

        [Newtonsoft.Json.JsonProperty("version", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PortOneVersion Version { get; set; }

        [Newtonsoft.Json.JsonProperty("webhookStatus", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PaymentWebhookStatus WebhookStatus { get; set; }

        [Newtonsoft.Json.JsonProperty("platformType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PaymentClientType PlatformType { get; set; }

        [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public Currency Currency { get; set; }

        [Newtonsoft.Json.JsonProperty("isEscrow", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsEscrow { get; set; }

        [Newtonsoft.Json.JsonProperty("escrowStatus", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PaymentFilterInputEscrowStatus EscrowStatus { get; set; }

        [Newtonsoft.Json.JsonProperty("cardBrand", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public CardBrand CardBrand { get; set; }

        [Newtonsoft.Json.JsonProperty("cardType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public CardType CardType { get; set; }

        [Newtonsoft.Json.JsonProperty("cardOwnerType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public CardOwnerType CardOwnerType { get; set; }

        [Newtonsoft.Json.JsonProperty("giftCertificateType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PaymentMethodGiftCertificateType GiftCertificateType { get; set; }

        [Newtonsoft.Json.JsonProperty("cashReceiptType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public CashReceiptType CashReceiptType { get; set; }

        [Newtonsoft.Json.JsonProperty("cashReceiptStatus", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PaymentCashReceiptStatus CashReceiptStatus { get; set; }

        [Newtonsoft.Json.JsonProperty("cashReceiptIssuedAtRange", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateTimeRange CashReceiptIssuedAtRange { get; set; }

        [Newtonsoft.Json.JsonProperty("cashReceiptCancelledAtRange", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateTimeRange CashReceiptCancelledAtRange { get; set; }

        [Newtonsoft.Json.JsonProperty("textSearch", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ICollection<PaymentTextSearch> TextSearch { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ??= new Dictionary<string, object>(); }
            set { _additionalProperties = value; }
        }
    }
}