using Maladin.Api.Models.Dtos.Read.Abstractions;
using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Maladin.Api.Models.Dtos.Read
{
    public class GoodsCartRead : ReadBase
    {
        [Range(1, int.MaxValue)]
        public required int Count { get; set; }

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