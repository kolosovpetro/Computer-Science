using StrategyLibrary.Transport;

namespace StrategyLibrary.Strategies
{
    internal interface IRouteStrategy
    {
        int Range(Point a, Point b);
        string Message(Point a, Point b);
    }
}
