using MarsRover.Domain;
using MarsRover.Services.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace MarsRover.Services.UnitTests.CommandProcessorTests
{
    [TestClass]
    public class WhenProcessingCommands
    {
        private Mock<ILogger> _loggerMock;
        private CommandProcessor _processor;

        [TestInitialize]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger>();
            _processor = new CommandProcessor(_loggerMock.Object);
        }

        [TestMethod]
        public void AndTheRoverIsNullThenAnExceptionIsThrown()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _processor.ProcessCommand(Command.MoveBackward, null));
        }

        [TestMethod]
        public void AndTheCommandIsMoveBackwardThenTheRoverMovesBackward()
        {
            var mock = new Mock<IRover>();
            var rover = mock.Object;

            _processor.ProcessCommand(Command.MoveBackward, rover);

            mock.Verify(x => x.MoveBackward(), Times.Once());
        }

        [TestMethod]
        public void AndTheCommandIsMoveBackwardThenTheCorrectMessageIsLogged()
        {
            _processor.ProcessCommand(Command.MoveBackward, new Mock<IRover>().Object);

            _loggerMock.Verify(x => x.Log("Rover moved backward!"));
        }

        [TestMethod]
        public void AndTheCommandIsMoveForwardThenTheRoverMovesForward()
        {
            var mock = new Mock<IRover>();
            var rover = mock.Object;

            _processor.ProcessCommand(Command.MoveForward, rover);

            mock.Verify(x => x.MoveForward(), Times.Once());
        }

        [TestMethod]
        public void AndTheCommandIsMoveForwardThenTheCorrectMessageIsLogged()
        {
            _processor.ProcessCommand(Command.MoveForward, new Mock<IRover>().Object);

            _loggerMock.Verify(x => x.Log("Rover moved forward!"));
        }

        [TestMethod]
        public void AndTheCommandIsTurnLeftThenTheRoverTurnsLeft()
        {
            var mock = new Mock<IRover>();
            var rover = mock.Object;

            _processor.ProcessCommand(Command.TurnLeft, rover);

            mock.Verify(x => x.TurnLeft(), Times.Once());
        }

        [TestMethod]
        public void AndTheCommandIsTurnLeftThenTheCorrectMessageIsLogged()
        {
            _processor.ProcessCommand(Command.TurnLeft, new Mock<IRover>().Object);

            _loggerMock.Verify(x => x.Log("Rover turned left!"));
        }

        [TestMethod]
        public void AndTheCommandIsTurnRightThenTheRoverTurnRight()
        {
            var mock = new Mock<IRover>();
            var rover = mock.Object;

            _processor.ProcessCommand(Command.TurnRight, rover);

            mock.Verify(x => x.TurnRight(), Times.Once());
        }

        [TestMethod]
        public void AndTheCommandIsTurnRightThenTheCorrectMessageIsLogged()
        {
            _processor.ProcessCommand(Command.TurnRight, new Mock<IRover>().Object);

            _loggerMock.Verify(x => x.Log("Rover turned right!"));
        }

        [TestMethod]
        public void AndTheCommandIsQuitThenTheRoverDoesNothing()
        {
            var mock = new Mock<IRover>();
            var rover = mock.Object;

            _processor.ProcessCommand(Command.Quit, rover);

            mock.Verify(x => x.MoveForward(), Times.Never());
            mock.Verify(x => x.MoveBackward(), Times.Never());
            mock.Verify(x => x.TurnLeft(), Times.Never());
            mock.Verify(x => x.TurnRight(), Times.Never());
        }

        [TestMethod]
        public void AndTheCommandIsQuitThenTheCorrectMessageIsLogged()
        {
            var rover = new Rover(0, 0, Direction.North);

            _processor.ProcessCommand(Command.Quit, rover);

            _loggerMock.Verify(x => x.Log("Rover stopped at (0, 0) facing North"));
        }
    }
}
