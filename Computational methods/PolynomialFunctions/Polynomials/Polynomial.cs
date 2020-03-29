using System;
using PolynomialFunctions.Exceptions;
using PolynomialFunctions.Interfaces;

namespace PolynomialFunctions.Polynomials
{
    internal class Polynomial : IPolynomialFormat, IValuable, IDerivative, IRoot
    {
        public double[] Coefficients { get; }
        public string Derivative => GetDerivative();
        public string Display => DisplayPolynomialForm();

        public Polynomial(params double[] coefficients)
        {
            Coefficients = coefficients;
        }

        public string DisplayPolynomialForm(string variable = "x")
        {
            int length = Coefficients.Length;

            string PolynomialForm = $"f({variable}) = {Coefficients[0]}*{variable}^{length - 1}";

            for (int i = 1; i < length; i++)
                PolynomialForm += $" + {Coefficients[i]}*{variable}^{length - 1 - i}";

            return PolynomialForm;
        }

        public double ValueInPoint(double point)
        {
            double Result = default;
            int Size = Coefficients.Length;

            for (int i = 0; i < Size; i++)
                Result += Coefficients[i] * Math.Pow(point, Size - 1 - i);

            return Result;
        }

        public double[] ValuesSet()
        {
            double[] PolynomialValues = new double[3];
            PolynomialValues[0] = ValueInPoint(-1);
            PolynomialValues[1] = ValueInPoint(0);
            PolynomialValues[2] = ValueInPoint(1);
            return PolynomialValues;
        }

        public string DisplayPolynomialValues()
        {
            string Values = default;

            double[] temp = ValuesSet();

            for (int i = 0; i < temp.Length; i++)
                Values += $"f({i - 1}) = {temp[i]}\n";

            return Values;
        }

        public string GetDerivative(string variable = "x")
        {
            int length = Coefficients.Length;

            string derivative = $"f({variable}) = {(length - 1) * Coefficients[0]}*{variable}^{length - 2}";

            for (int i = 1; i < length - 1; i++)
                derivative += $" + {(length - 1 - i) * Coefficients[i]}*{variable}^{length - 2 - i}";

            return derivative;
        }

        public double DerivativeValue(double point)
        {
            if (Coefficients == null || Coefficients.Length == 0) 
                throw new Exception("Unable to calculate");

            double result = default;

            for (int i = 0; i < Coefficients.Length - 1; i++)
            {

                if (i != Coefficients.Length - 2)
                    result += (Coefficients.Length - 1 - i) * Coefficients[i] * (Math.Pow(point, Coefficients.Length - 2 - i));
                else
                    result += (Coefficients.Length - 1 - i) * Coefficients[i];
            }

            return result;
        }


        public double GuessRoot(double initialGuess)
        {

            for (int i = 0; i < 150; i++)
            {
                double newX = initialGuess;
                initialGuess = initialGuess - ValueInPoint(initialGuess) / DerivativeValue(initialGuess);
                double ApproxError = (initialGuess - newX) / initialGuess * 100;

                if (Math.Abs(ApproxError) < 0.1)
                    return newX;
            }

            throw new RootNotFoundException("Root not found.");
        }
    }
}
