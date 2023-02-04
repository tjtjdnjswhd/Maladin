namespace Maladin.Data.Models
{
    public class OAuthProvider : EntityBase
    {
        public required string Name { get; set; }

        public List<OAuthId> OAuthIds { get; set; }
    }
}