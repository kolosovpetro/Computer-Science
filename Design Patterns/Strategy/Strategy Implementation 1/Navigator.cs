using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Navigator
    {
        Point A;
        Point B;
        IRouteStrategy RouteStrategy;
        public Navigator(Point newA, Point newB)
        {
            this.A = newA;
            this.B = newB;
        }
        public void SetStrategy(IRouteStrategy strategy)
        {
            this.RouteStrategy = strategy;
        }
        public void GetRoute()
        {
            this.RouteStrategy.BuildRoute(A, B);
        }
    }
}
