namespace MarsRover.Domain.UnitTests.RoverTests
{
    public static class RoverFixture
    {
        public static Rover CreateRoverFacing(Direction direction)
        {
            return new Rover(0, 0, direction);
        }
    }
}
