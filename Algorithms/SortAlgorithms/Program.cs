using System;
using System.Collections.Generic;
using SortAlgorithms.SortMethods;
using SortAlgorithms.Arrays;

namespace SortAlgorithms
{
    internal static class Program
    {
        private static void Main()
        {
            const int size = 200;

            for (var i = 1; i <= 20; i++)
            {
                var Arrays = new List<AbstractArray>();
                var a1 = new AscendingArray(size * i);
                var a2 = new AShapeArray(size * i);
                var a3 = new ConstArray(size * i);
                var a4 = new DescendingArray(size * i);
                var a5 = new RandomArray(size * i);
                var a6 = new VShapeArray(size * i);
                Arrays.AddRange(new AbstractArray[] {a1, a2, a3, a4, a5, a6});

                foreach (var CurrentArray in Arrays)
                {
                    var SortList = new List<AbstractSort>();
                    var s1 = new BubbleSort(CurrentArray);
                    var s2 = new CocktailSort(CurrentArray);
                    var s3 = new InsertionSort(CurrentArray);
                    var s4 = new CountingSort(CurrentArray);
                    var s5 = new SelectionSort(CurrentArray);
                    var s6 = new MergeSort(CurrentArray);
                    var s7 = new QuickSort(CurrentArray);
                    SortList.AddRange(new AbstractSort[] {s1, s2, s3, s4, s5, s6, s7});

                    foreach (var SortMethod in SortList)
                    {
                        SortMethod.GetSortedArray();
                        SortMethod.GetBenchmark();
                        Console.WriteLine(SortMethod.Message);
                    }
                }
            }
        }
    }
}