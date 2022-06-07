using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.Domain.UnitTests.RoverTests
{
    [TestClass]
    public class WhenMovingForward
    {
        [TestMethod]
        public void AndFacingNorthThenTheYIncreaseByOne()
        {
            const int startingY = 0;
            var rover = new Rover(0, startingY, Direction.North);

            rover.MoveForward();

            var expectedRover = new Rover(0, startingY + 1, Direction.North);
            Assert.AreEqual(expectedRover, rover);
        }

        [TestMethod]
        public void AndFacingSouthThenYDecreasesByOne()
        {
            const int startingY = 0;
            var rover = new Rover(0, startingY, Direction.South);

            rover.MoveForward();

            var expectedRover = new Rover(0, startingY - 1, Direction.South);
            Assert.AreEqual(expectedRover, rover);
        }

        [TestMethod]
        public void AndFacingEastThenXIncreasesByOne()
        {
            const int startingX = 0;
            var rover = new Rover(startingX, 0, Direction.East);

            rover.MoveForward();

            var expectedRover = new Rover(startingX + 1, 0, Direction.East);
            Assert.AreEqual(expectedRover, rover);
        }

        [TestMethod]
        public void AndFacingWestThenXDecreasesByOne()
        {
            const int startingX = 0;
            var rover = new Rover(startingX, 0, Direction.West);

            rover.MoveForward();

            var expectedRover = new Rover(startingX - 1, 0, Direction.West);
            Assert.AreEqual(expectedRover, rover);
        }
    }
}
