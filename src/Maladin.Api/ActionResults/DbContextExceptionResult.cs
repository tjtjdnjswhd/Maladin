using Maladin.Api.Constants;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Maladin.Api.ActionResults
{
    [DefaultStatusCode(DefaultStatusCode)]
    public partial class DbContextExceptionResult(Exception exception) : ActionResult
    {
        private const int DefaultStatusCode = StatusCodes.Status500InternalServerError;

        private readonly Exception _exception = exception;

        public override void ExecuteResult(ActionContext context)
        {
            var loggerFactory = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger<DbContextExceptionResult>();
            Log.DbContextException(logger, _exception);

            context.HttpContext.Response.StatusCode = DefaultStatusCode;
        }

        private static partial class Log
        {
            [LoggerMessage(EventId = LoggerEvent.DbContextExceptionId, EventName = LoggerEvent.DbContextExceptionName, Level = LogLevel.Error)]
            public static partial void DbContextException(ILogger logger, Exception e);
        }
    }
}