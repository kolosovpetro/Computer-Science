using System;
using System.Collections.Generic;
using System.Linq;

namespace Heaps.LINQ
{
    internal class Linq<T> : ILinq<T>
    {
        public void PrintCollection(IEnumerable<T> collection, bool inline = false)
        {
            Console.WriteLine();
            if (inline == false)
            {
                foreach (var item in collection)
                    Console.Write(item + ", ");
            }

            else
            {
                foreach (var item in collection)
                    Console.WriteLine(item + ", ");
            }

        }

        public IEnumerable<T> NumbersFromCollection(IEnumerable<T> Collection)
        {
            var numbers = Collection.Where(s => double.TryParse(s.ToString(), out _));
            return numbers;
        }

        public IEnumerable<T> CollectionSubset(IEnumerable<T> Collection, int StartIndex, int EndIndex)
        {
            var subset = Collection.Skip(StartIndex).Take(EndIndex);
            return subset;
        }

        public IEnumerable<string> SubsetThatConsist(IEnumerable<string> Collection, string Item)
        {
            var matches = Collection.Where(g => g.Contains(Item));
            return matches;
        }
    }
}
