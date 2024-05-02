using System.ComponentModel.DataAnnotations.Schema;

namespace Maladin.EFCore.Models.Abstractions
{
    [Table("Payment")]
    public abstract class Payment : EntityBase
    {
        public int Amount { get; set; }

        public OrderSet Order { get; }
    }
}