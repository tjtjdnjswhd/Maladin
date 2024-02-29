namespace Maladin.Api.Models.Dtos.Update
{
    public class OrderSetUpdate
    {
        public required int UsedPoints { get; set; }

        public required string Address { get; set; }

        public required string PostCode { get; set; }

        public required string ReceiverName { get; set; }

        public string? Message { get; set; }

        public required string PhoneNumber { get; set; }

        public string? InvoiceNumber { get; set; }

        public required string State { get; set; }

        public required int UserId { get; set; }

        public int? DeliveryId { get; set; }

        public required int PaymentId { get; set; }
    }
}