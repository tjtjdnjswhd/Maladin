using Maladin.Api.Services;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Validation
{
    public class UserNameAttribute : ValidationAttribute
    {
        public override bool RequiresValidationContext => true;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not string userName)
            {
                return ValidationResult.Success;
            }

            using var scope = validationContext.CreateScope();
            IEntityConfigurationService entityConfiguration = scope.ServiceProvider.GetRequiredService<IEntityConfigurationService>();

            (int minLength, int maxLength) lengthRange = entityConfiguration.GetUserNameLengthRange();
            if (lengthRange == default)
            {
                return ValidationResult.Success;
            }

            return lengthRange.minLength <= userName.Length && userName.Length <= lengthRange.maxLength
                ? ValidationResult.Success
                : new ValidationResult($"User name length must be between {lengthRange.minLength} and {lengthRange.maxLength}", [validationContext.DisplayName]);
        }
    }
}