namespace MarsRover.Domain
{
    public interface IRover
    {
        Direction Direction { get; }
        int X { get; }
        int Y { get; }

        void MoveBackward();
        void MoveForward();
        void TurnLeft();
        void TurnRight();
    }
}