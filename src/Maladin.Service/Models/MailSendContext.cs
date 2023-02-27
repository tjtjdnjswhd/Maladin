namespace Maladin.Service.Models
{
    public class MailSendContext
    {
        public MailSendContext(string subject, string fromAddress, string fromName, string toAddress, string toName, string body)
        {
            Subject = subject;
            FromAddress = fromAddress;
            FromName = fromName;
            ToAddress = toAddress;
            ToName = toName;
            Body = body;
            Cc = new();
        }

        public string Subject { get; init; }
        public string FromAddress { get; init; }
        public string FromName { get; init; }
        public string ToAddress { get; init; }
        public string ToName { get; init; }
        public string Body { get; init; }
        public List<string> Cc { get; init; }
    }
}