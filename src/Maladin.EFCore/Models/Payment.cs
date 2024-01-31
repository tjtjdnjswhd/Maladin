using Maladin.EFCore.Models.Abstractions;
using Maladin.EFCore.Models.Enums;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maladin.EFCore.Models
{
    [Table("Payment")]
    public class Payment(EPaymentStatus status) : EntityBase
    {
        public string? ImpUid { get; set; }

        public int? PaidAmount { get; set; }

        public int? BalanceAmount { get; set; }

        [Required]
        public EPaymentStatus Status { get; set; } = status;

        public OrderSet Order { get; }
    }
}