using Maladin.Data.Enums;

namespace Maladin.Data.Models
{
    public sealed class PortonePayment : EntityBase
    {
        public string ImpUid { get; set; }
        public int OrderId { get; set; }
        public required int Amount { get; set; }
        public required int CancelledAmount { get; set; }
        public required EPaymentState State { get; set; }

        public Order Order { get; set; }
    }
}