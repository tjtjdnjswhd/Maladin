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

        public int BookId { get; init; }
        public int PublisherId { get; init; }
        public int AuthorId { get; init; }
        public int? TranslatorId { get; init; }
        public int CategoryId { get; init; }
        public string Title { get; init; }
        public string Overview { get; init; }
        public string PaperSize { get; init; }
        public int PageCount { get; init; }
        public string CoverUrl { get; init; }
        public DateTimeOffset PublishAt { get; init; }
    }
}
