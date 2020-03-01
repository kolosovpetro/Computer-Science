using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Component : IComponent
    {
        public void Execute()
        {
            Console.WriteLine($"E-Mail Message was sent.");
        }
    }
}
