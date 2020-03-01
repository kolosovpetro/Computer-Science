using System;

namespace NumericalIntegration
{
    class Auxiliary
    {
        public static void printArray(Array type)
        {
            foreach (var item in type)
            {
                Console.Write(item.ToString() + " ");
            }
        }
        public static void Print2Darray(double[,] Array)
        {
            for (int i = 0; i < Array.GetLength(0); i++)
            {
                for (int j = 0; j < Array.GetLength(1); j++)
                {
                    Console.Write(Array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static int InputOfTypeInt(int Min, int Max)
        {
            string ToParse;
            int result;
            while (true)
            {
                ToParse = Console.ReadLine();
                try
                {
                    result = int.Parse(ToParse);
                    if (result < Min || result > Max)
                        throw new FormatException();
                        break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return result;
        }
    }
}
