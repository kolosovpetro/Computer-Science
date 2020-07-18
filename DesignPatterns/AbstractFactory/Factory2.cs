using Factory_Method.Abstract_Products;
using Factory_Method.Concrete_Products;

namespace Factory_Method
{
    internal class Factory2 : IAbstractFactory
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