namespace NumericalIntegration
{
    class Integrator : IDiscreteIntegrable
    {
        public double Min { get; private set; }
        public double Max { get; private set; }
        public Function Function { get; private set; }
        public Integrator(double newMin, double newMax, Function newFunction)
        {
            if (newMin > newMax)
                throw new WrongIntegralBoundsException("Upper bound cannot be lesser than lower.");
            this.Min = newMin;
            this.Max = newMax;
            this.Function = newFunction;
        }
        public Integrator(double newMin, double newMax)
        {
            if (newMin > newMax)
                throw new WrongIntegralBoundsException("Upper bound cannot be lesser than lower.");
            this.Min = newMin;
            this.Max = newMax;
            this.Function = new Function();
        }
        public double TrapezoidalMethod(int Precision)
        {
            double h = (Max - Min) / Precision;
            double Int = (h / 2) * Function.ValueInPoint(Min) + (h / 2) * Function.ValueInPoint(Max);

            double Sum = 0;
            for (int i = 1; i < Precision - 1; i++)
                Sum += Function.ValueInPoint(X(i, h)) * h;

            Int += Sum;
            return Int;
        }
        public double TrapezoidalMethod(string Infix, int Precision)
        {
            double h = (Max - Min) / Precision;
            double Int = (h / 2) * Function.ValueInPoint(Infix, Min) + (h / 2) * Function.ValueInPoint(Infix, Max);

            double Sum = 0;
            for (int i = 1; i < Precision - 1; i++)
                Sum += Function.ValueInPoint(Infix, X(i, h)) * h;

            Int += Sum;
            return Int;
        }

        public double SimpsonMethod(int Precision)
        {
            double h = (Max - Min) / Precision;
            double Integral = h / 3 * (Function.ValueInPoint(Min) + Function.ValueInPoint(Max));

            for (int i = 1; i < Precision; i++)
            {
                if (i % 2 != 0)
                    Integral += h / 3 * 4 * Function.ValueInPoint(X(i, h));

                if (i % 2 == 0)
                    Integral += h / 3 * 2 * Function.ValueInPoint(X(i, h));
            }

            return Integral;
        }
        public double SimpsonMethod(string Infix, int Precision)
        {
            double h = (Max - Min) / Precision;
            double Integral = h / 3 * (Function.ValueInPoint(Infix, Min) + Function.ValueInPoint(Infix, Max));

            for (int i = 1; i < Precision; i++)
            {
                if (i % 2 != 0)
                    Integral += h / 3 * 4 * Function.ValueInPoint(Infix, X(i, h));

                if (i % 2 == 0)
                    Integral += h / 3 * 2 * Function.ValueInPoint(Infix, X(i, h));
            }

            return Integral;
        }

        private double X(double i, double h)
        {
            return Min + i * h;
        }
    }
}
