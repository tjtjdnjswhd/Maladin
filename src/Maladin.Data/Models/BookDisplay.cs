namespace Maladin.Data.Models
{
    public sealed class BookDisplay : EntityBase
    {
        public required int BookId { get; set; }
        public required int AuthorId { get; set; }
        public int? TranslatorId { get; set; }
        public required int PublisherId { get; set; }
        public required int CategoryId { get; set; }
        public required string Title { get; set; }
        public required string Overview { get; set; }
        public required string PaperSize { get; set; }
        public required string PageCount { get; set; }
        public required string CoverUrl { get; set; }
        public required DateTimeOffset PublishAt { get; set; }

        public Book Book { get; set; }
        public Author Author { get; set; }
        public Translator Translator { get; set; }
        public Publisher Publisher { get; set; }
        public BookCategory BookCategory { get; set; }
    }
}