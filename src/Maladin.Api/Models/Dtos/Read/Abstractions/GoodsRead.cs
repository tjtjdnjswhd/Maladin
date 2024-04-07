using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Read.Abstractions
{
    public class GoodsRead : ReadBase, IGoodsKind
    {
        public virtual EGoodsKind Kind { get; } = EGoodsKind.Unknown;

        [Required(AllowEmptyStrings = false)]
        public required string Name { get; set; }

        public required string? Overview { get; set; }

        [Range(0, int.MaxValue)]
        public required int Price { get; set; }

        [EntityId]
        public required int CategoryId { get; set; }

        public GoodsCategoryRead? Category { get; protected set; }

        public List<GoodsCartRead>? Carts { get; protected set; }

        public List<GoodsOrderRead>? Orders { get; protected set; }

        public List<GoodsReviewRead>? Reviews { get; protected set; }
    }
}