using System;
using SieveOfEratosthenes.SieveOfEratosthenes;

namespace SieveOfEratosthenes.ConsoleUI
{
    public static class Program
    {
        private static void Main()
        {
            var primeList = PrimeSieve.PrimesList(30);
            
            foreach (var prime in primeList) 
                Console.Write(prime + " ");
        }
    }
}