using System;

namespace LINQ_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            LINQ<int> IntegerProcessing = new LINQ<int>();
            LINQ<string> StringProcessing = new LINQ<string>();
            int[] Integers = new int[]
            {
                0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                11, 12, 5, 5, 5, 5, 5, 2, 2, 2, 8,
                8, 8, 7, 5, 1, 9, 2, 3, 7, 4, 5, 6,
                8, 7, 6, 3, 4, 5, 2
            };
            Console.WriteLine("Our array is: ");
            IntegerProcessing.PrintCollection(Integers);
            var EvensInCollection = IntegerProcessing.EvenNumbersFromCollection(Integers);
            Console.WriteLine("\nEvens from this collection: ");
            IntegerProcessing.PrintCollection(EvensInCollection);
            var OddsInCollection = IntegerProcessing.OddNumbersFromCollection(Integers);
            Console.WriteLine("\nOdds from this collection: ");
            IntegerProcessing.PrintCollection(OddsInCollection);
            var Duplicates = IntegerProcessing.CountDuplicates(Integers);
            Console.WriteLine("\nDuplicates this collection: ");
            IntegerProcessing.PrintCollection(Duplicates, true);
            string Word = "I love My Mother and Father";
            Console.WriteLine($"Let's test a string: {Word}");
            Console.WriteLine("Calculate the number of letters in it:");
            var LettersCount = StringProcessing.CountLettersInWord(Word);
            StringProcessing.PrintCollection(LettersCount, true);
            LINQ<string> NumberParsing = new LINQ<string>();
            string[] Collection = new string[]
            {
                "A", "1", "B", "2", "C", "3", "D", "4", "E", "5", "F", "6", "G", "7", "H", "8"
            };

            var Numbers = NumberParsing.CollectionSubset(Collection, 2, 5);
            NumberParsing.PrintCollection(Numbers);
            Console.WriteLine("Binary Search Test: ");
            IntegerProcessing.PrintCollection(Integers);
            Console.WriteLine($"\nCollection {Integers} consists 20: ");
            Array.Sort(Integers);
            bool IsConsist = IntegerProcessing.BinarySearch(Integers, 20);
            Console.WriteLine(IsConsist);
        }
    }
}
