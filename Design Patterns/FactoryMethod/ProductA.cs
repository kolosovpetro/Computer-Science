using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class ProductA : IProduct
    {
        public void DoSomething()
        {
            Console.WriteLine($"I'm instance of class {this.GetType()} and I counting: one, two, three, four, five, ....");
        }
    }
}
