using System;
using System.Linq;

namespace NumericalIntegration
{
    class Function : IPolynomialable
    {
        public double[] Coefficients { get; private set; }
        public string PrintForm { get; private set; }

        public Function()
        {

        }

        public Function(string Coefficients)
        {
            this.Coefficients = GetCoefficients(Coefficients);
            this.PrintForm = NewPrintForm();
        }
        public double[] GetCoefficients(string Input)
        {
            string[] tokens = Input.Split(' ');

            if (tokens.Contains(" "))
                throw new FormatException();

            double[] Coeffs = new double[tokens.Length];

            for (int i = 0; i < Coeffs.Length; i++)
                Coeffs[i] = double.Parse(tokens[i]);

            return Coeffs;
        }
        public double ValueInPoint(double Variable)
        {
            int size = this.Coefficients.Length;
            double newValue = 0;

            for (int i = 0; i < size; i++)
                newValue += Coefficients[i] * Math.Pow(Variable, size - 1 - i);

            return newValue;
        }
        public double ValueInPoint(string Infix, double Variable)
        {
            string postfix = RPNCalculator.InfixToPostfix(Infix, Variable);
            double result = RPNCalculator.PostfixEvaluator(postfix);
            return result;
        }
        private string NewPrintForm(string Variable = "x")
        {
            int size = this.Coefficients.Length;
            string PolynomialForm = $"f({Variable}) = {Coefficients[0]}{Variable}^{size - 1}";

            for (int i = 1; i < size - 1; i++)
                PolynomialForm += $" + {Coefficients[i]}{Variable}^{size - 1 - i}";

            PolynomialForm += $" + {Coefficients[size - 1]}";
            return PolynomialForm;
        }
    }
}
