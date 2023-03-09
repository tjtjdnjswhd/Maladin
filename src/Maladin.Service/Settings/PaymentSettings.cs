namespace Maladin.Service.Settings
{
    public class PaymentSettings
    {
        public required string ApiKey { get; set; }
        public required string ApiSecret { get; set; }
        public required string BaseUrl { get; set; }
        public required string AccessTokenUrl { get; set; }
        public required string CancelUrl { get; set; }
        public required string PaymentUrl { get; set; }
        public required string PrepareUrl { get; set; }
    }
}