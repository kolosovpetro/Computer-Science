// TODO: Simplify.

namespace Exercises.Misc
{
	using System;

	public class E2
    {
        private readonly int _v0;
        private readonly int _v1;

        public E2(int v0, int v1)
        {
            _v0 = v0;
            _v1 = v1;
        }

        public double Process(int i)
        {
            if (i >= 0)
            {
                if (i == 0)
                {
                    return 0;
                }

                if (i > 500)
                {
                    return i / 500.0;
                }
            }
            else
            {
                if (_v0 + _v1 > 0)
                {
                    var x = Math.Cos(i + _v0);
                    var y = Math.Sin(i + _v1);

                    var isPositive = Math.Round(x + y) > 0;

                    if (isPositive != false)
                        return x - y;
                    else
                        return y + x;
                }
            }

	        return i;
        }
    }
}