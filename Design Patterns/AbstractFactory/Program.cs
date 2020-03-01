using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.Abstract_Products;
using AbstractFactory.Concrete_Products;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory1 f1 = new Factory1();
            IProductA a1 = f1.CreateProductA();
            IProductB b1 = f1.CreateProductB();
            IProductC c1 = f1.CreateProductC();

            Factory2 f2 = new Factory2();
            IProductA a2 = f2.CreateProductA();
            IProductB b2 = f2.CreateProductB();
            IProductC c2 = f2.CreateProductC();
        }
    }
}
