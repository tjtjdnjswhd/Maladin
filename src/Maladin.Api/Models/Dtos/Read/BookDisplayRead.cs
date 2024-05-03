using Maladin.Api.Models.Dtos.Read.Abstractions;
using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Read
{
    public class BookDisplayRead : GoodsRead
    {
        public override EGoodsKind Kind => EGoodsKind.BookDisplay;

        [Required(AllowEmptyStrings = false)]
        public required string PaperSize { get; set; }

        [Range(1, int.MaxValue)]
        public required int PageCount { get; set; }

        public required Uri? CoverUrl { get; set; }

        public required DateTimeOffset PublishedAt { get; set; }

        [EntityId]
        public required int BookId { get; set; }

        [EntityId]
        public required int AuthorId { get; set; }

        [EntityId]
        public required int? TranslatorId { get; set; }

        [EntityId]
        public required int PublisherId { get; set; }
    }
}