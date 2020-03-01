using System;
using System.Linq;

namespace LinearEquationsSolver
{
    class Equation
    {
        private string[] AugMatrixRow;
        private string EquationForm;

        public Equation(string NewAugMatrixRow)
        {
            this.AugMatrixRow = SetAugMatrixRow(NewAugMatrixRow);
            this.EquationForm = SetEquationForm(AugMatrixRow);
        }
        private string[] SetAugMatrixRow(string Input)
        {
            for (int i = 0; i < Input.Length; i++)
            {
                if (!double.TryParse(Input[i].ToString(), out double s) && Input[i] != ' ' && Input[i] != '-')
                    throw new Exception("Wrong character detected");
            }

            string[] arrayWithNulls = Input.Split(' ');

            for (int i = 0; i < arrayWithNulls.Length; i++)
            {
                arrayWithNulls[i] = arrayWithNulls[i].Replace(' '.ToString(), null);
            }

            int size = arrayWithNulls.Count(s => s != " ");

            string[] arrayNoNulls = new string[size];

            for (int i = 0; i < size; i++)
            {
                if (arrayWithNulls[i] != null)
                {
                    arrayNoNulls[i] = arrayWithNulls[i];
                }
            }

            return arrayNoNulls;
        }
        public static string SetEquationForm(string[] Entry)
        {
            int index = 1;
            string equation = null;

            for (int i = 0; i < Entry.Length; i++)
            {
                if (i == 0)
                {
                    equation += $"{Entry[i]}*x{index}";
                    index++;
                }

                else if (i == Entry.Length - 1)
                    equation += $" = {Entry[i]}";

                else
                {
                    equation += $" + {Entry[i]}*x{index}";
                    index++;
                }
            }

            return equation;
        }
        public string[] GetAugMatrixRow { get { return this.AugMatrixRow; } }
        public string GetEquationForm { get { return this.EquationForm; } }
    }
}
