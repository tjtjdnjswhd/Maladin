using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Create
{
    public class GoodsCartCreate
    {
        [Range(1, int.MaxValue)]
        public required int Count { get; set; }

        [EntityId]
        public required int UserId { get; set; }

        [EntityId]
        public required int GoodsId { get; set; }
    }
}