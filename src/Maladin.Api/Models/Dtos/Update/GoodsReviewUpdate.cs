using Maladin.Api.Validation;

namespace Maladin.Api.Models.Dtos.Update
{
    public class GoodsReviewUpdate
    {
        public string? Content { get; set; }

        [GoodsReviewRating]
        public required int Rating { get; set; }
    }
}