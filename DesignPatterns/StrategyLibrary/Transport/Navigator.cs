using StrategyLibrary.Strategies;

namespace StrategyLibrary.Transport
{
    internal class Navigator
    {
        public Point A { get; }
        public Point B { get; }
        public IRouteStrategy RouteStrategy { get; private set; }

        public Navigator(Point a, Point b)
        {
            A = a;
            B = b;
        }

        public void SetStrategy(IRouteStrategy strategy)
        {
            RouteStrategy = strategy;
        }

        public int GetRange()
        {
            return RouteStrategy.Range(A, B);
        }

        public string GetMessage()
        {
            return RouteStrategy.Message(A, B);
        }
    }
}
