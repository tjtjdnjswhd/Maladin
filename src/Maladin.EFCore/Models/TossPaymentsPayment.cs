using Maladin.EFCore.Models.Abstractions;

using System.ComponentModel.DataAnnotations.Schema;

namespace Maladin.EFCore.Models
{
    [Table("TossPaymentsPayment")]
    public class TossPaymentsPayment : Payment
    {
        public TossPaymentsPayment(string paymentKey, int amount)
        {
            PaymentKey = paymentKey;
            Amount = amount;
        }

        public string PaymentKey { get; set; }

        public string Status { get; set; }
    }
}