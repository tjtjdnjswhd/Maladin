namespace Maladin.Data.Models
{
    public class TossCancelPayment : EntityBase
    {
        public required string TransactionKey { get; set; }
        public required int CancelAmount { get; set; }
        public required DateTimeOffset CanceledAt { get; set; }
        public required string ConfirmKey { get; set; }
        public required int? VirtualRefundId { get; set; }

        public TossConfirmPayment ConfirmPayment { get; set; }
        public VirtualRefund VirtualRefund { get; set; }
    }
}