using Maladin.Api.Models.Dtos.Read.Abstractions;
using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Maladin.Api.Models.Dtos.Read
{
    public class GoodsOrderRead : ReadBase
    {
        [Range(1, int.MaxValue)]
        public required int OrderQty { get; set; }

        [Range(0, int.MaxValue)]
        public required int CancelQty { get; set; }

        [EntityId]
        public required int OrderSetId { get; set; }

        [EntityId]
        public required int GoodsId { get; set; }

        [JsonIgnore]
        public OrderSetRead? OrderSet { get; }

        [JsonIgnore]
        public GoodsRead? Goods { get; }
    }
}