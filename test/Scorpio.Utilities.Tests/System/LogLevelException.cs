using Microsoft.Extensions.Logging;

using Scorpio.Logging;

namespace System
{
    public class LogLevelException : Exception, IHasLogLevel
    {
        public LogLevelException()
        {
        }
        public LogLevelException(LogLevel logLevel) => LogLevel = logLevel;

        public LogLevelException(string message) : base(message)
        {
        }
        public LogLevelException(string message, LogLevel logLevel) : base(message) => LogLevel = logLevel;

        public LogLevelException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public LogLevelException(string message, Exception innerException, LogLevel logLevel) : base(message, innerException) => LogLevel = logLevel;

#if !NET8_0_OR_GREATER
        protected LogLevelException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
#endif   

        public LogLevel LogLevel { get; set; }
    }
}