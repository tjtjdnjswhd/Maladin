using Maladin.Api.Validation;

namespace Maladin.Api.Models.Dtos.Read
{
    public class GoodsReviewRead
    {
        [EntityId]
        public required int Id { get; set; }

        public string? Content { get; set; }

        [GoodsReviewRating]
        public required int Rating { get; set; }

        public required DateTimeOffset CreatedAt { get; set; }

        [EntityId]
        public required int UserId { get; set; }

        [EntityId]
        public required int GoodsId { get; set; }
    }
}