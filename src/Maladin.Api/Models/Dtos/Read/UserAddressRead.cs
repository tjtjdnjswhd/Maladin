using Maladin.Api.Models.Dtos.Read.Abstractions;
using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Maladin.Api.Models.Dtos.Read
{
    public class UserAddressRead : ReadBase
    {
        [Required(AllowEmptyStrings = false)]
        public required string Address { get; set; }

        [Required(AllowEmptyStrings = false)]
        public required string PostCode { get; set; }

        public required bool IsDefault { get; set; }

        [EntityId]
        public required int UserId { get; set; }

        [JsonIgnore]
        public UserRead? User { get; private set; }
    }
}