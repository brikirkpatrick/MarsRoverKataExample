using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Domain.UnitTests.RoverTests
{
    [TestClass]
    public class WhenMovingBackward
    {
        [TestMethod]
        public void AndFacingNorthThenTheYDecreasesByOne()
        {
            const int startY = 0;
            var rover = new Rover(0, startY, Direction.North);

            rover.MoveBackward();

            var expectedRover = new Rover(0, startY-1, Direction.North);
            Assert.AreEqual(expectedRover, rover);
        }

        [TestMethod]
        public void AndFacingSouthThenTheYIncreasesByOne()
        {
            const int startY = 0;
            var rover = new Rover(0, startY, Direction.South);

            rover.MoveBackward();

            var expectedRover = new Rover(0, startY+1, Direction.South);
            Assert.AreEqual(expectedRover, rover);
        }

        [TestMethod]
        public void AndFacingWestThenTheXIncreasesByOne()
        {
            const int startX = 0;
            var rover = new Rover(startX, 0, Direction.West);

            rover.MoveBackward();

            var expectedRover = new Rover(startX+1, 0, Direction.West);
            Assert.AreEqual(expectedRover, rover);
        }

        [TestMethod]
        public void AndFacingEastThenTheXDecreasesByOne()
        {
            const int startX = 0;
            var rover = new Rover(startX, 0, Direction.East);

            rover.MoveBackward();

            var expectedRover = new Rover(startX-1, 0, Direction.East);
            Assert.AreEqual(expectedRover, rover);
        }
    }
}
