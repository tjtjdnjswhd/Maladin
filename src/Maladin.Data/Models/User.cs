namespace Maladin.Data.Models
{
    public sealed class User : EntityBase
    {
        public required int RoleId { get; set; }
        public required int MembershipId { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
#nullable enable
        public string? PasswordHash { get; set; }
        public required DateTimeOffset SignupAt { get; set; }
        public required string SignupIp { get; set; }
        public DateTimeOffset? UpdateAt { get; set; }
        public string? UpdateIp { get; set; }
        public DateTimeOffset? LastLoginDate { get; set; }
        public string? LastLoginIp { get; set; }
#nullable restore
        public required bool IsExpired { get; set; }
        public required bool IsLocked { get; set; }
        public required bool IsEmailAuthenticated { get; set; }
        public required bool IsOAuth { get; set; }

        public Role Role { get; set; }
        public Membership Membership { get; set; }
        public List<OAuthId> OauthIds { get; set; }
        public List<Point> Points { get; set; }
        public List<UserAddress> Addresses { get; set; }
        public List<Order> Orders { get; set; }
        public List<BookBox> BookBoxes { get; set; }
        public List<BookReview> BookReviews { get; set; }
    }
}