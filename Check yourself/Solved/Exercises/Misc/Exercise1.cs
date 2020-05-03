// TODO: Simplify.

namespace Exercises.Misc
{
    using System;

    public class E1
    {
        private readonly double _v0;
        private readonly double _v1;

        public E1(double v0, double v1)
        {
            _v0 = v0;
            _v1 = v1;
        }

        public double Process(double i)
        {
            double x = Math.Cos(i + _v0);
            double y = Math.Sin(i + _v1);

            bool isPositive = Math.Round(x + y) > 0;

            if (!isPositive) return x - y;

            return y + x;
        }
    }
}