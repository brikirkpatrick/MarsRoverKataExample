using MarsRover.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Services.UnitTests.CommandParserTests
{
    [TestClass]
    public class WhenParsingAString
    {
        [DataTestMethod]
        [DataRow("f", Command.MoveForward, DisplayName = "AndTheInputIsfThenMoveForwardIsReturned")]
        [DataRow("F", Command.MoveForward, DisplayName = "AndTheInputIsFThenMoveForwardIsReturned")]
        [DataRow("b", Command.MoveBackward, DisplayName = "AndTheInputIsbThenMoveBackwardIsReturned")]
        [DataRow("B", Command.MoveBackward, DisplayName = "AndTheInputIsBThenMoveBackwardIsReturned")]
        [DataRow("l", Command.TurnLeft, DisplayName = "AndTheInputIslThenTurnLeftIsReturned")]
        [DataRow("L", Command.TurnLeft, DisplayName = "AndTheInputIsLThenTurnLeftIsReturned")]
        [DataRow("r", Command.TurnRight, DisplayName = "AndTheInputIsrThenTurnRightIsReturned")]
        [DataRow("R", Command.TurnRight, DisplayName = "AndTheInputIsRThenTurnRightIsReturned")]
        [DataRow("q", Command.Quit, DisplayName = "AndTheInputIsqThenQuitIsReturned")]
        [DataRow("Q", Command.Quit, DisplayName = "AndTheInputIsQThenQuitIsReturned")]
        [DataRow("kumquats", Command.Unknown, DisplayName = "AndTheInputIsKumquatsThenUnknownIsReturned")]
        public void ThenTheInputIsConvertedToTheCorrectCommand(string input, Command expected)
        {
            var parser = new CommandParser();

            var result = parser.Parse(input);

            Assert.AreEqual(expected, result);
        }
    }
}
