namespace Maladin.Service.Settings
{
    public class PortonePaymentServiceSettings
    {
        public required string BaseUrl { get; set; }
        public required string AccessTokenGetUrl { get; set; }
        public required string CancelUrl { get; set; }
        public required string ApiKey { get; set; }
        public required string ApiSecret { get; set; }
        public required string PaymentUrl { get; set; }
    }
}