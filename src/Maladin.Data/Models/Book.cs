namespace Maladin.Data.Models
{
    public sealed class Book : EntityBase
    {
        public required string Isbn { get; set; }
        public required int Stock { get; set; }
        public required int Sales { get; set; }
        public required int Price { get; set; }

        public BookDisplay BookDisplay { get; set; }
        public List<OrderBook> OrderBooks { get; set; }
        public List<BookReview> BookReviews { get; set; }
        public List<BookBox> BookBoxes { get; set; }
    }
}