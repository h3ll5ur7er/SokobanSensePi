using System.Drawing;

namespace SokobanSensePi
{
    public static class DirectionExtensions
    {
        public static Point Move(this Point position, Direction direction)
        {
            switch(direction)
            {
                case Direction.Left:  return new Point(position.X-1, position.Y);
                case Direction.Up:    return new Point(position.X,   position.Y-1);
                case Direction.Right: return new Point(position.X+1, position.Y);
                case Direction.Down:  return new Point(position.X,   position.Y+1);
                default:              return position;
            }
        }
    }

}