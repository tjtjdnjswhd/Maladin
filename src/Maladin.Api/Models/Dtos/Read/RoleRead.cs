using Maladin.Api.Models.Dtos.Read.Abstractions;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Maladin.Api.Models.Dtos.Read
{
    public class RoleRead : ReadBase
    {
        [Required(AllowEmptyStrings = false)]
        public required string Name { get; set; }

        public required int Priority { get; set; }

        [JsonIgnore]
        public List<UserRead>? Users { get; }
    }
}