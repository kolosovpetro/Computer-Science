using System;

namespace LinearEquationsSolver
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
    }
}
