using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postgres
{
    class Inputs
    {
        public static int ReadInt()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Write an integer: ");
                    int num = int.Parse(Console.ReadLine());
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
                    double num = double.Parse(Console.ReadLine());
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
