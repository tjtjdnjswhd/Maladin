namespace Maladin.Api.Helpers
{
    public static class EntityConfigurationHelper
    {
        public const string EntitySectionName = "Entity";

        /// <summary>
        /// Get entity configuration section. throw exception if not exist
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns>Entity section</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static IConfigurationSection GetEntitySection(IConfiguration configuration) => configuration.GetRequiredSection(EntitySectionName);

        /// <summary>
        /// Get default maxReadCount. return 0 if not exist
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static int GetMaxReadCount(IConfiguration configuration)
        {
            return GetEntitySection(configuration).GetValue("Default:MaxReadCount", 0);
        }

        /// <summary>
        /// Get maxReadCount. return 0 if not exist
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public static int GetMaxReadCount(IConfiguration configuration, string entityName)
        {
            return GetEntitySection(configuration).GetValue($"{entityName}:MaxReadCount", 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns>If not exist, return default</returns>
        public static (int minLength, int maxLength) GetUserNameLengthRange(IConfiguration configuration)
        {
            IConfigurationSection nameSection = GetEntitySection(configuration).GetSection("User:Property:Name:Length");
            if (!nameSection.Exists())
            {
                return default;
            }

            int minLength = nameSection.GetValue<int>("Min");
            int maxLength = nameSection.GetValue<int>("Max");
            return (minLength, maxLength);
        }

        public static (int min, int max) GetGoodsReviewRatingRange(IConfiguration configuration)
        {
            IConfigurationSection ratingSection = GetEntitySection(configuration).GetSection("GoodsReview:Property:Rating");
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