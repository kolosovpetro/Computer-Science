using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CreatorA c1 = new CreatorA();
            IProduct p1 = c1.CreateProduct();
            p1.DoSomething();
            CreatorB c2 = new CreatorB();
            IProduct p2 = c2.CreateProduct();
            p2.DoSomething();
        }
    }
}
