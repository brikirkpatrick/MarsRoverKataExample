using MarsRover.Domain;
using MarsRover.Services;
using MarsRover.Services.Logger;
using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Where should we send the log?");
            var filePath = Console.ReadLine();

            ILogger logger;
            try
            {

                logger = new FileLogger(filePath);
                var processor = new CommandProcessor(logger);
                var rover = processor.Create();

                var parser = new CommandParser();
                Command command = Command.Unknown;
                while (command != Command.Quit)
                {
                    Console.WriteLine(FormatRover(rover));
                    Console.WriteLine("Enter a command:");
                    Console.WriteLine("Move (F)orward, Move (B)ackward, Turn (L)eft, Turn (R)ight, (Q)uit");
                    var input = Console.ReadLine();
                    command = parser.Parse(input);
                    if (command == Command.Unknown)
                    {
                        Console.WriteLine($"I don't know how to process {input}, please try again");
                    }
                    else
                    {
                        processor.ProcessCommand(command, rover);
                    }
                }
                Console.WriteLine(FormatRover(rover));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to crate file logger :(, exiting application");
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }
        }

        private static string FormatRover(IRover rover)
        {
            return $"Rover is at ({rover.X}, {rover.Y}) facing {rover.Direction}";
        }
    }
}
