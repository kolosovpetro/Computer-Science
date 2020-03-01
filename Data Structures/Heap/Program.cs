using System;
using System.Collections.Generic;
using Heaps.LINQ;
namespace Heaps
{
    class Program
    {
        static void Main(string[] args)
        {
            Linq<int> IntProcess = new Linq<int>();
            Heap h1 = new Heap(5, 8, 4, 12, 11, 3, 7, 9, 0, 4, 2);
            Console.WriteLine("Heaped Array: ");
            IntProcess.PrintCollection(h1.HeapBase);
            Console.WriteLine("Heap sort:");
            List<int> Sorted = h1.HeapSort();
            IntProcess.PrintCollection(Sorted);
        }
    }
}
