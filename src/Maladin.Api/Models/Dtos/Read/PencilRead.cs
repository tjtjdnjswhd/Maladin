using Maladin.Api.Models.Dtos.Read.Abstractions;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Read
{
    public class PencilRead : GoodsRead
    {
        public override EGoodsKind Kind => EGoodsKind.Pencil;

        [Required]
        public required string Maker { get; set; }
    }
}