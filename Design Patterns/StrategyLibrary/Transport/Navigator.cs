namespace StrategyLibrary.Transport
{
    class Navigator
    {
        public Point A { get; private set; }
        public Point B { get; private set; }
        public IRouteStrategy RouteStrategy { get; private set; }

        public Navigator(Point newA, Point newB)
        {
            A = newA;
            B = newB;
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
