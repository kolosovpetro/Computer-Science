using System;
using Dictionary.Dictionary;

namespace Dictionary
{
    internal class Program
    {
        private static void Main()
        {
            var myDictionary = new MyDictionary<int, string>
            {
                {0, "Andrey"},
                {1, "Eugene"},
                {3, "Elizabeth"},
                {4, "Landariel"},
                {5, "Andy"}
            };


            foreach (var page in myDictionary)
            {
                Console.WriteLine($"{page.Key}, {page.Value}");
            }

            for (int i = 0; i < myDictionary.Count; i++)
            {
                Console.WriteLine($"{myDictionary[i].Key}, {myDictionary[i].Value}");
            }
        }
    }
}
