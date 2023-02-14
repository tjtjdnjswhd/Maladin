namespace Maladin.Service.Models
{
    public sealed class BookDisplayContext
    {
        public BookDisplayContext(int bookId, int publisherId, int authorId, int? translatorId, int categoryId, string title, string overview, string paperSize, int pageCount, string coverUrl, DateTimeOffset publishAt)
        {
            BookId = bookId;
            PublisherId = publisherId;
            AuthorId = authorId;
            TranslatorId = translatorId;
            CategoryId = categoryId;
            Title = title;
            Overview = overview;
            PaperSize = paperSize;
            PageCount = pageCount;
            CoverUrl = coverUrl;
            PublishAt = publishAt;
        }

        public required int BookId { get; init; }
        public required int PublisherId { get; init; }
        public required int AuthorId { get; init; }
        public required int? TranslatorId { get; init; }
        public required int CategoryId { get; init; }
        public required string Title { get; init; }
        public required string Overview { get; init; }
        public required string PaperSize { get; init; }
        public required int PageCount { get; init; }
        public required string CoverUrl { get; init; }
        public required DateTimeOffset PublishAt { get; init; }
    }
}
