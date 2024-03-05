using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Create
{
    public class TranslatorCreate
    {
        [Required(AllowEmptyStrings = false)]
        public required string Name { get; set; }

        public string? Introduce { get; set; }
    }
}