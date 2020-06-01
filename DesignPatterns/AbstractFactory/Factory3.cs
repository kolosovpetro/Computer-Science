using AbstractFactory;
using AbstractFactory.Abstract_Products;
using AbstractFactory.Concrete_Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Factory3 : IAbstractFactory
    {
        public IProductA CreateProductA()
        {
            throw new NotImplementedException();
        }

        public IProductB CreateProductB()
        {
            throw new NotImplementedException();
        }

        public IProductC CreateProductC()
        {
            throw new NotImplementedException();
        }
    }
}
