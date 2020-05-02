using System;
using System.Linq;
using NumericalIntegration.Interfaces;
using NumericalIntegration.RPN;

namespace NumericalIntegration
{
    internal class Function : IPolynomial
    {
        private double[] Coefficients { get; }
        public string PrintForm { get; }

        public Function()
        {

        }

        public Function(string coefficients)
        {
            Coefficients = GetCoefficients(coefficients);
            PrintForm = NewPrintForm();
        }

        public double[] GetCoefficients(string input)
        {
            string[] tokens = input.Split(' ');

            if (tokens.Contains(" "))
                throw new FormatException("Wrong input format.");

            double[] coefficients = new double[tokens.Length];

            for (int i = 0; i < coefficients.Length; i++)
                coefficients[i] = double.Parse(tokens[i]);

            return coefficients;
        }

        public double ValueInPoint(double variable)
        {
            int size = Coefficients.Length;

            double newValue = default;

            for (int i = 0; i < size; i++)
                newValue += Coefficients[i] * Math.Pow(variable, size - 1 - i);

            return newValue;
        }

        public double ValueInPoint(string infix, double variable)
        {
            string postfix = RpnCalculator.InfixToPostfix(infix, variable);
            double result = RpnCalculator.PostfixEvaluator(postfix);
            return result;
        }
        private string NewPrintForm(string variable = "x")
        {
            int length = Coefficients.Length;

            string polynomialForm = $"f({variable}) = {Coefficients[0]}{variable}^{length - 1}";

            for (int i = 1; i < length - 1; i++)
                polynomialForm += $" + {Coefficients[i]}{variable}^{length - 1 - i}";

            polynomialForm += $" + {Coefficients[length - 1]}";

            return polynomialForm;
        }
    }
}
