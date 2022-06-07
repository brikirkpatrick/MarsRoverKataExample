using MarsRover.Services.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace MarsRover.Services.UnitTests.CommandProcessorTests
{
    [TestClass]
    public class WhenCreatingTheProcessor
    {
        [TestMethod]
        public void AndTheLoggerIsNullThenAnExceptionIsThrown()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new CommandProcessor(null));
        }

        [TestMethod]
        public void ThenTheProcessorIsCreated()
        {
            var logger = new Mock<ILogger>().Object;
            
            var processor = new CommandProcessor(logger);

            Assert.IsNotNull(processor);
        }
    }
}
