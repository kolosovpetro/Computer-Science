using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            ITreeRoot sl1 = new SingleLeaf(5);
            ITreeRoot sl2 = new SingleLeaf(6);
            ITreeRoot sl3 = new SingleLeaf(7);
            ITreeRoot sl4 = new SingleLeaf(8);
            ITreeRoot cl1 = new CompoudLeaf(9);
            Console.WriteLine($"The object {cl1} has been sucesfully created.");
            cl1.Add(sl1);
            cl1.Add(sl2);
            cl1.Add(sl3);
            cl1.Add(sl4);
            Console.WriteLine($"Weight of object {cl1} is {cl1.GetWholeWeight()}");
        }
    }
}
