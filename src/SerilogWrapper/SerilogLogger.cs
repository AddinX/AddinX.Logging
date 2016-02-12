using System;
using System.IO;
using System.Runtime.CompilerServices;
using Serilog;
using Serilog.Events;

namespace AddinX.Logging
{
    /// <summary>
    /// This Serilog wrapper implements the <see cref = "ILogger" /> interface
    /// </summary>
    public class SerilogLogger : ILogger
    {
        private readonly Serilog.ILogger log;

        public bool IsDebugEnabled => log.IsEnabled(LogEventLevel.Debug);
        public bool IsErrorEnabled => log.IsEnabled(LogEventLevel.Error);
        public bool IsFatalEnabled => log.IsEnabled(LogEventLevel.Fatal);
        public bool IsInfoEnabled => log.IsEnabled(LogEventLevel.Information);
        public bool IsWarnEnabled => log.IsEnabled(LogEventLevel.Warning);

        public SerilogLogger(Serilog.ILogger logger)
        {
            log = logger;
        }

        public SerilogLogger()
        {
            // read configuration
            log = new LoggerConfiguration()
                .ReadFrom.AppSettings()
                .CreateLogger();
        }

        protected internal void FormatCallerMessage(LogEventLevel level, string memberName, string sourceFilePath, int sourceLineNumber)
        {
            const string callerMessageFormat = "File: {SourceFileName} \t Method:{MethodName} \t Line Number {SourceLineNumber}";
            var fileName = Path.GetFileName(sourceFilePath);
            log.Write(level, callerMessageFormat, fileName, memberName, sourceLineNumber);
        }

        public void Debug(string message,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsDebugEnabled) return;
            FormatCallerMessage(LogEventLevel.Debug, memberName, sourceFilePath, sourceLineNumber);
            log.Write(LogEventLevel.Debug, message, null);
        }

        public void Debug(Func<string> messageFactory,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsDebugEnabled) return;
            FormatCallerMessage(LogEventLevel.Debug, memberName, sourceFilePath, sourceLineNumber);
            log.Write(LogEventLevel.Debug, messageFactory.Invoke(), null);
        }

        public void Debug(string message, Exception exception,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsDebugEnabled) return;
            FormatCallerMessage(LogEventLevel.Debug, memberName, sourceFilePath, sourceLineNumber);
            log.Write(LogEventLevel.Debug, exception, message, null);
        }

        public void DebugFormat(string format, params object[] args)
        {
            if (IsDebugEnabled)
            {
                log.Write(LogEventLevel.Debug, format, args);
            }
        }

        public void Error(string message,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsErrorEnabled) return;
            FormatCallerMessage(LogEventLevel.Error, memberName, sourceFilePath, sourceLineNumber);
            log.Write(LogEventLevel.Error, message, null);
        }

        public void Error(Func<string> messageFactory,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsErrorEnabled) return;
            FormatCallerMessage(LogEventLevel.Error, memberName, sourceFilePath, sourceLineNumber);
            log.Write(LogEventLevel.Error, messageFactory.Invoke(), null);
        }

        public void Error(string message, Exception exception,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsErrorEnabled) return;
            FormatCallerMessage(LogEventLevel.Error, memberName, sourceFilePath, sourceLineNumber);
            log.Write(LogEventLevel.Error, exception, message, null);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            if (IsErrorEnabled)
            {
                log.Write(LogEventLevel.Error, format, args);

            }
        }

        public void Fatal(string message,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsFatalEnabled) return;
            FormatCallerMessage(LogEventLevel.Fatal, memberName, sourceFilePath, sourceLineNumber);
            log.Write(LogEventLevel.Fatal, message, null);
        }

        public void Fatal(Func<string> messageFactory,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsFatalEnabled) return;
            FormatCallerMessage(LogEventLevel.Fatal, memberName, sourceFilePath, sourceLineNumber);
            log.Write(LogEventLevel.Fatal, messageFactory.Invoke(), null);
        }

        public void Fatal(string message, Exception exception,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsFatalEnabled) return;
            FormatCallerMessage(LogEventLevel.Fatal, memberName, sourceFilePath, sourceLineNumber);
            log.Write(LogEventLevel.Fatal, exception, message, null);
        }

        public void FatalFormat(string format, params object[] args)
        {
            if (IsFatalEnabled)
            {
                log.Write(LogEventLevel.Fatal, format, args);
            }
        }

        public void Info(string message,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsInfoEnabled) return;
            FormatCallerMessage(LogEventLevel.Information, memberName, sourceFilePath, sourceLineNumber);
            log.Write(LogEventLevel.Information, message, null);
        }

        public void Info(Func<string> messageFactory,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsInfoEnabled) return;
            FormatCallerMessage(LogEventLevel.Information, memberName, sourceFilePath, sourceLineNumber);
            log.Write(LogEventLevel.Information, messageFactory.Invoke(), null);
        }

        public void Info(string message, Exception exception,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsInfoEnabled) return;
            FormatCallerMessage(LogEventLevel.Information, memberName, sourceFilePath, sourceLineNumber);
            log.Write(LogEventLevel.Information, exception, message, null);
        }

        public void InfoFormat(string format, params object[] args)
        {
            if (IsInfoEnabled)
            {
                log.Write(LogEventLevel.Information, format, args);
            }
        }

        public void Warn(string message,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsWarnEnabled) return;
            FormatCallerMessage(LogEventLevel.Warning, memberName, sourceFilePath, sourceLineNumber);
            log.Write(LogEventLevel.Warning, message, null);
        }

        public void Warn(Func<string> messageFactory,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsWarnEnabled) return;
            FormatCallerMessage(LogEventLevel.Warning, memberName, sourceFilePath, sourceLineNumber);
            log.Write(LogEventLevel.Warning, messageFactory.Invoke(), null);
        }

        public void Warn(string message, Exception exception,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsWarnEnabled) return;
            FormatCallerMessage(LogEventLevel.Warning, memberName, sourceFilePath, sourceLineNumber);
            log.Write(LogEventLevel.Warning, exception, message, null);
        }

        public void WarnFormat(string format, params object[] args)
        {
            if (IsWarnEnabled)
            {
                log.Write(LogEventLevel.Warning, format, args);
            }
        }
    }
}
