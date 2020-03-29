using System;
using System.Collections.Generic;
using Heaps.LINQ;
namespace Heaps
{
    internal class Program
    {
        private static void Main()
        {
            Linq<int> intProcess = new Linq<int>();
            Heap h1 = new Heap(5, 8, 4, 12, 11, 3, 7, 9, 0, 4, 2);
            Console.WriteLine("Heaped Array: ");
            intProcess.PrintCollection(h1.HeapBase);
            Console.WriteLine("Heap sort:");
            List<int> sorted = h1.HeapSort();
            intProcess.PrintCollection(sorted);
        }
    }
}
