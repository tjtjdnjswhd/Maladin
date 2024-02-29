namespace Maladin.Api.Models.Dtos.Read
{
    public class GoodsReviewRead
    {
        public required int Id { get; set; }

        public required string Content { get; set; }

        public required int Rating { get; set; }

        public required DateTimeOffset CreatedAt { get; set; }

        public required int UserId { get; set; }

        public required int GoodsId { get; set; }
    }
}