using Maladin.Data.Enums;

namespace Maladin.Data.Models
{
    public sealed class Order : EntityBase
    {
        public required int UserId { get; set; }
        public required int? UsedPoint { get; set; }
        public required DateTimeOffset OrderedAt { get; set; }
        public required string Address { get; set; }
        public required string Postcode { get; set; }
        public required string ReceiverName { get; set; }
        public required string PhoneNumber { get; set; }
#pragma warning disable CS8632 // nullable 참조 형식에 대한 주석은 코드에서 '#nullable' 주석 컨텍스트 내에만 사용되어야 합니다.
        public string? Message { get; set; }

        public int? DeliveryId { get; set; }
        public string? InvoiceNumber { get; set; }
#pragma warning restore CS8632 // nullable 참조 형식에 대한 주석은 코드에서 '#nullable' 주석 컨텍스트 내에만 사용되어야 합니다.
        public required EOrderState OrderState { get; set; }

        public User User { get; set; }
        public Delivery Delivery { get; set; }
        public List<OrderBook> OrderBooks { get; set; }
        public PortonePayment Payment { get; set; }
    }
}