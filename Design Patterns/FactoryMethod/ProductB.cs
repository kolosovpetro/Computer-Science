using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class ProductB : IProduct
    {
        public void DoSomething()
        {
            Console.WriteLine($"I'm instance of class {this.GetType()} and I do singing: Lalala-lala-lala-uhhhu");
        }
    }
}
