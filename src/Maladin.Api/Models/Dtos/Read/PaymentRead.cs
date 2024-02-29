namespace Maladin.Api.Models.Dtos.Read
{
    public class PaymentRead
    {
        public required int Id { get; set; }

        public string? ImpUid { get; set; }

        public int? PaidAmount { get; set; }

        public int? BalanceAmount { get; set; }

        public required string Status { get; set; }
    }
}