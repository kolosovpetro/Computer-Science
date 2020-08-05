using System;
using HeapLibrary.Implementations;
using HeapLibrary.Interfaces;

namespace HeapConsoleUI
{
    internal static class Program
    {
        private static void Main()
        {
            IBinaryHeap heap = new MaxBinaryHeap();
            heap.PushRange(1, 3, 5, 4, 6, 13, 10, 9, 8, 15, 17);
            Console.WriteLine("My Heap: ");
            foreach (var value in heap.HeapBase)
            {
                Console.Write($"{value} ");
            }

            var floydHeap = Auxiliary.FloydAlgorithm(4, 1, 3, 2, 16, 9, 10, 14, 8, 7);
            Console.WriteLine();
            Console.WriteLine("Floyd's Algorithm: ");
            foreach (var value in floydHeap.HeapBase)
            {
                Console.Write($"{value} ");
            }

            var heapSort = Auxiliary.HeapSort(4, 1, 3, 2, 16, 9, 10, 14, 8, 7);
            Console.WriteLine();
            Console.WriteLine("Heap sort try");
            foreach (var value in heapSort)
            {
                Console.Write($"{value} ");
            }
        }
    }
}