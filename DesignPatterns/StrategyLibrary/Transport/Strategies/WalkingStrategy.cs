using System;

namespace StrategyLibrary.Transport
{
    class WalkingStrategy : IRouteStrategy
    {
        public string Message(Point A, Point B)
        {
            return $"Walking route between points {(A.X, A.Y)} and {(B.X, B.Y)} is build sucessfully.";
        }

        public int Range(Point A, Point B)
        {
            return (int)Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
        }
    }
}
