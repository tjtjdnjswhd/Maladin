namespace Maladin.Service.Models
{
    public class PortoneAccessTokenRequest
    {
        public PortoneAccessTokenRequest(string impKey, string impSecret)
        {
            ImpKey = impKey;
            ImpSecret = impSecret;
        }

        public string ImpKey { get; set; }
        public string ImpSecret { get; set; }
    }
}
