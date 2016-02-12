using System;
using System.IO;
using System.Runtime.CompilerServices;
using log4net;

namespace AddinX.Logging
{
    public class Log4NetLogger : ILogger
    {
        private readonly ILog log;

        public bool IsDebugEnabled => log.IsDebugEnabled;
        public bool IsErrorEnabled => log.IsErrorEnabled;
        public bool IsFatalEnabled => log.IsFatalEnabled;
        public bool IsInfoEnabled => log.IsInfoEnabled;
        public bool IsWarnEnabled => log.IsWarnEnabled;

        protected internal Log4NetLogger(ILog logger)
        {
            log = logger;
        }

        public Log4NetLogger()
        {
            log = LogManager.GetLogger(typeof(ILogger));
            // read app.config
            log4net.Config.XmlConfigurator.Configure();
        }

        protected internal string FormatCallerMessage(string memberName, string sourceFilePath, int sourceLineNumber)
        {
            const string format = "File: {0,50} Method:{1,40} Line Number {2,4}";
            var fileName = Path.GetFileName(sourceFilePath);
            return string.Format(format, fileName, memberName, sourceLineNumber);
        }

        public void Debug(string message,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsDebugEnabled) return;
            log.Debug(FormatCallerMessage(memberName,sourceFilePath,sourceLineNumber));
            log.Debug(message);
        }

        public void Debug(Func<string> messageFactory,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsDebugEnabled) return;
            log.Debug(FormatCallerMessage(memberName, sourceFilePath, sourceLineNumber));
            log.Debug(messageFactory.Invoke());
        }

        public void Debug(string message, Exception exception,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsDebugEnabled) return;
            log.Debug(FormatCallerMessage(memberName, sourceFilePath, sourceLineNumber));
            log.Debug(message, exception);
        }

        public void DebugFormat(string format, params object[] args)
        {
            if (IsDebugEnabled)
            {
                log.DebugFormat(format, args);
            }
        }

        public void Error(string message,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsErrorEnabled) return;
            log.Error(FormatCallerMessage(memberName, sourceFilePath, sourceLineNumber));
            log.Error(message);
        }

        public void Error(Func<string> messageFactory,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsErrorEnabled) return;
            log.Error(FormatCallerMessage(memberName, sourceFilePath, sourceLineNumber));
            log.Error(messageFactory.Invoke());
        }

        public void Error(string message, Exception exception,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsErrorEnabled) return;
            log.Error(FormatCallerMessage(memberName, sourceFilePath, sourceLineNumber));
            log.Error(message, exception);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            if (IsErrorEnabled)
            {
                log.ErrorFormat(format, args);
            }
        }

        public void Fatal(string message,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsFatalEnabled) return;
            log.Fatal(FormatCallerMessage(memberName, sourceFilePath, sourceLineNumber));
            log.Fatal(message);
        }

        public void Fatal(Func<string> messageFactory,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsFatalEnabled) return;
            log.Fatal(FormatCallerMessage(memberName, sourceFilePath, sourceLineNumber));
            log.Fatal(messageFactory.Invoke());
        }

        public void Fatal(string message, Exception exception,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsFatalEnabled) return;
            log.Fatal(FormatCallerMessage(memberName, sourceFilePath, sourceLineNumber));
            log.Fatal(message, exception);
        }

        public void FatalFormat(string format, params object[] args)
        {
            if (IsFatalEnabled)
            {
                log.FatalFormat(format, args);
            }
        }

        public void Info(string message,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsInfoEnabled) return;
            log.Info(FormatCallerMessage(memberName, sourceFilePath, sourceLineNumber));
            log.Info(message);
        }

        public void Info(Func<string> messageFactory,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsInfoEnabled) return;
            log.Info(FormatCallerMessage(memberName, sourceFilePath, sourceLineNumber));
            log.Info(messageFactory.Invoke());
        }

        public void Info(string message, Exception exception,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsInfoEnabled) return;
            log.Info(FormatCallerMessage(memberName, sourceFilePath, sourceLineNumber));
            log.Info(message, exception);
        }

        public void InfoFormat(string format, params object[] args)
        {
            if (IsInfoEnabled)
            {
                log.InfoFormat(format, args);
            }
        }

        public void Warn(string message,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsWarnEnabled) return;
            log.Warn(FormatCallerMessage(memberName, sourceFilePath, sourceLineNumber));
            log.Warn(message);
        }

        public void Warn(Func<string> messageFactory,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsWarnEnabled) return;
            log.Warn(FormatCallerMessage(memberName, sourceFilePath, sourceLineNumber));
            log.Warn(messageFactory.Invoke());
        }

        public void Warn(string message, Exception exception,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (!IsWarnEnabled) return;
            log.Warn(FormatCallerMessage(memberName, sourceFilePath, sourceLineNumber));
            log.Warn(message, exception);
        }

        public void WarnFormat(string format, params object[] args)
        {
            if (IsWarnEnabled)
            {
                log.WarnFormat(format, args);
            }
        }
    }
}
