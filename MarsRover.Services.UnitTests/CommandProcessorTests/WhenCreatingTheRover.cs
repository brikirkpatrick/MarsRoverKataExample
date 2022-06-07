using MarsRover.Domain;
using MarsRover.Services.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MarsRover.Services.UnitTests.CommandProcessorTests
{
    [TestClass]
    public class WhenCreatingTheRover
    {
        [TestMethod]
        public void ThenTheRoverIsAt0_0_FacingNorth()
        {
            var logger = new Mock<ILogger>().Object;
            var processor = new CommandProcessor(logger);

            var rover = processor.Create();

            var expectedRover = new Rover(0, 0, Direction.North);
            Assert.AreEqual(expectedRover, rover);
        }
    }
}
