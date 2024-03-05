using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Read
{
    public class BookRead
    {
        [EntityId]
        public required int Id { get; set; }

        [Range(0, int.MaxValue)]
        public required int Stock { get; set; }

        [Required(AllowEmptyStrings = false)]
        public required string Isbn { get; set; }

        [Range(0, int.MaxValue)]
        public required int Sales { get; set; }
    }
}