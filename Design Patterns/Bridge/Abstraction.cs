using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Abstraction
    {
        IImplementation Implementation;
        public Abstraction(IImplementation newImplementation)
        {
            this.Implementation = newImplementation;
        }

        public void Feature1()
        {
            Implementation.Method1();
        }
        public void Feature2()
        {
            Implementation.Method2();
        }
        public void Feature3()
        {
            Implementation.Method3();
        }
    }
}
