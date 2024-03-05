using Maladin.Api.Validation;
using Maladin.EFCore.Models.Enums;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Read
{
    public class PaymentRead
    {
        [EntityId]
        public required int Id { get; set; }

        public string? ImpUid { get; set; }

        public int? PaidAmount { get; set; }

        public int? BalanceAmount { get; set; }

        [EnumDataType(typeof(EPaymentStatus))]
        public required string Status { get; set; }
    }
}