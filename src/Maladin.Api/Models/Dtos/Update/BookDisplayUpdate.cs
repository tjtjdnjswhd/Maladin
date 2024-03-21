using Maladin.Api.Models.Dtos.Update.Abstractions;
using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Update
{
    public class BookDisplayUpdate : GoodsUpdate
    {
        public override EGoodsKind Kind => EGoodsKind.BookDisplay;

        public required int PageCount { get; set; }

        [Required(AllowEmptyStrings = false)]
        public required string PaperSize { get; set; }

        public Uri? CoverUrl { get; set; }

        public required DateTimeOffset PublishedAt { get; set; }

        [EntityId]
        public required int BookId { get; set; }

        [EntityId]
        public required int AuthorId { get; set; }

        [EntityId]
        public required int PublisherId { get; set; }

        [EntityId]
        public int? TranslatorId { get; set; }
    }
}