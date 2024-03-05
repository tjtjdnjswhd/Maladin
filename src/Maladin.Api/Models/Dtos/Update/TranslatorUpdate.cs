using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Update
{
    public class TranslatorUpdate
    {
        [Required(AllowEmptyStrings = false)]
        public required string Name { get; set; }

        public string? Introduce { get; set; }
    }
}