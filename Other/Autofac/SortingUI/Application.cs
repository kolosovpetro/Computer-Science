using System;
using System.Linq;
using IDLibrary.Interfaces;

namespace SortingUI
{
    public class Application
    {
        private readonly int[] _array = {5, 6, 2, 8, 1, 3, 9};
        private readonly ISortMethod _sortMethod;

        public Application(ISortMethod sortMethod)
        {
            _sortMethod = sortMethod;
        }

        public void Execute()
        {
            Console.Write("Initial array: ");
            _array.ToList().ForEach(x => Console.Write($"{x}, "));
            Console.WriteLine();
            Console.WriteLine($"Sort Method used: {_sortMethod.GetType().Name}");
            _sortMethod.Sort(_array);
            Console.Write("Sorted: ");
            _array.ToList().ForEach(x => Console.Write($"{x}, "));
        }
    }
}