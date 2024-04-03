using Maladin.Api.Models.Dtos.Read.Abstractions;
using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json.Serialization;

namespace Maladin.Api.Models.Dtos.Read
{
    public class UserRead : ReadBase
    {
        [UserName]
        public required string Name { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        public required DateTimeOffset SignupAt { get; set; }

        public required IPAddress SignupIp { get; set; }

        public required DateTimeOffset? LastLoginDate { get; set; }

        public required IPAddress? LastLoginIp { get; set; }

        public required bool IsExpired { get; set; }

        public required bool IsLocked { get; set; }

        [EntityId]
        public required int MembershipId { get; set; }

        [JsonIgnore]
        public MembershipRead? Membership { get; private set; }

        [JsonIgnore]
        public List<RoleRead>? Roles { get; private set; }

        [JsonIgnore]
        public List<OAuthIdRead>? OAuthIds { get; private set; }

        [JsonIgnore]
        public List<PointRead>? Points { get; private set; }

        [JsonIgnore]
        public List<UserAddressRead>? Addresses { get; private set; }

        [JsonIgnore]
        public List<OrderSetRead>? Orders { get; private set; }

        [JsonIgnore]
        public List<GoodsCartRead>? Cart { get; private set; }

        [JsonIgnore]
        public List<GoodsReviewRead>? Reviews { get; private set; }
    }
}