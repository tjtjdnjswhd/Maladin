namespace Maladin.Api.Extensions
{
    internal static partial class LoggerExtensions
    {
        public const string DbContextExceptionName = "DbContext exception";
        public const int DbContextExceptionId = 1001;

        public const string DistributedCacheExceptionName = "Distributed cache exception";
        public const int DistributedCacheExceptionId = 1002;

        [LoggerMessage(EventId = DbContextExceptionId, EventName = DbContextExceptionName, Level = LogLevel.Error)]
        public static partial void LogDbContextException(this ILogger logger, Exception e);

        [LoggerMessage(EventId = DistributedCacheExceptionId, EventName = DistributedCacheExceptionName, Level = LogLevel.Error)]
        public static partial void LogDistributedCacheException(this ILogger logger, Exception e);

        [LoggerMessage(Level = LogLevel.Information, Message = "OAuthProviderName: {oauthProvider}, NameIdentifier: {nameIdentifier}")]
        public static partial void LogOAuthInfo(this ILogger logger, string? oauthProvider, string? nameIdentifier);
    }
}