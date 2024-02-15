namespace Maladin.Api.Extensions
{
    internal static partial class LoggerExtensions
    {
        public const string DbContextQueryExceptionName = "Query exception";
        public const int DbContextQueryExceptionId = 1001;

        public const string DbContextSaveChangesExceptionName = "SavaChange exception";
        public const int DbContextSaveChangesExceptionId = 1002;

        public const string DistributedCacheExceptionName = "Distributed cache exception";
        public const int DistributedCacheExceptionId = 1003;

        [LoggerMessage(EventId = DbContextQueryExceptionId, EventName = DbContextQueryExceptionName, Level = LogLevel.Error)]
        public static partial void LogDbContextQueryException(this ILogger logger, Exception e);

        [LoggerMessage(EventId = DbContextSaveChangesExceptionId, EventName = DbContextSaveChangesExceptionName, Level = LogLevel.Error)]
        public static partial void LogDbContextSaveException(this ILogger logger, Exception e);

        [LoggerMessage(EventId = DistributedCacheExceptionId, EventName = DistributedCacheExceptionName, Level = LogLevel.Error)]
        public static partial void LogDistributedCacheException(this ILogger logger, Exception e);

        [LoggerMessage(Level = LogLevel.Information, Message = "OAuthProvider: {oauthProvider}, NameIdentifier: {nameIdentifier}")]
        public static partial void LogOAuthInfo(this ILogger logger, string? oauthProvider, string? nameIdentifier);
    }
}