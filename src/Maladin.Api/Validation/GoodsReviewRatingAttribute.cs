using Maladin.Api.Services;

using System.ComponentModel.DataAnnotations;

namespace Maladin.Api.Validation
{
    public class GoodsReviewRatingAttribute : ValidationAttribute
    {
        public override bool RequiresValidationContext => true;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not int rating)
            {
                return ValidationResult.Success;
            }

            using var scope = validationContext.CreateScope();
            IEntityConfigurationService entityConfiguration = scope.ServiceProvider.GetRequiredService<IEntityConfigurationService>();

            (int min, int max) range = entityConfiguration.GetGoodsReviewRatingRange();
            if (range == default)
            {
                return ValidationResult.Success;
            }

            return range.min <= rating && rating >= range.max
                ? ValidationResult.Success
                : new ValidationResult($"Rating must be between {range.min} and {range.max}", [validationContext.DisplayName]);
        }
    }
}