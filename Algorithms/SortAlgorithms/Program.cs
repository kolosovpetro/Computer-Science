using System;
using System.Collections.Generic;
using SortAlgorithms.SortMethods;
using SortAlgorithms.Arrays;

namespace SortAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int Size = 200;

            for (int i = 1; i <= 20; i++)
            {
                List<AbstractArray> AbsArrays = new List<AbstractArray>();
                AscArray a1 = new AscArray(Size * i);
                AShapeArray a2 = new AShapeArray(Size * i);
                ConstArray a3 = new ConstArray(Size * i);
                DscArray a4 = new DscArray(Size * i);
                RandomArray a5 = new RandomArray(Size * i);
                VShapeArray a6 = new VShapeArray(Size * i);
                AbsArrays.Add(a1);
                AbsArrays.Add(a2);
                AbsArrays.Add(a3);
                AbsArrays.Add(a4);
                AbsArrays.Add(a5);
                AbsArrays.Add(a6);

                for (int j = 0; j < AbsArrays.Count; j++)
                {
                    AbstractArray CurrentArray = AbsArrays[j];
                    List<AbstractSort> AbsSortList = new List<AbstractSort>();
                    BubbleSort bs = new BubbleSort(CurrentArray);
                    CocktailSort cs = new CocktailSort(CurrentArray);
                    InsertionSort ins = new InsertionSort(CurrentArray);
                    CountingSort cs1 = new CountingSort(CurrentArray);
                    SelectionSort ss = new SelectionSort(CurrentArray);
                    MergeSort ms = new MergeSort(CurrentArray);
                    QuickSort qs = new QuickSort(CurrentArray);
                    AbsSortList.Add(bs);
                    AbsSortList.Add(cs);
                    AbsSortList.Add(ins);
                    AbsSortList.Add(cs1);
                    AbsSortList.Add(ss);
                    AbsSortList.Add(ms);
                    AbsSortList.Add(qs);

                    foreach (AbstractSort SortMethod in AbsSortList)
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
