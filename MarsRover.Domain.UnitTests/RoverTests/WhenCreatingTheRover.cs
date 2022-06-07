using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.Domain.UnitTests.RoverTests
{
    [TestClass]
    public class WhenCreatingTheRover
    {
        [TestMethod]
        public void AndTheDirectionIsInvalidThenAnExceptionIsThrown()
        {
            var invalidDirection = (Direction)100;
            Assert.ThrowsException<ArgumentException>(() => new Rover(0, 0, invalidDirection));
        }

        [TestMethod]
        public void AndTheDirectionIsValidThenTheRoverIsCreated()
        {
            var rover = new Rover(0, 0, Direction.North);
            
            Assert.IsNotNull(rover);
        }

        [TestMethod]
        public void AndTheDirectionIsValidThenTheRoverIsConfiguredCorrectly()
        {
            var rover = new Rover(1, 2, Direction.North);
            
            Assert.AreEqual(1, rover.X);
            Assert.AreEqual(2, rover.Y);
            Assert.AreEqual(Direction.North, rover.Direction);
        }
    }
}
