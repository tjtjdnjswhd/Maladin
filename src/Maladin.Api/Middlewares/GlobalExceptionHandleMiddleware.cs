namespace Maladin.Api.Middlewares
{
    public class GlobalExceptionHandleMiddleware(RequestDelegate next, Action<HttpContext, Exception> contextAction, IEnumerable<Action<ILogger, Exception>> loggerActions)
    {
        private readonly RequestDelegate _next = next;
        private readonly Action<HttpContext, Exception> _contextAction = contextAction;
        private readonly IEnumerable<Action<ILogger, Exception>> _loggerActions = loggerActions;

        public async Task InvokeAsync(HttpContext httpContext, ILogger<GlobalExceptionHandleMiddleware> logger)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                foreach (var loggerAction in _loggerActions)
                {
                    loggerAction.Invoke(logger, e);
                }
                _contextAction.Invoke(httpContext, e);
            }
        }
    }
}