using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Create
{
    public class GoodsOrderCreate
    {
        [Range(0, int.MaxValue)]
        public required int Price { get; set; }

        [Range(1, int.MaxValue)]
        public required int OrderQty { get; set; }

        [Range(0, int.MaxValue)]
        public required int CancelQty { get; set; }

        [EntityId]
        public required int OrderSetId { get; set; }

        [EntityId]
        public required int GoodsId { get; set; }
    }
}