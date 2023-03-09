namespace Maladin.Data.Models
{
    public class VirtualRefund : EntityBase
    {
        public string BankCode { get; set; }
        public string AccountNumber { get; set; }
        public string HolderNumber { get; set; }
        public int CancelPaymentId { get; set; }

        public TossCancelPayment CancelPayment { get; set; }
    }
}