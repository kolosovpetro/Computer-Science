using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Point A = new Point(3, 2);
            Point B = new Point(8, 10);
            Console.WriteLine($"Points {A} and {B} defined with the following coordinates: A = ({A.X}, {A.Y}), B = ({B.X}, {B.Y})");
            Navigator n1 = new Navigator(A, B);
            RoadStrategy r1 = new RoadStrategy();
            n1.SetStrategy(r1);
            n1.GetRoute();
            WalkingStrategy w1 = new WalkingStrategy();
            n1.SetStrategy(w1);
            n1.GetRoute();
        }
    }
}
