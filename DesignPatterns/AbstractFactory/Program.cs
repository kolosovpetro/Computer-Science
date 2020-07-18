using Factory_Method.Abstract_Products;

namespace Factory_Method
{
    internal static class Program
    {
        private static void Main()
        {
            IAbstractFactory f1 = new Factory1();
            var a1 = f1.CreateProductA();
            var b1 = f1.CreateProductB();
            var c1 = f1.CreateProductC();

            IAbstractFactory f2 = new Factory2();
            var a2 = f2.CreateProductA();
            var b2 = f2.CreateProductB();
            var c2 = f2.CreateProductC();
        }
    }
}
