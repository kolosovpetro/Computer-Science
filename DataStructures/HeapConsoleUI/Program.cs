using System;
using HeapLibrary.Implementations;
using HeapLibrary.Interfaces;

namespace HeapConsoleUI
{
    internal static class Program
    {
        private static void Main()
        {
            IBinaryHeap heap = new BinaryHeap();
            heap.PushRange(1, 3, 5, 4, 6, 13, 10, 9, 8, 15, 17);
            Console.WriteLine("My Heap: ");

            foreach (var value in heap.HeapBase)
            {
                Console.Write($"{value}, ");
            }
        }
    }
}