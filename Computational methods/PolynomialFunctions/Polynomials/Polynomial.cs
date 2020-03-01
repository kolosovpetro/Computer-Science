using System;

namespace PolynomialFunctions
{
    class Polynomial : IFormable, IValuable, IDerivativable, IRootable
    {
        public double[] Coefficients { get; private set; }
        public string Derivative { get { return this.GetDerivative(); } }
        public string Display { get { return this.PolynomDisplayForm(); } }
        public Polynomial(params double[] newCoefficients)
        {
            this.Coefficients = newCoefficients;
        }
        public string PolynomDisplayForm(string Variable = "x")
        {
            int Size = this.Coefficients.Length;
            string PolynomialForm = $"f({Variable}) = {Coefficients[0]}*{Variable}^{Size - 1}";

            for (int i = 1; i < Size; i++)
                PolynomialForm += $" + {Coefficients[i]}*{Variable}^{Size - 1 - i}";

            return PolynomialForm;
        }
        public double ValueInPoint(double Point)
        {
            double Result = default;
            int Size = Coefficients.Length;

            for (int i = 0; i < Size; i++)
                Result += Coefficients[i] * Math.Pow(Point, Size - 1 - i);

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
        public string DisplayPoynomialValues()
        {
            string Values = default;

            double[] temp = ValuesSet();

            for (int i = 0; i < temp.Length; i++)
                Values += $"f({i - 1}) = {temp[i]}\n";

            return Values;
        }

        public string GetDerivative(string Variable = "x")
        {
            int Size = this.Coefficients.Length;
            string Derivative = $"f({Variable}) = {(Size - 1) * Coefficients[0]}*{Variable}^{Size - 2}";

            for (int i = 1; i < Size - 1; i++)
                Derivative += $" + {(Size - 1 - i) * Coefficients[i]}*{Variable}^{Size - 2 - i}";

            return Derivative;
        }

        public double DerivativeValue(double Point)
        {
            if (Coefficients == null || Coefficients.Length == 0) 
                throw new Exception("Unable to calculate");

            double result = default;

            for (int i = 0; i < Coefficients.Length - 1; i++)
            {

                if (i != Coefficients.Length - 2)
                    result += (Coefficients.Length - 1 - i) * Coefficients[i] * (Math.Pow(Point, Coefficients.Length - 2 - i));
                else
                    result += (Coefficients.Length - 1 - i) * Coefficients[i];
            }

            return result;
        }


        public double GuessRoot(double initialGuess)
        {
            // works for testcase: (2, 5), (3, 4), (7, 1) and root = 5;

            for (int i = 0; i < 150; i++)
            {
                double newX = initialGuess;
                initialGuess = initialGuess - ValueInPoint(initialGuess) / DerivativeValue(initialGuess);
                double ApproxError = (initialGuess - newX) / initialGuess * 100;

                if (ApproxError == 0)
                    return newX;
            }

            throw new RootNotFoundException("Root not found.");
        }
    }
}
