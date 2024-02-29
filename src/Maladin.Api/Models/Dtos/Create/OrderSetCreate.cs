namespace Maladin.Api.Models.Dtos.Create
{
    public class OrderSetCreate
    {
        public required int UsedPoints { get; set; }

        public required string Address { get; set; }

        public required string PostCode { get; set; }

        public required string ReceiverName { get; set; }

        public required string? Message { get; set; }

        public required string PhoneNumber { get; set; }

        public required int UserId { get; set; }

        public required int PaymentId { get; set; }
    }
}