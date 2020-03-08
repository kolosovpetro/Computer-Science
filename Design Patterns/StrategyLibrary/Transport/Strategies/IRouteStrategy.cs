namespace StrategyLibrary.Transport
{
    interface IRouteStrategy
    {
        int Range(Point A, Point B);
        string Message(Point A, Point B);
    }
}
