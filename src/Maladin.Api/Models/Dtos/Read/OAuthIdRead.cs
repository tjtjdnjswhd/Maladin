namespace Maladin.Api.Models.Dtos.Read
{
    public class OAuthIdRead
    {
        public required int Id { get; set; }

        public required string NameIdentifier { get; set; }

        public required int ProviderId { get; set; }

        public required int UserId { get; set; }
    }
}