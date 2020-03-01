using AbstractFactory.Abstract_Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    interface IAbstractFactory
    {
        IProductA CreateProductA();
        IProductB CreateProductB();
        IProductC CreateProductC();
    }
}
