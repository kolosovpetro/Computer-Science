using static System.Math;

namespace ClosesPairProblem
{
    public static class Distance
    {
        public static double CalculateDistance(Point a, Point b)
        {
            var d = b.X - a.X;
            var e = b.Y - a.Y;

            return Sqrt(Pow(d, 2) + Pow(e, 2));
        }
    }
}