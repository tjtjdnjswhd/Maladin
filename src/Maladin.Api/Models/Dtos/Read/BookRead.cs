using Maladin.Api.Models.Dtos.Read.Abstractions;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Maladin.Api.Models.Dtos.Read
{
    public class BookRead : ReadBase
    {
        [Range(0, int.MaxValue)]
        public required int Stock { get; set; }

        [Required(AllowEmptyStrings = false)]
        public required string Isbn { get; set; }

        [Range(0, int.MaxValue)]
        public required int Sales { get; set; }

        [JsonIgnore]
        public List<BookDisplayRead>? BookDisplays { get; }
    }
}