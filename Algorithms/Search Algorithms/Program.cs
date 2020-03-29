using System;
using System.Collections.Generic;
using SearchAlgorithms.Auxiliaries;
using SearchAlgorithms.SearchMethods;

namespace SearchAlgorithms
{
    internal class Program
    {
        private static void Main()
        {
            const int size = 5000;

            Random rand = new Random();

            for (int i = 1; i <= 40; i++)
            {
                var searcher = new Searcher();
                int searchValue = rand.Next(size * i);
                int[] randomArray = ArrayGenerator.RandomArray(size * i);
                int[] sortedArray = ArrayGenerator.SortedAscArray(size * i);
                var searchMethods = new List<AbstractSearch>();
                var simpleLinearSearch = new SimpleLinearSearchMethod(randomArray, searchValue);
                var improvedLinearSearch = new ImprovedLinearSearchMethod(randomArray, searchValue);
                var binarySearch = new BinarySearchMethod(sortedArray, searchValue);
                var improvedLinearSearchWithSentinel = new ImprovedLinearSearchWithSentinelMethod(randomArray, searchValue);

                searchMethods.Add(simpleLinearSearch);
                searchMethods.Add(improvedLinearSearch);
                searchMethods.Add(binarySearch);
                searchMethods.Add(improvedLinearSearchWithSentinel);

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
