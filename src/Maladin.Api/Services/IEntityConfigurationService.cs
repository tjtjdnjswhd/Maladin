namespace Maladin.Api.Services
{
    public interface IEntityConfigurationService
    {
        (int min, int max) GetGoodsReviewRatingRange();
        int GetMaxReadCount(string entityName);
        (int minLength, int maxLength) GetUserNameLengthRange();
    }
}