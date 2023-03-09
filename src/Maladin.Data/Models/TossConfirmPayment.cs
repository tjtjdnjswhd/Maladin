using Maladin.Data.Enums;

namespace Maladin.Data.Models
{
    public class TossConfirmPayment : EntityBase
    {
        public required string PaymentKey { get; set; }
        public required EPgMethod PgMethod { get; set; }
        public required int TotalAmount { get; set; }
        public required int BalanceAmount { get; set; }
        public required EPaymentStatus Status { get; set; }
        public required DateTimeOffset RequestedAt { get; set; }
        public required DateTimeOffset ApprovedAt { get; set; }
        public required bool IsPartialCancelable { get; set; }
        public required string ReceiptUrl { get; set; }
        public required Guid OrderGuid { get; set; }

        public List<TossCancelPayment> CancelPayments { get; set; }
        public Order Order { get; set; }
    }
}