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
                Arrays.Add(a1);
                Arrays.Add(a2);
                Arrays.Add(a3);
                Arrays.Add(a4);
                Arrays.Add(a5);
                Arrays.Add(a6);

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
                    SortList.Add(s1);
                    SortList.Add(s2);
                    SortList.Add(s3);
                    SortList.Add(s4);
                    SortList.Add(s5);
                    SortList.Add(s6);
                    SortList.Add(s7);

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
