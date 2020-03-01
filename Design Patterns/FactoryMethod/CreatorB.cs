using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class CreatorB : Creator
    {
        public override IProduct CreateProduct()
        {
            return new ProductB();
        }
    }
}
