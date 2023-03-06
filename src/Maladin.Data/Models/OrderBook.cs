namespace Maladin.Data.Models
{
    public sealed class OrderBook : EntityBase
    {
        public int OrderId { get; set; }
        public required int BookId { get; set; }
        public required int OrderQty { get; set; }
        public int? RefundQty { get; set; }
        public required int PricePerItem { get; set; }

        public Book Book { get; set; }
        public Order Order { get; set; }
    }
}