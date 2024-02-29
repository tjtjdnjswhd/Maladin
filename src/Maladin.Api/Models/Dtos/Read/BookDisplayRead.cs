using Maladin.Api.Models.Dtos.Read.Abstractions;

namespace Maladin.Api.Models.Dtos.Read
{
    public class BookDisplayRead : GoodsRead
    {
        public required string PaperSize { get; set; }

        public required int PageCount { get; set; }

        public string? CoverUrl { get; set; }

        public required DateTimeOffset PublishedAt { get; set; }

        public required GoodsCategoryRead Category { get; set; }

        public required BookRead Book { get; set; }

        public required AuthorRead Author { get; set; }

        public required TranslatorRead? Translator { get; set; }

        public required PublisherRead Publisher { get; set; }
    }
}