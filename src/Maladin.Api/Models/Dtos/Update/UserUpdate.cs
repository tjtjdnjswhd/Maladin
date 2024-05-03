using Maladin.Api.Validation;

namespace Maladin.Api.Models.Dtos.Update
{
    public class UserUpdate
    {
        public required bool IsExpired { get; set; }

        public required bool IsLocked { get; set; }

        [EntityId]
        public required int MembershipId { get; set; }
    }
}