namespace Maladin.Api.Models.Dtos.Create
{
    public class GoodsReviewCreate
    {
        public required string Content { get; set; }

        public required int Rating { get; set; }

        public required int UserId { get; set; }

        public required int GoodsId { get; set; }
    }
}