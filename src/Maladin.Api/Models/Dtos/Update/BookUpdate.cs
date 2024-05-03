using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Update
{
    public class BookUpdate
    {
        [Range(0, int.MaxValue)]
        public required int Stock { get; set; }

        [Required(AllowEmptyStrings = false)]
        public required string Isbn { get; set; }

        [Range(0, int.MaxValue)]
        public required int Sales { get; set; }
    }
}