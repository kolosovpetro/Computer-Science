using System;
using System.Collections.Generic;
using SearchAlgorithms.Auxiliaries;
using SearchAlgorithms.SearchMethods;

namespace SearchAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int Size = 5000;
            Random rand = new Random();

            for (int i = 1; i <= 40; i++)
            {
                Searcher s = new Searcher();
                int SearchValue = rand.Next(Size * i);
                int[] RandomArray = ArrayGenerator.RandomArray(Size * i);
                int[] SortedArray = ArrayGenerator.SortedAscArray(Size * i);
                List<AbstractSearch> SearchMethods = new List<AbstractSearch>();
                SimpleLinearSearch sls = new SimpleLinearSearch(RandomArray, SearchValue);
                ImprovedLimearSearch ils = new ImprovedLimearSearch(RandomArray, SearchValue);
                BinarySearch bs = new BinarySearch(SortedArray, SearchValue);
                ImprovedLinearSearchWithSentinel ilss = new ImprovedLinearSearchWithSentinel(RandomArray, SearchValue);
                SearchMethods.Add(sls);
                SearchMethods.Add(ils);
                SearchMethods.Add(bs);
                SearchMethods.Add(ilss);

                foreach (AbstractSearch AbsSearch in SearchMethods)
                {
                    s.SetSearch(AbsSearch);
                    s.SetDataLogger(AbsSearch);
                    s.DoSearchAndBenchmark();
                    Console.WriteLine(AbsSearch.Message);
                }
            }


        }
    }
}
