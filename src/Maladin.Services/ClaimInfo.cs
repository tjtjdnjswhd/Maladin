namespace Maladin.Services
{
    public class ClaimInfo(int userId, string userName, string userEmail, IEnumerable<string> roles, string issuer, string audience)
    {
        public int UserId { get; } = userId;

        public string UserName { get; } = userName;

        public string UserEmail { get; } = userEmail;

        public IEnumerable<string> Roles { get; } = roles;

        public string Issuer { get; } = issuer;

        public string Audience { get; } = audience;
    }
}