using Maladin.EFCore.Models.Enums;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Update
{
    public class PaymentUpdate
    {
        public string? ImpUid { get; set; }

        public int? PaidAmount { get; set; }

        public int? BalanceAmount { get; set; }

        [EnumDataType(typeof(EPaymentStatus))]
        public required string Status { get; set; }
    }
}