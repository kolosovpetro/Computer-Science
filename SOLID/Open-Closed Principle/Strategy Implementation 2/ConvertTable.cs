using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalSystems
{
    class ConvertTable
    {
        readonly char[] ConvTable = new char[] 
        { 
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' 
        };

        public char[] GetConvTable
        {
            get
            {
                return ConvTable;
            }
        }
    }
}
