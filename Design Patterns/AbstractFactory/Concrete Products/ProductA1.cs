using AbstractFactory.Abstract_Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Concrete_Products
{
    class ProductA1 : IProductA
    {
        public void DoSomething()
        {
            throw new NotImplementedException();
        }
    }
}
