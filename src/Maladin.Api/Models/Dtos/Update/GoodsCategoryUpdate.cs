using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Update
{
    public class GoodsCategoryUpdate
    {
        [Required(AllowEmptyStrings = false)]
        public required string Name { get; set; }

        [EntityId]
        public int? ParentId { get; set; }
    }
}