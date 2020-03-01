using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    abstract class Creator : IProduct
    {
        public void DoSomething()
        {

        }

        public virtual IProduct CreateProduct()
        {
            return null;
        }
    }
}
