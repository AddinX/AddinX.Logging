using System;
using AddinX.Logging;
using Moq;
using NUnit.Framework;
using Serilog.Events;

namespace AddIn.Logging.Test
{
    [TestFixture]
    public class SerilogUnitTest
    {   
        private Mock<Serilog.ILogger> logger;
        private SerilogLogger log;


        [SetUp]
        public void SetUp()
        {
            logger = new Mock<Serilog.ILogger>();
            logger.Setup(l => l.IsEnabled(
                    It.IsAny<LogEventLevel>()))
                    .Returns(true);
        }

        [TearDown]
        public void TearDown()
        {
            logger = null;
            log = null;
        }

        [Test]
        public void Debug_MessageOnly()
        {
            // Prepare
            const string message = "Simple Message";
            logger.Setup(l => l.Write(
                       LogEventLevel.Debug,message,null))
                    .Verifiable();
            log = new SerilogLogger(logger.Object);

            // Act
            log.Debug(message);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Debug_LambdaMessage()
        {
            // Prepare
            const string message = "Simple Message";
            logger.Setup(l => l.Write(
                       LogEventLevel.Debug, message, null))
                    .Verifiable();
            log = new SerilogLogger(logger.Object);

            // Act
            log.Debug(message);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Debug_MessageWithException()
        {
            // Prepare
            const string message = "Exception occurred";
            var ex = new Exception(message);
            logger.Setup(l => l.Write(
                       LogEventLevel.Debug,ex, message, null))
                    .Verifiable();
            log = new SerilogLogger(logger.Object);

            // Act
            log.Debug(message,ex);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Debug_FormatMessage()
        {
            // Prepare
            const string format = "Number of Call: {0} occurred";
            logger.Setup(l => l.Write(
                       LogEventLevel.Debug, format, 1))
                    .Verifiable();
            log = new SerilogLogger(logger.Object);

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
            logger.Setup(l => l.Write(
                       LogEventLevel.Error, message, null))
                    .Verifiable();
            log = new SerilogLogger(logger.Object);

            // Act
            log.Error(message);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Error_LambdaMessage()
        {
            // Prepare
            const string message = "Simple Message";
            logger.Setup(l => l.Write(
                       LogEventLevel.Error, message, null))
                    .Verifiable();
            log = new SerilogLogger(logger.Object);

            // Act
            log.Error(message);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Error_MessageWithException()
        {
            // Prepare
            const string message = "Exception occurred";
            var ex = new Exception(message);
            logger.Setup(l => l.Write(
                       LogEventLevel.Error, ex, message, null))
                    .Verifiable();
            log = new SerilogLogger(logger.Object);

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
            logger.Setup(l => l.Write(
                       LogEventLevel.Error, format, 1))
                    .Verifiable();
            log = new SerilogLogger(logger.Object);

            // Act
            log.ErrorFormat(format, 1);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Info_MessageOnly()
        {
            // Prepare
            const string message = "Simple Message";
            logger.Setup(l => l.Write(
                       LogEventLevel.Information, message, null))
                    .Verifiable();
            log = new SerilogLogger(logger.Object);

            // Act
            log.Info(message);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Info_LambdaMessage()
        {
            // Prepare
            const string message = "Simple Message";
            logger.Setup(l => l.Write(
                       LogEventLevel.Information, message, null))
                    .Verifiable();
            log = new SerilogLogger(logger.Object);

            // Act
            log.Info(message);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Info_MessageWithException()
        {
            // Prepare
            const string message = "Exception occurred";
            var ex = new Exception(message);
            logger.Setup(l => l.Write(
                       LogEventLevel.Information, ex, message, null))
                    .Verifiable();
            log = new SerilogLogger(logger.Object);

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
            logger.Setup(l => l.Write(
                       LogEventLevel.Information, format, 1))
                    .Verifiable();
            log = new SerilogLogger(logger.Object);

            // Act
            log.InfoFormat(format, 1);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Fatal_MessageOnly()
        {
            // Prepare
            const string message = "Simple Message";
            logger.Setup(l => l.Write(
                       LogEventLevel.Fatal, message, null))
                    .Verifiable();
            log = new SerilogLogger(logger.Object);

            // Act
            log.Fatal(message);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Fatal_LambdaMessage()
        {
            // Prepare
            const string message = "Simple Message";
            logger.Setup(l => l.Write(
                       LogEventLevel.Fatal, message, null))
                    .Verifiable();
            log = new SerilogLogger(logger.Object);

            // Act
            log.Fatal(message);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Fatal_MessageWithException()
        {
            // Prepare
            const string message = "Exception occurred";
            var ex = new Exception(message);
            logger.Setup(l => l.Write(
                       LogEventLevel.Fatal, ex, message, null))
                    .Verifiable();
            log = new SerilogLogger(logger.Object);

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
            logger.Setup(l => l.Write(
                       LogEventLevel.Fatal, format, 1))
                    .Verifiable();
            log = new SerilogLogger(logger.Object);

            // Act
            log.FatalFormat(format, 1);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Warn_MessageOnly()
        {
            // Prepare
            const string message = "Simple Message";
            logger.Setup(l => l.Write(
                       LogEventLevel.Warning, message, null))
                    .Verifiable();
            log = new SerilogLogger(logger.Object);

            // Act
            log.Warn(message);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Warn_LambdaMessage()
        {
            // Prepare
            const string message = "Simple Message";
            logger.Setup(l => l.Write(
                       LogEventLevel.Warning, message, null))
                    .Verifiable();
            log = new SerilogLogger(logger.Object);

            // Act
            log.Warn(message);

            // Assert
            logger.VerifyAll();
        }

        [Test]
        public void Warn_MessageWithException()
        {
            // Prepare
            const string message = "Exception occurred";
            var ex = new Exception(message);
            logger.Setup(l => l.Write(
                       LogEventLevel.Warning, ex, message, null))
                    .Verifiable();
            log = new SerilogLogger(logger.Object);

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
            logger.Setup(l => l.Write(
                       LogEventLevel.Warning, format, 1))
                    .Verifiable();
            log = new SerilogLogger(logger.Object);

            // Act
            log.WarnFormat(format, 1);

            // Assert
            logger.VerifyAll();
        }
    }
}
