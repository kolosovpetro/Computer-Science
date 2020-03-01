using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class PublicTransportStrategy : IRouteStrategy
    {
        public void BuildRoute(Point A, Point B)
        {
            double ShortestPath = Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
            Console.WriteLine($"Public transport route between points {A} and {B} is build sucessfully.");
            Console.WriteLine($"Shortest Path is: {ShortestPath}");
        }
    }
}
