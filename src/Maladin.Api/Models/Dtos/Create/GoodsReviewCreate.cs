using Maladin.Api.Validation;

namespace Maladin.Api.Models.Dtos.Create
{
    public class GoodsReviewCreate
    {
        public string? Content { get; set; }

        [GoodsReviewRating]
        public required int Rating { get; set; }

        [EntityId]
        public required int UserId { get; set; }

        [EntityId]
        public required int GoodsId { get; set; }
    }
}