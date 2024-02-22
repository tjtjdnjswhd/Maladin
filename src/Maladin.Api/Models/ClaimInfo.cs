namespace Maladin.Api.Models
{
    internal class ClaimInfo
    {
        public required int UserId { get; init; }

        public required string UserName { get; init; }

        public required string UserEmail { get; init; }

        public required IEnumerable<string> RoleNames { get; init; }
    }
}