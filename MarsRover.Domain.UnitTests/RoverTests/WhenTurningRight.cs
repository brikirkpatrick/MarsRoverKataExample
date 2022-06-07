using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.Domain.UnitTests.RoverTests
{
    [TestClass]
    public class WhenTurningRight
    {
        [DataTestMethod]
        [DataRow(Direction.North, Direction.East, DisplayName = "AndStartingDirectionIsNorthThenTheEndDirectionIsEast")]
        [DataRow(Direction.East, Direction.South, DisplayName = "AndStartingDirectionIsEastThenTheEndDirectionIsSouth")]
        [DataRow(Direction.South, Direction.West, DisplayName = "AndStartingDirectionIsSouthThenTheEndDirectionIsWest")]
        [DataRow(Direction.West, Direction.North, DisplayName = "AndStartingDirectionIsWestThenTheEndDirectionIsNorth")]
        public void AndFacingTheStartDirectionThenTheRoverFacesTheEndDirection(Direction start, Direction end)
        {
            var rover = RoverFixture.CreateRoverFacing(start);

            rover.TurnRight();

            var expectedRover = RoverFixture.CreateRoverFacing(end);
            Assert.AreEqual(expectedRover, rover);
        }
    }
}
