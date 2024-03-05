using Maladin.EFCore.Models.Enums;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Create
{
    public class PaymentCreate
    {
        [EnumDataType(typeof(EPaymentStatus))]
        public required string Status { get; set; }
    }
}