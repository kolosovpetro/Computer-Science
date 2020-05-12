using System;
using System.Linq;

namespace LinearEquationsSolver
{
    internal class Equation
    {
        public string[] GetAugMatrixRow { get; }

        public string GetEquationForm { get; }

        public Equation(string newAugMatrixRow)
        {
            GetAugMatrixRow = SetAugMatrixRow(newAugMatrixRow);
            GetEquationForm = SetEquationForm(GetAugMatrixRow);
        }
        private string[] SetAugMatrixRow(string input)
        {
            foreach (var item in input)
            {
                if (!double.TryParse(item.ToString(), out _) && item != ' ' && item != '-')
                    throw new Exception("Wrong character detected");
            }

            var arrayWithNulls = input.Split(' ');

            for (int i = 0; i < arrayWithNulls.Length; i++)
            {
                arrayWithNulls[i] = arrayWithNulls[i].Replace(' '.ToString(), null);
            }

            int size = arrayWithNulls.Count(s => s != " ");

            var arrayNoNulls = new string[size];

            for (int i = 0; i < size; i++)
            {
                arrayNoNulls[i] = arrayWithNulls[i];
            }

            return arrayNoNulls;
        }

        private static string SetEquationForm(string[] entry)
        {
            int index = 1;
            string equation = null;

            for (int i = 0; i < entry.Length; i++)
            {
                if (i == 0)
                {
                    equation += $"{entry[i]}*x{index}";
                    index++;
                }

                else if (i == entry.Length - 1)
                    equation += $" = {entry[i]}";

                else
                {
                    equation += $" + {entry[i]}*x{index}";
                    index++;
                }
            }

            return equation;
        }
    }
}
