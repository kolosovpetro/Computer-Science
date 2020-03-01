using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            Abstraction a1 = new Abstraction(new ConcreteImplementation1());
            a1.Feature1();
            a1.Feature2();
            a1.Feature3();
        }
    }
}
