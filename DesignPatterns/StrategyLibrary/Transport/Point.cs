namespace StrategyLibrary.Transport
{
    class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point(int newX, int newY)
        {
            X = newX;
            Y = newY;
        }
    }
}
