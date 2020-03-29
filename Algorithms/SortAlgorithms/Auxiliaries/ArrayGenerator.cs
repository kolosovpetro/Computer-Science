using System;
using System.Linq;

namespace SortAlgorithms.Auxiliaries
{
    internal static class ArrayGenerator
    {
        public static int [] RandomArray(int Size)
        {
            Random rand = new Random();
            int[] RandomArray = new int[Size];

            for (int i = 0; i < Size; i++)
                RandomArray[i] = rand.Next(0, Size);

            return RandomArray;
        }

        public static int [] SortedAscArray(int Size)
        {
            var temp = RandomArray(Size);
            Array.Sort(temp);
            return temp;
        }

        public static int[] SortedDscArray(int Size)
        {
            var temp = SortedAscArray(Size);
            Array.Reverse(temp);
            return temp;
        }

        public static int[] ConstArray(int Size)
        {
            Random rand = new Random();
            int[] temp = new int[Size];
            int Value = rand.Next(0, Size);
            for (int i = 0; i < Size; i++)
                temp[i] = Value;

            return temp;
        }
        public static int [] AShapeArray(int Size)
        {
            var temp = SortedAscArray(Size);
            var part1 = temp.Skip(0).Take(Size / 2).ToArray();
            var part2 = temp.Skip(Size / 2).Take(Size).ToArray();
            Array.Reverse(part2);
            temp = part1.Concat(part2).ToArray();
            return temp;
        }

        public static int[] VShapeArray(int Size)
        {
            var temp = SortedAscArray(Size);
            var part1 = temp.Skip(0).Take(Size / 2).ToArray();
            var part2 = temp.Skip(Size / 2).Take(Size).ToArray();
            Array.Reverse(part1);
            temp = part1.Concat(part2).ToArray();
            return temp;
        }
    }
}
