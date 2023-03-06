using Maladin.Data.Enums;

namespace Maladin.Data.Models
{
    public sealed class Order : EntityBase
    {
        public required int UserId { get; set; }
        public int? DeliveryId { get; set; }
        public required int? UsedPoint { get; set; }
        public required DateTimeOffset OrderedAt { get; set; }
        public required string Address { get; set; }
        public required string Postcode { get; set; }
        public required string ReceiverName { get; set; }
#nullable enable
        public string? Message { get; set; }
        public required string PhoneNumber { get; set; }
        public string? InvoiceNumber { get; set; }
#nullable restore
        public required EOrderState State { get; set; }

        public User User { get; set; }
        public Delivery Delivery { get; set; }
        public List<OrderBook> OrderBooks { get; set; }
        public PortonePayment Payment { get; set; }
    }
}