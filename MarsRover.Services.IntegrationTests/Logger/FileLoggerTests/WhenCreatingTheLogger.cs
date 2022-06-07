using MarsRover.Services.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Services.IntegrationTests.Logger.FileLoggerTests
{
    [TestClass]
    public class WhenCreatingTheLogger
    {
        [TestMethod]
        public void AndThePathIsNullThenAnExceptionIsThrown()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new FileLogger(null));
        }

        [TestMethod]
        public void AndThePathIsEmptyThenAnExceptionIsThrown()
        {
            Assert.ThrowsException<ArgumentException>(() => new FileLogger(String.Empty));
        }

        [TestMethod]
        public void AndTheDirectoryDoesntExistThenAnExceptionIsThrown()
        {
            const string nonExistentFilePath = @"C:\I'dont_exist\log.txt";
            Assert.ThrowsException<DirectoryNotFoundException>(() => new FileLogger(nonExistentFilePath));
        }

        [TestMethod]
        public void AndTheDirectoryExistsThenTheLoggerIsCreated()
        {
            var executingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var logger = new FileLogger(executingDirectory + "log.txt");

            Assert.IsNotNull(logger);
        }
    }
}
