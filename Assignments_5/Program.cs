using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            int[] t = { 0 };
            Modify(ref i);
            Modify(t);
            Console.WriteLine(i);
            Console.WriteLine(t[0]);
        }

        static void Modify(ref int a)
        {
            a = 5;
        }
        static void Modify(int[] a)
        {
            a[0] = 5;
        }
    }
}
