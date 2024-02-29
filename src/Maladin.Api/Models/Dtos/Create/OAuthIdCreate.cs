namespace Maladin.Api.Models.Dtos.Create
{
    public class OAuthIdCreate
    {
        public required string NameIdentifier { get; set; }

        public required string ProviderId { get; set; }

        public required string UserId { get; set; }
    }
}