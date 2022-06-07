using System;
using System.Linq;

namespace MarsRover.Domain
{
    public class Rover : IRover
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Direction Direction { get; private set; }

        public Rover(int x, int y, Direction direction)
        {
            ValidateDirection(direction);
            X = x;
            Y = y;
            Direction = direction;
        }

        private void ValidateDirection(Direction direction)
        {
            var isValid = Enum
                .GetValues(typeof(Direction))
                .Cast<Direction>()
                .Any(x => x == direction);
            if (!isValid)
            {
                throw new ArgumentException(nameof(direction));
            }
        }

        public void TurnLeft()
        {
            switch (Direction)
            {
                case Direction.North:
                    Direction = Direction.West;
                    break;
                case Direction.South:
                    Direction = Direction.East;
                    break;
                case Direction.East:
                    Direction = Direction.North;
                    break;
                case Direction.West:
                    Direction = Direction.South;
                    break;
            }
        }

        public void TurnRight()
        {
            TurnLeft();
            TurnLeft();
            TurnLeft();
        }
        public void MoveForward()
        {
            switch (Direction)
            {
                case Direction.North:
                    Y += 1;
                    break;
                case Direction.South:
                    Y -= 1;
                    break;
                case Direction.East:
                    X += 1;
                    break;
                case Direction.West:
                    X -= 1;
                    break;
            }
        }

        public void MoveBackward()
        {
            TurnLeft();
            TurnLeft();
            MoveForward();
            TurnRight();
            TurnRight();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return obj is Rover && Equals((Rover)obj);
        }

        protected bool Equals(Rover other)
        {
            return X == other.X && Y == other.Y && Direction == other.Direction;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X;
                hashCode = (hashCode * 397) ^ Y;
                hashCode = (hashCode * 397) ^ (int)Direction;
                return hashCode;
            }
        }
    }
}
