using System;
using System.Collections.Generic;
using SearchAlgorithms.SearchMethods;
using static SearchAlgorithms.Auxiliaries.ArrayGenerator;

namespace SearchAlgorithms
{
    internal static class Program
    {
        private static void Main()
        {
            const int size = 5000;

            var rand = new Random();

            for (var i = 1; i <= 40; i++)
            {
                var searcher = new Searcher();
                var searchValue = rand.Next(size * i);
                var randomArray = RandomArray(size * i);
                var sortedArray = SortedAscArray(size * i);
                var searchMethods = new List<AbstractSearch>();
                var s1 = new SimpleLinearSearch(randomArray, searchValue);
                var s2 = new ImprovedLinearSearch(randomArray, searchValue);
                var s3 = new BinarySearch(sortedArray, searchValue);
                var s4 = new ImprovedLinearSearchSentinel(randomArray, searchValue);

                searchMethods.AddRange(new AbstractSearch[] {s1, s2, s3, s4});

                foreach (var search in searchMethods)
                {
                    searcher.SetSearch(search);
                    searcher.SetDataLogger(search);
                    searcher.SearchAndBenchmark();
                    Console.WriteLine(search.Message);
                }
            }
        }
    }
}