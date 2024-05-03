using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Create
{
    public class GoodsCategoryCreate
    {
        [Required(AllowEmptyStrings = false)]
        public required string Name { get; set; }

        [EntityId]
        public int? ParentId { get; set; }
    }
}