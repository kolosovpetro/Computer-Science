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
    class Factory2 : IAbstractFactory
    {
        public IProductA CreateProductA()
        {
            return new ProductA2();
        }

        public IProductB CreateProductB()
        {
            return new ProductB2();
        }

        public IProductC CreateProductC()
        {
            return new ProductC2();
        }
    }
}
