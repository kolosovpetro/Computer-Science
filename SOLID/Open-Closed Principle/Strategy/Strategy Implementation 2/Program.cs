using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalSystems
{
    class Program
    {
        static void Main(string[] args)
        {
            Converter c1 = new Converter(1000);
            BinaryForm b1 = new BinaryForm();
            c1.NewStrategy(b1);
            Console.WriteLine(c1.GetForm());
            OctalForm o1 = new OctalForm();
            c1.NewStrategy(o1);
            Console.WriteLine(c1.GetForm());
        }
    }
}
