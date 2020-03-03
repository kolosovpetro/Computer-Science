using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    interface IRouteStrategy
    {
        void BuildRoute(Point A, Point B);
    }
}
