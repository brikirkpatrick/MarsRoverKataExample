using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.Domain.UnitTests.RoverTests
{
    [TestClass]
    public class WhenTurningLeft
    {
        [DataTestMethod]
        [DataRow(Direction.North, Direction.West, DisplayName = "AndStartingDirectionIsNorthThenTheEndDirectionIsWest")]
        [DataRow(Direction.West, Direction.South, DisplayName = "AndStartingDirectionIsWestThenTheEndDirectionIsSouth")]
        [DataRow(Direction.South, Direction.East, DisplayName = "AndStartingDirectionIsSouthThenTheEndDirectionIsEast")]
        [DataRow(Direction.East, Direction.North, DisplayName = "AndStartingDirectionIsEastThenTheEndDirectionIsNorth")]
        public void AndFacingTheStartDirectionThenTheRoverFacesTheEndDirection(Direction start, Direction end)
        {
            var rover = RoverFixture.CreateRoverFacing(start);

            rover.TurnLeft();

            var expectedRover = RoverFixture.CreateRoverFacing(end);
            Assert.AreEqual(expectedRover, rover);
        }
    }
}
