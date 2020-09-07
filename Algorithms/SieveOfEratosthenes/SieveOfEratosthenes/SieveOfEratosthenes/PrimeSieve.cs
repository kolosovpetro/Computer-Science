using System.Collections.Generic;

namespace SieveOfEratosthenes.SieveOfEratosthenes
{
    public static class PrimeSieve
    {
        private static bool[] SieveOfEratosthenes(int upperBound)
        {
            var primes = new bool[upperBound + 1];

            for (var i = 0; i < primes.Length; i++)
                primes[i] = true;

            for (var p = 2; p * p < upperBound; p++)
            {
                if (!primes[p]) continue;
                for (var i = p * p; i < upperBound; i += p)
                    primes[i] = false;
            }

            return primes;
        }

        public static IEnumerable<int> PrimesList(int upperBound)
        {
            var sieve = SieveOfEratosthenes(upperBound);

            for (var i = 2; i < sieve.Length - 1; i++)
                if (sieve[i])
                    yield return i;
        }
    }
}