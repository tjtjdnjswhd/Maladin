namespace Maladin.Data.Models
{
    public sealed class BookReviewComment : EntityBase
    {
        public required int ReviewId { get; set; }
        public required string Content { get; set; }

        public BookReview BookReview { get; set; }
    }
}