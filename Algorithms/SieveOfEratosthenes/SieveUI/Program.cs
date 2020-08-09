using System;
using SieveOfEratosthenes;
using SieveOfEratosthenes.AdvSieve;

namespace SieveUI
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var sieve = new SimpleSieve(10);
            var allTrueSieve = sieve.AllTrueSieve();
            SimpleSieve.ExcludeDivisible(3, allTrueSieve);
            var getSieve = sieve.GenerateSieve();
            foreach (var prime in getSieve)
            {
                Console.Write(prime + ", ");
            }

            Console.WriteLine();
            
            var advSieve = new AdvancedSieve(20);
            advSieve.ResetSieve();
            advSieve.GenerateEratosthenes();
            var primes = advSieve.Sieve;

            foreach (var prime in primes)
            {
                Console.WriteLine(prime);
            }
        }
    }
}