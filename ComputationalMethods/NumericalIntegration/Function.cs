using System;
using System.Linq;
using NumericalIntegration.RPN;

namespace NumericalIntegration
{
    internal class Function
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

        private static double[] GetCoefficients(string input)
        {
            var tokens = input.Split(' ');

            if (tokens.Contains(" "))
                throw new FormatException("Wrong input format.");

            var coefficients = new double[tokens.Length];

            for (var i = 0; i < coefficients.Length; i++)
                coefficients[i] = double.Parse(tokens[i]);

            return coefficients;
        }

        public double ValueInPoint(double variable)
        {
            var size = Coefficients.Length;

            double newValue = default;

            for (var i = 0; i < size; i++)
                newValue += Coefficients[i] * Math.Pow(variable, size - 1 - i);

            return newValue;
        }

        public double ValueInPoint(string infix, double variable)
        {
            var postfix = RpnCalculator.InfixToPostfix(infix, variable);
            var result = RpnCalculator.PostfixEvaluator(postfix);
            return result;
        }

        private string NewPrintForm(string variable = "x")
        {
            var length = Coefficients.Length;

            var polynomialForm = $"f({variable}) = {Coefficients[0]}{variable}^{length - 1}";

            for (var i = 1; i < length - 1; i++)
                polynomialForm += $" + {Coefficients[i]}{variable}^{length - 1 - i}";

            polynomialForm += $" + {Coefficients[length - 1]}";

            return polynomialForm;
        }
    }
}