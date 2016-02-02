using System;
using AddinX.Logging;
using log4net;
using Moq;
using NUnit.Framework;

namespace AddIn.Logging.Test
{
    [TestFixture]
    public class Log4NetUnitTest
    {

        private int counterCall;
        private Mock<ILog> logger;
        private Log4NetLogger log;


        [SetUp]
        public void SetUp()
        {
            logger = new Mock<ILog>();
            counterCall = 0;
        }

        [TearDown]
        public void TearDown()
        {
            logger = null;
            log = null;
        }

        [Test]
        public void FormatCaller_Message()
        {
            // Prepare
            const string memberName = "FormatCaller_Message";
            const string sourceFilePath = "Log4NetUnitTest.cs";
            const int sourceLineNumber = 45;
            const string format = "File: {0,50} Method:{1,40}";
            logger.SetupGet(o => o.IsDebugEnabled).Returns(() => true);
            log = new Log4NetLogger(logger.Object);

            // Act
            var result = log.FormatCallerMessage(memberName,sourceFilePath,sourceLineNumber);

            // Assert
            Assert.That(result.Contains(string.Format(format,sourceFilePath,memberName)));
        }


        [Test]
        public void Debug_MessageOnly()
        {
            // Prepare
            const string message = "Simple Message";
            logger.SetupGet(o => o.IsDebugEnabled).Returns(() => true);
            logger.Setup(o => o.Debug(message)).Verifiable();
            log = new Log4NetLogger(logger.Object);

            // Act
            log.Debug(message);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Debug_NoMessage()
        {
            // Prepare
            const string message = "Simple Message";
            logger.SetupGet(o => o.IsDebugEnabled).Returns(() => false);
            logger.Setup(o => o.Debug(message)).Callback(() => counterCall++);
            log = new Log4NetLogger(logger.Object);

            // Act
            log.Debug(message);

            // Assert
            Assert.AreEqual(counterCall, 0);
        }

        [Test]
        public void Debug_LambdaMessage()
        {
            // Prepare
            const string message = "Simple Message";
            logger.SetupGet(o => o.IsDebugEnabled).Returns(() => true);
            logger.Setup(o => o.Debug(message)).Verifiable();
            log = new Log4NetLogger(logger.Object);

            // Act
            log.Debug(() => message);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Debug_MessageWithException()
        {
            // Prepare
            const string message = "Exception occurred";
            var ex = new Exception(message);
            logger.SetupGet(o => o.IsDebugEnabled).Returns(() => true);
            logger.Setup(o => o.Debug(message, ex)).Verifiable();
            log = new Log4NetLogger(logger.Object);

            // Act
            log.Debug(message, ex);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Debug_FormatMessage()
        {
            // Prepare
            const string format = "Number of Call: {0} occurred";
            logger.SetupGet(o => o.IsDebugEnabled).Returns(() => true);
            logger.Setup(o => o.DebugFormat(format, new object[] { 1 })).Verifiable();
            log = new Log4NetLogger(logger.Object);

            // Act
            log.DebugFormat(format, 1);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Error_MessageOnly()
        {
            // Prepare
            const string message = "Simple Message";
            logger.SetupGet(o => o.IsErrorEnabled).Returns(() => true);
            logger.Setup(o => o.Error(message)).Verifiable();
            log = new Log4NetLogger(logger.Object);

            // Act
            log.Error(message);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Error_NoMessage()
        {
            // Prepare
            const string message = "Simple Message";
            logger.SetupGet(o => o.IsErrorEnabled).Returns(() => false);
            logger.Setup(o => o.Error(message)).Callback(() => counterCall++).Verifiable();
            log = new Log4NetLogger(logger.Object);

            // Act
            log.Error(message);

            // Assert
            Assert.AreEqual(counterCall, 0);
        }

        [Test]
        public void Error_LambdaMessage()
        {
            // Prepare
            const string message = "Simple Message";
            logger.SetupGet(o => o.IsErrorEnabled).Returns(() => true);
            logger.Setup(o => o.Error(message)).Verifiable();
            log = new Log4NetLogger(logger.Object);

            // Act
            log.Error(() => message);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Error_MessageWithException()
        {
            // Prepare
            const string message = "Exception occurred";
            var ex = new Exception(message);
            logger.SetupGet(o => o.IsErrorEnabled).Returns(() => true);
            logger.Setup(o => o.Error(message, ex)).Verifiable();
            log = new Log4NetLogger(logger.Object);

            // Act
            log.Error(message, ex);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Error_FormatMessage()
        {
            // Prepare
            const string format = "Number of Call: {0} occurred";
            logger.SetupGet(o => o.IsErrorEnabled).Returns(() => true);
            logger.Setup(o => o.ErrorFormat(format, new object[] { 1 })).Verifiable();
            log = new Log4NetLogger(logger.Object);

            // Act
            log.ErrorFormat(format, 1);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Fatal_MessageOnly()
        {
            // Prepare
            const string message = "Simple Message";
            logger.SetupGet(o => o.IsFatalEnabled).Returns(() => true);
            logger.Setup(o => o.Fatal(message)).Verifiable();
            log = new Log4NetLogger(logger.Object);

            // Act
            log.Fatal(message);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Fatal_NoMessage()
        {
            // Prepare
            const string message = "Simple Message";
            logger.SetupGet(o => o.IsFatalEnabled).Returns(() => false);
            logger.Setup(o => o.Fatal(message)).Callback(() => counterCall++).Verifiable();
            log = new Log4NetLogger(logger.Object);

            // Act
            log.Fatal(message);

            // Assert
            Assert.AreEqual(counterCall, 0);
        }

        [Test]
        public void Fatal_LambdaMessage()
        {
            // Prepare
            const string message = "Simple Message";
            logger.SetupGet(o => o.IsFatalEnabled).Returns(() => true);
            logger.Setup(o => o.Fatal(message)).Verifiable();
            log = new Log4NetLogger(logger.Object);

            // Act
            log.Fatal(() => message);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Fatal_MessageWithException()
        {
            // Prepare
            const string message = "Exception occurred";
            var ex = new Exception(message);
            logger.SetupGet(o => o.IsFatalEnabled).Returns(() => true);
            logger.Setup(o => o.Fatal(message, ex)).Verifiable();
            log = new Log4NetLogger(logger.Object);

            // Act
            log.Fatal(message, ex);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Fatal_FormatMessage()
        {
            // Prepare
            const string format = "Number of Call: {0} occurred";
            logger.SetupGet(o => o.IsFatalEnabled).Returns(() => true);
            logger.Setup(o => o.FatalFormat(format, new object[] { 1 })).Verifiable();
            log = new Log4NetLogger(logger.Object);

            // Act
            log.FatalFormat(format, 1);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Info_MessageOnly()
        {
            // Prepare
            const string message = "Simple Info";
            logger.SetupGet(o => o.IsInfoEnabled).Returns(() => true);
            logger.Setup(o => o.Info(message)).Verifiable();
            log = new Log4NetLogger(logger.Object);

            // Act
            log.Info(message);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Info_NoMessage()
        {
            // Prepare
            const string message = "Simple Info";
            logger.SetupGet(o => o.IsInfoEnabled).Returns(() => false);
            logger.Setup(o => o.Info(message)).Callback(() => counterCall++).Verifiable();
            log = new Log4NetLogger(logger.Object);

            // Act
            log.Info(message);

            // Assert
            Assert.AreEqual(counterCall, 0);
        }

        [Test]
        public void Info_LambdaMessage()
        {
            // Prepare
            const string message = "Simple Info";
            logger.SetupGet(o => o.IsInfoEnabled).Returns(() => true);
            logger.Setup(o => o.Info(message)).Verifiable();
            log = new Log4NetLogger(logger.Object);

            // Act
            log.Info(() => message);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Info_MessageWithException()
        {
            // Prepare
            const string message = "Exception occurred";
            var ex = new Exception(message);
            logger.SetupGet(o => o.IsInfoEnabled).Returns(() => true);
            logger.Setup(o => o.Info(message, ex)).Verifiable();
            log = new Log4NetLogger(logger.Object);

            // Act
            log.Info(message, ex);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Info_FormatMessage()
        {
            // Prepare
            const string format = "Number of Call: {0} occurred";
            logger.SetupGet(o => o.IsInfoEnabled).Returns(() => true);
            logger.Setup(o => o.InfoFormat(format, new object[] { 1 })).Verifiable();
            log = new Log4NetLogger(logger.Object);

            // Act
            log.InfoFormat(format, 1);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Warn_MessageOnly()
        {
            // Prepare
            const string message = "Simple Warn";
            logger.SetupGet(o => o.IsWarnEnabled).Returns(() => true);
            logger.Setup(o => o.Warn(message)).Verifiable();
            log = new Log4NetLogger(logger.Object);

            // Act
            log.Warn(message);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Warn_NoMessage()
        {
            // Prepare
            const string message = "Simple Warn";
            logger.SetupGet(o => o.IsWarnEnabled).Returns(() => false);
            logger.Setup(o => o.Warn(message)).Callback(() => counterCall++).Verifiable();
            log = new Log4NetLogger(logger.Object);

            // Act
            log.Warn(message);

            // Assert
            Assert.AreEqual(counterCall, 0);
        }

        [Test]
        public void Warn_LambdaMessage()
        {
            // Prepare
            const string message = "Simple Warn";
            logger.SetupGet(o => o.IsWarnEnabled).Returns(() => true);
            logger.Setup(o => o.Warn(message)).Verifiable();
            log = new Log4NetLogger(logger.Object);

            // Act
            log.Warn(() => message);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Warn_MessageWithException()
        {
            // Prepare
            const string message = "Exception occurred";
            var ex = new Exception(message);
            logger.SetupGet(o => o.IsWarnEnabled).Returns(() => true);
            logger.Setup(o => o.Warn(message, ex)).Verifiable();
            log = new Log4NetLogger(logger.Object);

            // Act
            log.Warn(message, ex);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Warn_FormatMessage()
        {
            // Prepare
            const string format = "Number of Call: {0} occurred";
            logger.SetupGet(o => o.IsWarnEnabled).Returns(() => true);
            logger.Setup(o => o.WarnFormat(format, new object[] { 1 })).Verifiable();
            log = new Log4NetLogger(logger.Object);

            // Act
            log.WarnFormat(format, 1);

            // Assert
            logger.VerifyAll();
        }

    }
}
