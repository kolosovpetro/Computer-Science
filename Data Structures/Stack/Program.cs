using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> s1 = new Stack<string>(5);
            s1.Push("entry 1");
            s1.Push("entry 2");
            s1.Push("entry 3");
            foreach (var item in s1)
            {
                Console.WriteLine(item + " ");
            }

            Console.WriteLine(s1[0]);
            Console.WriteLine(s1[1]);
            Console.WriteLine(s1[2]);
        }
    }
}
