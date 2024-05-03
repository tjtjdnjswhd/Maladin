using Maladin.Api.Models.Dtos.Update.Abstractions;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Update
{
    public class PencilUpdate : GoodsUpdate
    {
        public override EGoodsKind Kind => EGoodsKind.Pencil;

        [Required]
        public required string Maker { get; set; }
    }
}
