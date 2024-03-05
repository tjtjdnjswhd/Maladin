using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Read.Abstractions
{
    public abstract class GoodsRead : IDtoKind
    {
        [EntityId]
        public required int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public required string Name { get; set; }

        public string? Overview { get; set; }

        [Range(0, int.MaxValue)]
        public required int Price { get; set; }

        [EntityId]
        public required int CategoryId { get; set; }

        public required string Kind { get; set; }
    }
}