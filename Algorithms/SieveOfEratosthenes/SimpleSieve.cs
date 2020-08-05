using System.Collections.Generic;

namespace SieveOfEratosthenes
{
    public class SimpleSieve
    {
        private int Count { get; }
        private const int FirstPrime = 2;

        public SimpleSieve(int count)
        {
            Count = count;
        }

        public IEnumerable<int> PrimeList()
        {
            var list = new List<int>();
            var sieve = GenerateSieve();
            
            for (int i = 0; i < Count; i++)
            {
                if (sieve[i])
                {
                    list.Add(i);
                }
            }

            return list;
        }

        public bool[] GenerateSieve()
        {
            var sieve = AllTrueSieve();

            for (var i = FirstPrime; i < sieve.Length; i++)
            {
                if (sieve[i])
                    ExcludeDivisible(i, sieve);
            }

            return sieve;
        }

        public static void ExcludeDivisible(int iterator, bool[] sieve)
        {
            for (int i = 2 * iterator; i < sieve.Length; i += iterator)
            {
                if (!sieve[i])
                    continue;

                sieve[i] = false;
            }
        }

        public bool[] AllTrueSieve()
        {
            var sieve = new bool[Count];

            for (int i = 2; i < sieve.Length; i++)
                sieve[i] = true;

            return sieve;
        }
    }
}