namespace Maladin.Api.Services
{
    public class EntityConfigurationService(IConfiguration configuration) : IEntityConfigurationService
    {
        private readonly IConfigurationSection _configuration = configuration.GetRequiredSection("Entity");

        public int GetMaxReadCount(string entityName)
        {
            if (_configuration.GetValue($"{entityName}:MaxReadCount", 0) is int value and not 0)
            {
                return value;
            }

            return _configuration.GetValue<int>("Default:MaxReadCount");
        }

        public (int minLength, int maxLength) GetUserNameLengthRange()
        {
            var userNameLengthSection = _configuration.GetSection("User:Property:Name:Length");
            if (!userNameLengthSection.Exists())
            {
                return default;
            }

            int minLength = userNameLengthSection.GetValue<int>("Min");
            int maxLength = userNameLengthSection.GetValue<int>("Max");
            return (minLength, maxLength);
        }

        public (int min, int max) GetGoodsReviewRatingRange()
        {
            IConfigurationSection ratingSection = _configuration.GetSection("GoodsReview:Property:Rating");
            if (!ratingSection.Exists())
            {
                return default;
            }

            int min = ratingSection.GetValue<int>("Min");
            int max = ratingSection.GetValue<int>("Max");
            return (min, max);
        }
    }
}