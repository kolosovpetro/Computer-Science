using System;

namespace SearchAlgorithms.Auxiliaries
{
    static class ArrayGenerator
    {
        public static int [] RandomArray(int Size)
        {
            Random rand = new Random();
            int[] RandomArray = new int[Size];

            for (int i = 0; i < Size; i++)
                RandomArray[i] = rand.Next(Size);

            return RandomArray;
        }

        public static int [] SortedAscArray(int Size)
        {
            var temp = RandomArray(Size);
            Array.Sort(temp);
            return temp;
        }

        public static int [] SortedDscArray(int Size)
        {
            var temp = RandomArray(Size);
            Array.Sort(temp);
            Array.Reverse(temp);
            return temp;
        }


    }
}
