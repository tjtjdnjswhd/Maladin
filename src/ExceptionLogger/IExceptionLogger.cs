namespace ExceptionLogger
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T">예외 발생한 클래스</typeparam>
    public interface IExceptionLogger<T> where T : class
    {
        /// <summary>
        /// 로깅 설정
        /// </summary>
        public ExceptionLoggerSettings Settings { get; }

        /// <summary>
        /// <see cref="Settings"/>에 따라 예외를 로깅합니다
        /// </summary>
        /// <param name="exception"></param>
        public void Log(Exception exception);
    }
}