namespace Maladin.Api.Models.Dtos
{
    public class BookDisplayDto
    {
        public int Id { get; set; }

        public string PaperSize { get; set; }

        public int PageCount { get; set; }

        public string? CoverUrl { get; set; }

        public DateTimeOffset PublishedAt { get; set; }

        public int BookId { get; set; }

        public AuthorDto Author { get; set; }

        public TranslatorDto? Translator { get; set; }

        public PublisherDto Publisher { get; set; }
    }
}