using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            IComponent c1 = new Component();
            c1.Execute();
            IComponent c2 = new DecoratorA(c1);
            c2.Execute();
            IComponent c3 = new DecoratorB(c2);
            c3.Execute();
            IComponent c4 = new DecoratorC(c3);
            c4.Execute();
        }
    }
}
