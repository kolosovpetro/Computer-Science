using System;

namespace CollatzProblem.Implementation
{
    public static class Collatz
    {
        public static int GetSteps(int value)
        {
            if (value < 2)
            {
                throw new InvalidOperationException("Value must be greater than 1");
            }

            var path = 0;
            var current = value;

            while (true)
            {
                if (current == 1) break;
                
                if (IsEven(current))
                {
                    current /= 2;
                    path++;
                    continue;
                }
                
                current = 3 * current + 1;
                path++;
            }

            return path;
        }

        private static bool IsEven(int value)
        {
            return value % 2 == 0;
        }

        private static bool IsOdd(int value)
        {
            return !IsEven(value);
        }
    }
}