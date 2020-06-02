using System;
using StrategyLibrary.Transport;

namespace StrategyLibrary.Strategies
{
    internal class PublicTransportStrategy : IRouteStrategy
    {
        public string Message(Point a, Point b)
        {
            return $"Public transport route between points {(a.X, a.Y)} and {(b.X, b.Y)} is build successfully.";
        }

        public int Range(Point a, Point b)
        {
            return (int)Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
        }
    }
}
