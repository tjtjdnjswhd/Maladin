using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Create
{
    public class BookCreate
    {
        public required int Stock { get; set; }

        [Required(AllowEmptyStrings = false)]
        public required string Isbn { get; set; }

        public required int Sales { get; set; }
    }
}