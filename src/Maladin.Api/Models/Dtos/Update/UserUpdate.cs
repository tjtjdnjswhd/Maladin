using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Maladin.Api.Models.Dtos.Update
{
    public class UserUpdate
    {
        [UserName]
        public required string Name { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        public DateTimeOffset? LastLoginDate { get; set; }

        public IPAddress? LastLoginIp { get; set; }

        public required bool IsExpired { get; set; }

        public required bool IsLocked { get; set; }

        [EntityId]
        public required int MembershipId { get; set; }
    }
}