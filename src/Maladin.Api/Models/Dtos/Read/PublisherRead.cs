using Maladin.Api.Models.Dtos.Read.Abstractions;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Maladin.Api.Models.Dtos.Read
{
    public class PublisherRead : ReadBase
    {
        [Required(AllowEmptyStrings = false)]
        public required string Name { get; set; }

        public required string? Introduce { get; set; }

        [JsonIgnore]
        public List<BookDisplayRead>? Books { get; }
    }
}