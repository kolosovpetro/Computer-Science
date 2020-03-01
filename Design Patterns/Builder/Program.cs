using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Director dir = new Director();
            SmallHouseBuilder shb = new SmallHouseBuilder();
            dir.BuildSmallHouse(shb);
            SmallHouse sh = shb.GetResult();
            Console.WriteLine($"The instance of class {sh.GetType()} is created with characteristics: ");
            Console.WriteLine($"Roof square: {sh.ShowRoofSquare}");
            Console.WriteLine($"Number of Walls: {sh.ShowWallsNumber}");
            Console.WriteLine($"Number of Windows: {sh.ShowWindowsNumber}");
            Console.WriteLine($"Number of Doors: {sh.ShowDoorsNumber}");
        }
    }
}
