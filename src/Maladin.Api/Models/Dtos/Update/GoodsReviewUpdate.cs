namespace Maladin.Api.Models.Dtos.Update
{
    public class GoodsReviewUpdate
    {
        public required string Content { get; set; }

        public required int Rating { get; set; }
    }
}