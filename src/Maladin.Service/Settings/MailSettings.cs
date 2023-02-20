namespace Maladin.Service.Settings
{
    public sealed class MailSettings
    {
        public required string Host { get; set; }
        public required int Port { get; set; }
        public required bool UseSsl { get; set; }
        public required string SenderName { get; set; }
        public required string SenderAddress { get; set; }
        public required string Password { get; set; }
    }
}