namespace BinaryGCD.Implementation
{
    public static class BinaryGcd
    {
        public static int GetGcd(int u, int v)
        {
            if (u == 0 && v == 0) return 0;
            if (u == v) return u;
            if (u == 0) return v;
            if (v == 0) return u;

            if (IsEven(u))
            {
                if (IsOdd(v))
                    return GetGcd(u >> 1, v);

                return GetGcd(u >> 1, v >> 1) << 1;
            }

            if (IsEven(v))
                return GetGcd(u, v >> 1);

            if (u > v)
                return GetGcd((u - v) >> 1, v);

            return GetGcd((v - u) >> 1, u);
        }

        private static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        private static bool IsOdd(int number)
        {
            return !IsEven(number);
        }
    }
}