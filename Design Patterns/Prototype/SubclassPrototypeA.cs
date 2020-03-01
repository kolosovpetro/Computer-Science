using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class SubclassPrototypeA : ConcretePrototypeA
    {
        public SubclassPrototypeA(int newWidth, int newHeight, int newLength) : base(newWidth, newHeight, newLength) { }
    }
}
