using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Read
{
    public class UserAddressRead
    {
        [EntityId]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public required string Address { get; set; }

        [Required(AllowEmptyStrings = false)]
        public required string PostCode { get; set; }

        public required bool IsDefault { get; set; }

        [EntityId]
        public required int UserId { get; set; }
    }
}