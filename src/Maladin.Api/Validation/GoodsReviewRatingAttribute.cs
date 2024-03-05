using Maladin.Api.Helpers;

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

            (int min, int max) range = EntityConfigurationHelper.GetGoodsReviewRatingRange(validationContext.GetRequiredService<IConfiguration>());
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