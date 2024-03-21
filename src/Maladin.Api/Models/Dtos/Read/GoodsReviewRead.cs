using Maladin.Api.Models.Dtos.Read.Abstractions;
using Maladin.Api.Validation;

using System.Text.Json.Serialization;

namespace Maladin.Api.Models.Dtos.Read
{
    public class GoodsReviewRead : ReadBase
    {
        public string? Content { get; set; }

        [GoodsReviewRating]
        public required int Rating { get; set; }

        public required DateTimeOffset CreatedAt { get; set; }

        [EntityId]
        public required int UserId { get; set; }

        [EntityId]
        public required int GoodsId { get; set; }

        [JsonIgnore]
        public UserRead? User { get; }

        [JsonIgnore]
        public GoodsRead? Goods { get; }
    }
}