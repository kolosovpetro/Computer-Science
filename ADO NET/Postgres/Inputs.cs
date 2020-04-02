using System;

namespace Postgres
{
    internal class Inputs
    {
        public static int ReadInt()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Write an integer: ");
                    int num = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Null reference."));
                    return num;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + " Try again.");
                }
            }
        }

        public static double ReadDouble()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Write a double: ");
                    double num = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Null reference."));
                    return num;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + " Try again.");
                }
            }
        }
    }
}
