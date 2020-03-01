using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            IIncompatableClass ic1 = new IncompatableClass();
            IAdapter ca1 = new CurrentAdapter();
            IService s1 = ca1.Receive(ic1);
            Console.WriteLine($"The object {s1.GetType()} was sucesfully created by means of Adapter Pattern.");
        }
    }
}
