using Maladin.Service.Converters;

using System.Text.Json.Serialization;

namespace Maladin.Service.Models
{
    [JsonConverter(typeof(PortonePaymentResponseConverter))]
    internal class PortonePaymentResponse
    {
#pragma warning disable CS8618 // 생성자를 종료할 때 null을 허용하지 않는 필드에 null이 아닌 값을 포함해야 합니다. null 허용으로 선언해 보세요.
        public PortonePaymentResponse()
        {
            BankInfo = new();
            CardInfo = new();
            VirtualBankInfo = new();
            BuyerInfo = new();
        }

        [JsonRequired]
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonRequired]
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonRequired]
        [JsonPropertyName("imp_uid")]
        public string ImpUid { get; set; }

        [JsonRequired]
        [JsonPropertyName("merchant_uid")]
        public string MerchantUid { get; set; }

        [JsonRequired]
        [JsonPropertyName("pay_method")]
        public EPayMethod? PayMethod { get; set; }

        [JsonRequired]
        [JsonPropertyName("channel")]
        public EChannel? Channel { get; set; }

        [JsonRequired]
        [JsonPropertyName("pg_provider")]
        public EPgProvider? PgProvider { get; set; }

        [JsonRequired]
        [JsonPropertyName("emb_pg_provider")]
        public EEmbPgProvider? EmbPgProvider { get; set; }

        [JsonRequired]
        [JsonPropertyName("pg_tid")]
        public string PgTid { get; set; }

        [JsonRequired]
        [JsonPropertyName("pg_id")]
        public string PgId { get; set; }

        [JsonRequired]
        [JsonPropertyName("escrow")]
        public bool Escrow { get; set; }

        [JsonRequired]
        [JsonPropertyName("apply_num")]
        public string ApplyNum { get; set; }

        public Bank? BankInfo { get; set; }

        public Card? CardInfo { get; set; }

        public VirtualBank? VirtualBankInfo { get; set; }

        [JsonRequired]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonRequired]
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonRequired]
        [JsonPropertyName("cancel_amount")]
        public int CancelAmount { get; set; }

        [JsonRequired]
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        public Buyer BuyerInfo { get; set; }

        [JsonRequired]
        [JsonPropertyName("custom_data")]
        public string CustomData { get; set; }

        [JsonRequired]
        [JsonPropertyName("user_agent")]
        public string UserAgent { get; set; }

        [JsonRequired]
        [JsonPropertyName("status")]
        public EStatus Status { get; set; }

        [JsonRequired]
        [JsonPropertyName("started_at")]
        public DateTimeOffset StartedAt { get; set; }

        [JsonRequired]
        [JsonPropertyName("paid_at")]
        public DateTimeOffset PaidAt { get; set; }

        [JsonRequired]
        [JsonPropertyName("failed_at")]
        public DateTimeOffset FailedAt { get; set; }

        [JsonRequired]
        [JsonPropertyName("cancelled_at")]
        public DateTimeOffset CancelledAt { get; set; }

        [JsonRequired]
        [JsonPropertyName("fail_reason")]
        public string? FailReason { get; set; }

        [JsonRequired]
        [JsonPropertyName("cancel_reason")]
        public string? CancelReason { get; set; }

        [JsonRequired]
        [JsonPropertyName("receipt_url")]
        public string? ReceiptUrl { get; set; }

        [JsonRequired]
        [JsonPropertyName("cancel_history")]
        public CancelLog[]? CancelHistory { get; set; }

        [JsonRequired]
        [JsonPropertyName("cancel_receipt_urls")]
        public string[]? CancelReceiptUrls { get; set; }

        [JsonRequired]
        [JsonPropertyName("cash_receipt_issued")]
        public bool CashRecieptIssued { get; set; }

        [JsonRequired]
        [JsonPropertyName("customer_uid")]
        public string? CustomerUid { get; set; }

        [JsonRequired]
        [JsonPropertyName("customer_uid_usage")]
        public string? CustomerUidUsage { get; set; }

        public class Buyer
        {
            [JsonRequired]
            [JsonPropertyName("buyer_name")]
            public string Name { get; set; }

            [JsonRequired]
            [JsonPropertyName("buyer_email")]
            public string Email { get; set; }

            [JsonRequired]
            [JsonPropertyName("buyer_tel")]
            public string Tel { get; set; }

            [JsonRequired]
            [JsonPropertyName("buyer_addr")]
            public string Address { get; set; }

            [JsonRequired]
            [JsonPropertyName("buyer_postcode")]
            public string Postcode { get; set; }
        }

        public class Card
        {
            [JsonPropertyName("card_code")]
            [JsonRequired]
            public string? Code { get; set; }

            [JsonRequired]
            [JsonPropertyName("card_name")]
            public string? Name { get; set; }

            [JsonRequired]
            [JsonPropertyName("card_quota")]
            public int Quota { get; set; }

            [JsonRequired]
            [JsonPropertyName("card_number")]
            public string? Number { get; set; }

            [JsonRequired]
            [JsonPropertyName("card_type")]
            public string? Type { get; set; }
        }

        public class VirtualBank
        {
            [JsonRequired]
            [JsonPropertyName("vbank_code")]
            public string? Code { get; set; }

            [JsonRequired]
            [JsonPropertyName("vbank_name")]
            public string? Name { get; set; }

            [JsonRequired]
            [JsonPropertyName("vbank_num")]
            public string? Num { get; set; }

            [JsonRequired]
            [JsonPropertyName("vbank_holder")]
            public string? Holder { get; set; }

            [JsonRequired]
            [JsonPropertyName("vbank_date")]
            public DateTimeOffset Date { get; set; }

            [JsonRequired]
            [JsonPropertyName("vbank_issued_at")]
            public DateTimeOffset IssuedAt { get; set; }
        }

        public class Bank
        {
            [JsonRequired]
            [JsonPropertyName("bank_code")]
            public string? Code { get; set; }

            [JsonRequired]
            [JsonPropertyName("bank_name")]
            public string? Name { get; set; }
        }

        public class CancelLog
        {
            [JsonRequired]
            [JsonPropertyName("pg_tid")]
            public string PgTid { get; set; }

            [JsonRequired]
            [JsonPropertyName("amount")]
            public int Amount { get; set; }

            [JsonRequired]
            [JsonPropertyName("cancelled_at")]
            public DateTimeOffset CancelledAt { get; set; }

            [JsonRequired]
            [JsonPropertyName("reason")]
            public string? Reason { get; set; }

            [JsonRequired]
            [JsonPropertyName("receipt_url")]
            public string? ReceiptUrl { get; set; }
        }

        public enum EChannel
        {
            PC,
            Mobile,
            API
        }

        public enum EPayMethod
        {
            Samsung,
            Card,
            Trans,
            VBank,
            Phone,
            Cultureland,
            SmartCulture,
            BooknLife,
            HappyMoney,
            Point,
            SSGPay,
            LPay,
            Payco,
            KakaoPay,
            TossPay,
            NaverPay
        }

        public enum EPgProvider
        {
            Inicis,
            Nice
        }

        public enum EEmbPgProvider
        {
            Chai,
            KakaoPay
        }

        public enum EStatus
        {
            Ready,
            Paid,
            Cancelled,
            Failed
        }
    }
#pragma warning restore CS8618 // 생성자를 종료할 때 null을 허용하지 않는 필드에 null이 아닌 값을 포함해야 합니다. null 허용으로 선언해 보세요.
}