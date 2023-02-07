namespace Maladin.Data.Models
{
    public sealed class OAuthId : EntityBase
    {
        public required int UserId { get; set; }
        public required int ProivderId { get; set; }
        public required string NameIdentifier { get; set; }

        public User User { get; set; }
        public OAuthProvider OAuthProvider { get; set; }
    }
}