using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            IPrototype p1 = new ConcretePrototypeA(3, 5, 7);
            ConcretePrototypeA p2 = (ConcretePrototypeA)p1.Clone();

            // To show that prvious copy was successful, we recast it to Prototype and show the properties got

            // Here is report
            Console.WriteLine($"Object p1 of type {p1.GetType().Name} was succesfully cloned to p2 of type {p2.GetType().Name} with parameters: ");
            Console.WriteLine($"Width: {p2.GetWidth}");
            Console.WriteLine($"Height: {p2.GetHeight}");
            Console.WriteLine($"Length: {p2.GetLength}");

            SubclassPrototypeA p4 = new SubclassPrototypeA(9, 7, 3);
            SubclassPrototypeA p5 = (SubclassPrototypeA)p4.Clone();
            Console.WriteLine($"Object p1 of type {p4.GetType().Name} was succesfully cloned to p2 of type {p5.GetType().Name} with parameters: ");
            Console.WriteLine($"Width: {p5.GetWidth}");
            Console.WriteLine($"Height: {p5.GetHeight}");
            Console.WriteLine($"Length: {p5.GetLength}");


        }
    }
}
