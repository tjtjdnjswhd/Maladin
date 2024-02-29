using Maladin.Api.Models.Dtos.Create.Abstractions;

namespace Maladin.Api.Models.Dtos.Create
{
    public class BookDisplayCreate : GoodsCreate
    {
        public required string PaperSize { get; set; }

        public required DateTimeOffset PublishedAt { get; set; }

        public required int BookId { get; set; }

        public required int AuthorId { get; set; }

        public int? TranslatorId { get; set; }

        public required int PublisherId { get; set; }
    }
}