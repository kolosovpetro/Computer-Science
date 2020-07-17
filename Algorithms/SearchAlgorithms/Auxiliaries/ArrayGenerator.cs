using System;
using System.Collections.Generic;

namespace SearchAlgorithms.Auxiliaries
{
    internal static class ArrayGenerator
    {
        public static int[] RandomArray(int length)
        {
            var rand = new Random();

            var randomArray = new int[length];

            for (var i = 0; i < length; i++)
                randomArray[i] = rand.Next(length);

            return randomArray;
        }

        public static IEnumerable<int> SortedAscArray(int length)
        {
            var temp = RandomArray(length);
            Array.Sort(temp);
            return temp;
        }
    }
}