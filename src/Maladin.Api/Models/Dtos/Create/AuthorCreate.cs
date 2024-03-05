using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Create
{
    public class AuthorCreate
    {
        [Required(AllowEmptyStrings = false)]
        public required string Name { get; set; }

        public string? Introduce { get; set; }
    }
}