using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalSystems
{
    class Converter
    {
        double Number;
        INumericalForm Form;

        public Converter(double newNumber)
        {
            this.Number = newNumber;
        }

        public void NewStrategy(INumericalForm newForm)
        {
            this.Form = newForm;
        }

        public string GetForm()
        {
            return this.Form.GetForm(Number);
        }
    }
}
