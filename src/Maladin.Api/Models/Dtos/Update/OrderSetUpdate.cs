using Maladin.Api.Validation;
using Maladin.EFCore.Models.Enums;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Update
{
    public class OrderSetUpdate
    {
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

        public string? InvoiceNumber { get; set; }

        [EnumDataType(typeof(EOrderSetStatus))]
        public required string State { get; set; }

        [EntityId]
        public required int UserId { get; set; }

        [EntityId]
        public int? DeliveryId { get; set; }

        [EntityId]
        public required int PaymentId { get; set; }
    }
}