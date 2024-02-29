using System.Net;

namespace Maladin.Api.Models.Dtos.Update
{
    public class UserUpdate
    {
        public required string Name { get; set; }

        public required string Email { get; set; }

        public DateTimeOffset? LastLoginDate { get; set; }

        public IPAddress? LastLoginIp { get; set; }

        public required bool IsExpired { get; set; }

        public required bool IsLocked { get; set; }

        public required int MembershipId { get; set; }
    }
}