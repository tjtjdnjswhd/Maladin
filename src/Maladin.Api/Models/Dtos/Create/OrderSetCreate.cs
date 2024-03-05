using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Create
{
    public class OrderSetCreate
    {
        [Range(0, int.MaxValue)]
        public required int UsedPoints { get; set; }

        [Required(AllowEmptyStrings = false)]
        public required string Address { get; set; }

        [Required(AllowEmptyStrings = false)]
        public required string PostCode { get; set; }

        [Required(AllowEmptyStrings = false)]
        public required string ReceiverName { get; set; }

        public string? Message { get; set; }

        [Phone]
        public required string PhoneNumber { get; set; }

        [EntityId]
        public required int UserId { get; set; }

        [EntityId]
        public required int PaymentId { get; set; }
    }
}