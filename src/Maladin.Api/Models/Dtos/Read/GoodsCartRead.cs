using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Read
{
    public class GoodsCartRead
    {
        [EntityId]
        public required int Id { get; set; }

        [Range(1, int.MaxValue)]
        public required int Count { get; set; }

        [EntityId]
        public required int UserId { get; set; }

        [EntityId]
        public required int GoodsId { get; set; }
    }
}