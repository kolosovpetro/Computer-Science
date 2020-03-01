using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalSystems
{
    interface INumericalForm
    {
        string GetForm(double Number);
        double GetDecimal(string Number);
    }
}
