using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Maladin.Api.Models
{
    public record ChallengeInfo : IValidatableObject
    {
        public required string OAuthProviderName { get; init; }

        [JsonConverter(typeof(JsonStringEnumConverter<EChallengeKind>))]
        public required EChallengeKind ChallengeKind { get; init; }

        public string? UserName { get; init; }

        public string? ReturnUrl { get; init; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ChallengeKind == EChallengeKind.Signup && UserName is null)
            {
                yield return new ValidationResult("User name required when signup");
            }
        }
    }
}