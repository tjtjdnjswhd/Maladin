using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Update
{
    public class RoleUpdate
    {
        [Required(AllowEmptyStrings = false)]
        public required string Name { get; set; }

        public required int Priority { get; set; }
    }
}