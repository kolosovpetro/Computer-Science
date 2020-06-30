using System;

namespace ClosesPairProblem
{
    public class Point: IEquatable<Point>
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                throw new InvalidOperationException("Coordinates must be positive");
            }

            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"Point: X={X}, Y={Y}";
        }

        public bool Equals(Point other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Point) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}