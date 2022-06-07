using MarsRover.Services.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Reflection;

namespace MarsRover.Services.IntegrationTests.Logger.FileLoggerTests
{
    [TestClass]
    public class WhenLoggingAMessage
    {
        private static ILogger _logger;
        private static string _logLocation;
        
        [ClassInitialize]
        public static void ClassSetup(TestContext ignored)
        {
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _logLocation = directory + "\\log.txt";
            _logger = new FileLogger(_logLocation);
        }
        
        [TestMethod]
        public void AndTheMessageIsNullThenAnExceptionIsThrown()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _logger.Log(null));
        }

        [TestMethod]
        public void AndTheFileDoesntExistThenItsCreated()
        {
            File.Delete(_logLocation);

            _logger.Log("message");

            Assert.IsTrue(File.Exists(_logLocation));
        }

        public void AndTheFileAlreadyHasAMessageThenANewMessageIsAppended()
        {
            File.Delete(_logLocation);

            const string firstMessage = "first message";
            File.WriteAllText(_logLocation, firstMessage);

            const string secondMessage = "second message";
            _logger.Log(secondMessage);

            var expectedContents = $"{firstMessage}{Environment.NewLine}{secondMessage}{Environment.NewLine}";
            var actualContents = File.ReadAllText(_logLocation);
            Assert.AreEqual(expectedContents, actualContents);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            File.Delete(_logLocation);
        }
    }
}
