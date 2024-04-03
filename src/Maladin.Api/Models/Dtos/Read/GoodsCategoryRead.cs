using Maladin.Api.Models.Dtos.Read.Abstractions;
using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Maladin.Api.Models.Dtos.Read
{
    public class GoodsCategoryRead : ReadBase
    {
        [Required(AllowEmptyStrings = false)]
        public required string Name { get; set; }

        [EntityId]
        public required int? ParentId { get; set; }

        [JsonIgnore]
        public GoodsCategoryRead? Parent { get; private set; }

        [JsonIgnore]
        public List<GoodsCategoryRead>? ChildCategories { get; private set; }

        [JsonIgnore]
        public List<GoodsRead>? GoodsList { get; private set; }
    }
}