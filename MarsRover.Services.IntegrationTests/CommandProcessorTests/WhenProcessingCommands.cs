using MarsRover.Domain;
using MarsRover.Services.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MarsRover.Services.IntegrationTests.CommandProcessorTests
{
    [TestClass]
    public class WhenProcessingCommands
    {
        private static string _logLocation;
        private static CommandProcessor _processor;

        [ClassInitialize]
        public static void ClassSetup(TestContext ignored)
        {
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _logLocation = directory + "\\log.txt";
            var logger = new FileLogger(_logLocation);
            _processor = new CommandProcessor(logger);
        }

        [TestCleanup]
        public void Cleanup()
        {
            File.Delete(_logLocation);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void ThenTheRoverIsAtTheCorrectPositionWithTheCorrectLogs(List<Command> commands, string message, Rover expectedRover)
        {
            File.Delete(_logLocation);
            var rover = _processor.Create();

            commands.ForEach(c => _processor.ProcessCommand(c, rover));

            Assert.AreEqual(expectedRover, rover);
            Assert.AreEqual(message, GetLogContents());
        }

        public static IEnumerable<object[]> GetData()
        {
            yield return OffsettingTestData();
            yield return AllTheWayAroundTestData();

        }

        private static object[] OffsettingTestData()
        {
            var commands = new List<Command>{
                    Command.MoveForward, Command.MoveForward, Command.MoveForward,
                    Command.MoveBackward, Command.MoveBackward,
                    Command.TurnLeft, Command.TurnLeft,
                    Command.TurnRight, Command.TurnRight,
                    Command.Quit };

            var rover = new Rover(0, 1, Direction.North);
            var message = BuildMessageFromCommandsAndRover(commands, rover);

            return new object[] { commands, message, rover };
        }

        private static object[] AllTheWayAroundTestData()
        {
            var commands = new List<Command> { Command.TurnLeft, Command.TurnLeft, Command.TurnLeft, Command.TurnLeft, Command.Quit };
            var rover = new Rover(0, 0, Direction.North);
            var message = BuildMessageFromCommandsAndRover(commands, rover);

            return new object[] { commands, message, rover };
        }
        private static string BuildMessageFromCommandsAndRover(List<Command> commands, Rover rover)
        {
            Func<Command, string> commandToMessage = c =>
            {
                switch (c)
                {
                    case Command.MoveForward:
                        return "Rover moved forward!";
                    case Command.MoveBackward:
                        return "Rover moved backward!";
                    case Command.TurnLeft:
                        return "Rover turned left!";
                    case Command.TurnRight:
                        return "Rover turned right!";
                    case Command.Unknown:
                        return "Failed to process an unknown command!";
                    case Command.Quit:
                        return $"Rover stopped at ({rover.X}, {rover.Y}) facing {rover.Direction}";
                    default: throw new NotSupportedException();
                }
            };

            return commands.Select(commandToMessage)
                .Aggregate(new StringBuilder(), (sb, s) => sb.AppendLine(s))
                .ToString();
        }
        private string GetLogContents() => File.ReadAllText(_logLocation);
    }
}
