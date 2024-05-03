using Maladin.Api.Models.Dtos.Create.Abstractions;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Create
{
    public class PencilCreate : GoodsCreate
    {
        public override EGoodsKind Kind => EGoodsKind.Pencil;

        [Required]
        public required string Maker { get; set; }
    }
}
