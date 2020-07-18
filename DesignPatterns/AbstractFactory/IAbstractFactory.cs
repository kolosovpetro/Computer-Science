using Factory_Method.Abstract_Products;

namespace Factory_Method
{
    internal interface IAbstractFactory
    {
        IProductA CreateProductA();
        IProductB CreateProductB();
        IProductC CreateProductC();
    }
}
