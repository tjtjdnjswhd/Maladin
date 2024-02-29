using Maladin.Api.Models.Dtos.Update.Abstractions;

namespace Maladin.Api.Models.Dtos.Update
{
    public class BookDisplayUpdate : GoodsUpdate
    {
        public required string PaperSize { get; set; }

        public string? CoverUrl { get; set; }

        public required DateTimeOffset PublishedAt { get; set; }

        public required int BookId { get; set; }

        public required int AuthorId { get; set; }

        public int? TranslatorId { get; set; }
    }
}