namespace Maladin.Api.Models.Dtos.Create
{
    public class UserCreate
    {
        public required string Name { get; set; }

        public required string Email { get; set; }

        public required List<OAuthIdCreate> OAuthIds { get; set; }
    }
}