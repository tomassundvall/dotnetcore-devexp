using System;
using Microsoft.Extensions.Logging;

namespace TSundvall.DotnetCoreDevExp.LogWrapper
{
    public interface ILoggerAdapter<T>
    {
        void LogDebug(string message);
        void LogDebug(string message, params object[] args);
    }


    public class LoggerAdapter<T> : ILoggerAdapter<T>
    {
        private readonly ILogger<T> _log;


        public LoggerAdapter(ILogger<T> log)
        {
            _log = log;
        }


        public void LogDebug(string message)
        {
            _log.LogDebug(message);
        }


        public void LogDebug(string message, params object[] args)
        {
            _log.LogDebug(message, args);
        }
    }
}