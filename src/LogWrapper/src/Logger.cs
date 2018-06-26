using System;

namespace TSundvall.DotnetCoreDevExp.LogWrapper
{
    public interface ILogger
    {
        void Log(LogEntry logEntry);
    }


    public enum LoggingEventType { Debug, Information, Warning, Error, Fatal };


    public class LogEntry
    {
        public readonly LoggingEventType Severity;
        public readonly string Message;
        public readonly Exception Exception;


        public LogEntry(
            LoggingEventType severity,
            string message,
            Exception exception = null)
        {
            if (message == null) throw new ArgumentNullException("Log message null");
            if (message == string.Empty) throw new ArgumentException("Log message empty");

            this.Severity = severity;
            this.Message = message;
            this.Exception = exception; 
        }
    }


    public static class LoggerExcensions
    {
        public static void Log(
            this ILogger log,
            LoggingEventType severity,
            string message)
        {
            log.Log(new LogEntry(severity, message, null));
        }


        public static void Debug(
            this ILogger log,
            string message)
        {
            log.Log(new LogEntry(LoggingEventType.Debug, message, null));
        }
    }


    public class SerilogAdapter : ILogger
    {
        private readonly Serilog.ILogger _serilogAdapter;


        public SerilogAdapter(Serilog.ILogger serilogAdapter)
        {
            _serilogAdapter = serilogAdapter;
        }


        public void Log(LogEntry logEntry)
        {
            // if (logEntry.Severity == LoggingEventType.Debug) _serilogAdapter.Debug();
        }
    }
}