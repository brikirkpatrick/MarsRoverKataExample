using MarsRover.Domain;
using MarsRover.Services.Logger;
using System;

namespace MarsRover.Services
{
    public class CommandProcessor
    {
        private readonly ILogger _logger;

        public CommandProcessor(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IRover Create()
        {
            return new Rover(0, 0, Direction.North);
        }

        public void ProcessCommand(Command command, IRover rover)
        {
            if (rover == null) throw new ArgumentNullException(nameof(rover));
            switch (command)
            {
                case Command.Unknown:
                    _logger.Log("Failed to process an unknown command!");
                    break;
                case Command.MoveForward:
                    rover.MoveForward();
                    _logger.Log("Rover moved forward!");
                    break;
                case Command.MoveBackward:
                    rover.MoveBackward();
                    _logger.Log("Rover moved backward!");
                    break;
                case Command.TurnLeft:
                    rover.TurnLeft();
                    _logger.Log("Rover turned left!");
                    break;
                case Command.TurnRight:
                    rover.TurnRight();
                    _logger.Log("Rover turned right!");
                    break;
                case Command.Quit:
                    _logger.Log($"Rover stopped at {FormatRoverLocation(rover)}");
                    break;
            }
        }

        private string FormatRoverLocation(IRover r) => $"({r.X}, {r.Y}) facing {r.Direction}";
    }
}
