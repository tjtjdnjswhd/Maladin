using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ExceptionLogger
{
    public class ExceptionLogger<T> : IExceptionLogger<T> where T : class
    {
        public ExceptionLoggerSettings Settings { get; }

        private readonly ILogger<T> _logger;

        public ExceptionLogger(IOptions<ExceptionLoggerSettings> setting, ILogger<T> logger)
        {
            Settings = setting.Value;
            _logger = logger;
        }

        /// <inheritdoc/>
        public void Log(Exception exception)
        {
            string exceptionFullName = exception.GetType().FullName!;
            if (Settings.IgnoreNameList.Contains(exceptionFullName))
            {
                return;
            }

            if (!Settings.LevelByFullName.TryGetValue(exceptionFullName, out LogLevel level))
            {
                level = Settings.Default;
            }

#pragma warning disable CA2254 // 템플릿은 정적 표현식이어야 합니다.
            _logger.Log(level, exception, null);
#pragma warning restore CA2254 // 템플릿은 정적 표현식이어야 합니다.
        }
    }
}