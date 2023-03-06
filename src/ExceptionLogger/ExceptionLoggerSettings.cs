using Microsoft.Extensions.Logging;

namespace ExceptionLogger
{
    /// <summary>
    /// <seealso cref="IExceptionLogger{T}"/>의 설정
    /// </summary>
    public sealed class ExceptionLoggerSettings
    {
        /// <summary>
        /// 기본 LogLevel
        /// </summary>
        public LogLevel Default { get; }

        /// <summary>
        /// 로깅하지 않을 예외의 <see cref="Type.FullName"/> 목록
        /// </summary>
        public List<string> IgnoreNameList { get; }

        /// <summary>
        /// 각 예외의 LogLevel.
        /// Key: <see cref="Type.FullName"/>
        /// </summary>
        public Dictionary<string, LogLevel> LevelByFullName { get; }

        public ExceptionLoggerSettings(LogLevel @default, List<string> ignoreList, Dictionary<string, LogLevel> levelByExceptionFullName)
        {
            Default = @default;
            IgnoreNameList = ignoreList;
            LevelByFullName = levelByExceptionFullName;
        }
    }
}