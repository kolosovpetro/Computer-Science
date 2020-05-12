using System;
using PolynomialFunctions.Exceptions;

namespace PolynomialFunctions.Polynomials
{
    internal class Polynomial 
    {
        private double[] Coefficients { get; }
        public string Derivative => GetDerivative();
        public string Display => DisplayPolynomialForm();

        public Polynomial(params double[] coefficients)
        {
            Coefficients = coefficients;
        }

        public string DisplayPolynomialForm(string variable = "x")
        {
            var length = Coefficients.Length;

            var polynomialForm = $"f({variable}) = {Coefficients[0]}*{variable}^{length - 1}";

            for (int i = 1; i < length; i++)
                polynomialForm += $" + {Coefficients[i]}*{variable}^{length - 1 - i}";

            return polynomialForm;
        }

        public double ValueInPoint(double point)
        {
            double result = default;
            var size = Coefficients.Length;

            for (var i = 0; i < size; i++)
                result += Coefficients[i] * Math.Pow(point, size - 1 - i);

            return result;
        }

        private double[] ValuesSet()
        {
            var polynomialValues = new double[3];
            polynomialValues[0] = ValueInPoint(-1);
            polynomialValues[1] = ValueInPoint(0);
            polynomialValues[2] = ValueInPoint(1);
            return polynomialValues;
        }

        public string DisplayPolynomialValues()
        {
            string values = default;

            var temp = ValuesSet();

            for (var i = 0; i < temp.Length; i++)
                values += $"f({i - 1}) = {temp[i]}\n";

            return values;
        }

        public string GetDerivative(string variable = "x")
        {
            var length = Coefficients.Length;

            var derivative = $"f({variable}) = {(length - 1) * Coefficients[0]}*{variable}^{length - 2}";

            for (var i = 1; i < length - 1; i++)
                derivative += $" + {(length - 1 - i) * Coefficients[i]}*{variable}^{length - 2 - i}";

            return derivative;
        }

        private double DerivativeValue(double point)
        {
            if (Coefficients == null || Coefficients.Length == 0) 
                throw new Exception("Unable to calculate");

            double result = default;

            for (var i = 0; i < Coefficients.Length - 1; i++)
            {

                if (i != Coefficients.Length - 2)
                    result += (Coefficients.Length - 1 - i) * Coefficients[i] * Math.Pow(point, Coefficients.Length - 2 - i);
                
                else
                    result += (Coefficients.Length - 1 - i) * Coefficients[i];
            }

            return result;
        }


        public double GuessRoot(double initialGuess)
        {

            for (var i = 0; i < 150; i++)
            {
                double newX = initialGuess;
                initialGuess = initialGuess - ValueInPoint(initialGuess) / DerivativeValue(initialGuess);
                double approxError = (initialGuess - newX) / initialGuess * 100;

                if (Math.Abs(approxError) < 0.1)
                    return newX;
            }

            throw new RootNotFoundException("Root not found.");
        }
    }
}
