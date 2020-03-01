using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Point(int newX, int newY)
        {
            this.X = newX;
            this.Y = newY;
        }
    }
}
