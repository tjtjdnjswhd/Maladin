namespace Maladin.Data.Models
{
    public sealed class BookReview : EntityBase
    {
        public required int UserId { get; set; }
        public required int BookId { get; set; }
        public required string Content { get; set; }
        public required int Rating { get; set; }
        public required DateTimeOffset CreatedAt { get; set; }

        public User User { get; set; }
        public Book Book { get; set; }
        public List<BookReviewComment> BookReviewComments { get; set; }
    }
}