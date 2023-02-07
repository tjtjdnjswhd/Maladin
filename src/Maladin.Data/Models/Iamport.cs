namespace Maladin.Data.Models
{
    public sealed class IamportPayment : EntityBase
    {
        public required string ImpUid { get; set; }
        public required int OrderId { get; set; }
        public required string Amount { get; set; }
        public required string PgProvider { get; set; }

        public Order Order { get; set; }
    }
}