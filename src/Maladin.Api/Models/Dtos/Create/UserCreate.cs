using Maladin.Api.Validation;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Models.Dtos.Create
{
    public class UserCreate : IValidatableObject
    {
        [UserName]
        public required string Name { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        public required List<OAuthIdCreate> OAuthIds { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (OAuthIds.Count == 0)
            {
                yield return new ValidationResult("OAuthId need at least one");
            }
        }
    }
}