using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Create
{
    public class RoleCreate
    {
        [Required(AllowEmptyStrings = false)]
        public required string Name { get; set; }

        public required int Priority { get; set; }
    }
}