using MonteCarloMethod.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonteCarloMethod.Classes
{
    internal class Linq<T> : ILinq<T>
    {
        public void PrintCollection(IEnumerable<T> enumerable, bool inline = false)
        {
            if (inline == false)
            {
                foreach (var Item in enumerable)
                    Console.Write(Item + ", ");
            }

            else
            {
                foreach (var Item in enumerable)
                    Console.WriteLine(Item + ", ");
            }

        }
        public void PrintCollection(IEnumerable<dynamic> enumerable, bool inline = false)
        {
            if (inline == false)
            {
                foreach (dynamic Item in enumerable)
                    Console.Write(Item + ", ");
            }

            else
            {
                foreach (dynamic Item in enumerable)
                    Console.WriteLine(Item + ", ");
            }

        }
        public IEnumerable<T> NumbersFromCollection(IEnumerable<T> collection)
        {
            var Numbers = collection.Where(s => double.TryParse(s.ToString(), out _));
            return Numbers;
        }
        public IEnumerable<T> EvenNumbersFromCollection(IEnumerable<T> collection)
        {
            var Temp = collection.Where(p => double.TryParse(p.ToString(), out _) && int.Parse(p.ToString()) % 2 == 0);
            return Temp;
        }
        public IEnumerable<T> OddNumbersFromCollection(IEnumerable<T> collection)
        {
            var Temp = collection.Where(p => double.TryParse(p.ToString(), out _) && int.Parse(p.ToString()) % 2 == 1);
            return Temp;
        }
        public IEnumerable<dynamic> CountDuplicates(IEnumerable<int> collection)
        {
            IEnumerable<dynamic> Duplicates = collection.GroupBy(p => p).Select(g => new { Value = g.Key, Duplicates = g.Count() }).ToArray();
            return Duplicates;
        }
        public IEnumerable<dynamic> CountLettersInWord(string word)
        {
            var Tokens = word.ToCharArray();
            var LettersCount = Tokens.GroupBy(token => token).Select(group => new { Letter = group.Key, InWord = group.Count() });
            return LettersCount;
        }
        public IEnumerable<T> CollectionSubset(IEnumerable<T> collection, int startIndex, int endIndex)
        {
            var Subset = collection.Skip(startIndex).Take(endIndex);
            return Subset;
        }
        public IEnumerable<string> SubsetThatConsist(IEnumerable<string> collection, string item)
        {
            var Matches = collection.Where(g => g.Contains(item));
            return Matches;
        }
        public bool BinarySearch(IEnumerable<int> collection, int value)
        {
            var List = collection.ToList();
            int Step = List.Count() / 2;

            while (Step != 0)
            {
                Step = List.Count() / 2;

                if (List[Step] == value)
                    return true;

                if (List[Step] > value)
                    List = List.Take(Step).ToList();

                else if (List[Step] < value)
                    List = List.Skip(Step).Take(List.Count()).ToList();
            }

            return false;
        }

        public void GenericSwap(IEnumerable<T> collection, int leftIndex, int rightIndex)
        {
            var NewCollection = collection.ToList();
            T Temp = NewCollection[leftIndex];
            NewCollection[leftIndex] = NewCollection[rightIndex];
            NewCollection[rightIndex] = Temp;
        }
    }
}
