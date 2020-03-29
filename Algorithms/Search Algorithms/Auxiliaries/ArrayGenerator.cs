using System;

namespace SearchAlgorithms.Auxiliaries
{
    internal static class ArrayGenerator
    {
        public static int [] RandomArray(int length)
        {
            Random rand = new Random();

            int[] randomArray = new int[length];

            for (int i = 0; i < length; i++)
                randomArray[i] = rand.Next(length);

            return randomArray;
        }

        public static int [] SortedAscArray(int length)
        {
            var temp = RandomArray(length);
            Array.Sort(temp);
            return temp;
        }
    }
}
