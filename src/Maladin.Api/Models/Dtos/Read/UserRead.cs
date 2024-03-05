using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Maladin.Api.Models.Dtos.Read
{
    public class UserRead
    {
        [EntityId]
        public required int Id { get; set; }

        [UserName]
        public required string Name { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        public required DateTimeOffset SignupAt { get; set; }

        public required IPAddress SignupIp { get; set; }

        public DateTimeOffset? LastLoginDate { get; set; }

        public IPAddress? LastLoginIp { get; set; }

        public required bool IsExpired { get; set; }

        public required bool IsLocked { get; set; }

        [EntityId]
        public required int MembershipId { get; set; }
    }
}