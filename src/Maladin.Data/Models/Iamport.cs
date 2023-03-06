namespace Maladin.Data.Models
{
    public sealed class PortonePayment : EntityBase
    {
        public required string ImpUid { get; set; }
        public required int OrderId { get; set; }
        public required int Amount { get; set; }

        public Order Order { get; set; }
    }
}