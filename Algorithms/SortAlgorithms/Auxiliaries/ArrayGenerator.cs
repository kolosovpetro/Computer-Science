using System;
using System.Linq;

namespace SortAlgorithms.Auxiliaries
{
    internal static class ArrayGenerator
    {
        public static int [] RandomArray(int size)
        {
            var rand = new Random();
            var RandomArray = new int[size];

            for (var i = 0; i < size; i++)
                RandomArray[i] = rand.Next(0, size);

            return RandomArray;
        }

        public static int [] SortedAscArray(int size)
        {
            var temp = RandomArray(size);
            Array.Sort(temp);
            return temp;
        }

        public static int[] SortedDscArray(int size)
        {
            var temp = SortedAscArray(size);
            Array.Reverse(temp);
            return temp;
        }

        public static int[] ConstArray(int size)
        {
            var rand = new Random();
            var temp = new int[size];
            var Value = rand.Next(0, size);
            for (var i = 0; i < size; i++)
                temp[i] = Value;

            return temp;
        }

        public static int [] AShapeArray(int size)
        {
            var temp = SortedAscArray(size);
            var part1 = temp.Skip(0).Take(size / 2).ToArray();
            var part2 = temp.Skip(size / 2).Take(size).ToArray();
            Array.Reverse(part2);
            temp = part1.Concat(part2).ToArray();
            return temp;
        }

        public static int[] VShapeArray(int size)
        {
            var temp = SortedAscArray(size);
            var part1 = temp.Skip(0).Take(size / 2).ToArray();
            var part2 = temp.Skip(size / 2).Take(size).ToArray();
            Array.Reverse(part1);
            temp = part1.Concat(part2).ToArray();
            return temp;
        }
    }
}
