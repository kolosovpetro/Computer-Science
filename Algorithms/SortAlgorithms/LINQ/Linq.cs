using System;
using System.Collections.Generic;
using System.Linq;

namespace SortAlgorithms.LINQ
{
    class Linq<T> : ILinq<T>
    {
        public void PrintCollection(IEnumerable<T> enumer, bool inline = false)
        {
            Console.WriteLine();
            if (inline == false)
            {
                foreach (T item in enumer)
                    Console.Write(item + ", ");
            }
            else
            {
                foreach (T item in enumer)
                    Console.WriteLine(item + ", ");
            }

        }
        public void PrintCollection(IEnumerable<dynamic> enumer, bool inline = false)
        {
            if (inline == false)
            {
                foreach (dynamic item in enumer)
                    Console.Write(item + ", ");
            }
            else
            {
                foreach (dynamic item in enumer)
                    Console.WriteLine(item + ", ");
            }

        }
        public IEnumerable<T> NumbersFromCollection(IEnumerable<T> Collection)
        {
            IEnumerable<T> Numbers = Collection.Where(s => double.TryParse(s.ToString(), out double t));
            return (IEnumerable<T>)Numbers;
        }
        public IEnumerable<T> EvenNumbersFromCollection(IEnumerable<T> Collection)
        {
            IEnumerable<T> temp = Collection.Where(p => double.TryParse(p.ToString(), out double d) && int.Parse(p.ToString()) % 2 == 0);
            return temp;
        }
        public IEnumerable<T> OddNumbersFromCollection(IEnumerable<T> Collection)
        {
            IEnumerable<T> Temp = Collection.Where(p => double.TryParse(p.ToString(), out double d) && int.Parse(p.ToString()) % 2 == 1);
            return Temp;
        }
        public IEnumerable<dynamic> CountDuplicates(IEnumerable<int> Collection)
        {
            IEnumerable<dynamic> Duplicates = Collection.GroupBy(p => p).Select(g => new { Value = g.Key, Duplicates = g.Count() }).ToArray();
            return Duplicates;
        }
        public IEnumerable<dynamic> CountLettersInWord(string Word)
        {
            char[] tokens = Word.ToCharArray();
            IEnumerable<dynamic> LettersCount = tokens.GroupBy(token => token).Select(group => new { Letter = group.Key, InWord = group.Count() });
            return LettersCount;
        }
        public IEnumerable<T> CollectionSubset(IEnumerable<T> Collection, int StartIndex, int EndIndex)
        {
            IEnumerable<T> Subset = Collection.Skip(StartIndex).Take(EndIndex);
            return Subset;
        }
        public IEnumerable<string> SubsetThatConsist(IEnumerable<string> Collection, string Item)
        {
            var Matches = Collection.Where(g => g.Contains(Item));
            return (IEnumerable<string>)Matches;
        }
        public bool BinarySearch(IEnumerable<int> Collecation, int Value)
        {
            List<int> List = Collecation.ToList();
            int step = List.Count() / 2;

            while (step != 0)
            {
                step = List.Count() / 2;

                if (List[step] == Value)
                    return true;

                else if (List[step] > Value)
                    List = List.Take(step).ToList();

                else if (List[step] < Value)
                    List = List.Skip(step).Take(List.Count()).ToList();
            }

            return false;
        }
    }
}
