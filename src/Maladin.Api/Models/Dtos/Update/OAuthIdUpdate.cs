namespace Maladin.Api.Models.Dtos.Update
{
    public class OAuthIdUpdate
    {
        public required string NameIdentifier { get; set; }

        public required int ProviderId { get; set; }

        public required int UserId { get; set; }
    }
}