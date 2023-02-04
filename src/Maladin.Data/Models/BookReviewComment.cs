namespace Maladin.Data.Models
{
    public class BookReviewComment : EntityBase
    {
        public required int ReviewId { get; set; }
        public required string Content { get; set; }

        public BookReview BookReview { get; set; }
    }
}