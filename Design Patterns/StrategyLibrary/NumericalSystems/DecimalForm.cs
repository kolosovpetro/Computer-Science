using System;
using System.Linq;

namespace NumericalSystems
{
    class DecimalForm : INumericalForm
    {
        string Number;
        double Decimal;
        readonly int Base;
        ConvertTable Table;

        public DecimalForm()
        {
            this.Base = 10;
            this.Table = new ConvertTable();
        }
        public double GetDecimal(string Number)
        {
            int Base = 10;
            double DecimalForm = 0;
            char[] array = Number.ToCharArray();

            for (int i = 0; i < array.Length; i++)
                DecimalForm += double.Parse(array[i].ToString()) * Math.Pow(Base, i);

            return Base;
        }

        public string GetForm(double DecimalForm)
        {
            string result = null;
            while ((int)DecimalForm > 0)
            {
                int remainder = (int)DecimalForm % Base;
                result += remainder;
                DecimalForm /= Base;
            }


            return ReverseString(result);
        }

        private string ReverseString(string Word)
        {
            return string.Join("", Word.Reverse());
        }
    }
}
