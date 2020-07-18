using Factory_Method.Abstract_Products;
using Factory_Method.Concrete_Products;

namespace Factory_Method
{
    internal class Factory1 : IAbstractFactory
    {
        public IProductA CreateProductA()
        {
            return new ProductA1();
        }

        public IProductB CreateProductB()
        {
            return new ProductB1();
        }

        public IProductC CreateProductC()
        {
            return new ProductC1();
        }
    }
}
