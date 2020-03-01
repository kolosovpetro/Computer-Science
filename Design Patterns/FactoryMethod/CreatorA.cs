using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class CreatorA : Creator
    {
        public override IProduct CreateProduct()
        {
            return new ProductA();
        }
    }
}
