using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class ConcreteImplementation2 : IImplementation
    {
        public void Method1()
        {
            Console.WriteLine($"Implementation of Method 1 from {this.GetType()}");
        }

        public void Method2()
        {
            Console.WriteLine($"Implementation of Method 2 from {this.GetType()}");
        }

        public void Method3()
        {
            Console.WriteLine($"Implementation of Method 3 from {this.GetType()}");
        }
    }
}
