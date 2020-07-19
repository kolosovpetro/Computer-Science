using NumericalIntegration.Exceptions;

namespace NumericalIntegration
{
    internal class Integrator
    {
        private double Min { get; }
        private double Max { get; }
        private Function Function { get; }

        public Integrator(double min, double max, Function function)
        {
            if (min > max)
                throw new WrongIntegralBoundsException("Upper bound cannot be lesser than lower.");
            Min = min;
            Max = max;
            Function = function;
        }

        public Integrator(double min, double max)
        {
            if (min > max)
                throw new WrongIntegralBoundsException("Upper bound cannot be lesser than lower.");
            Min = min;
            Max = max;
            Function = new Function();
        }

        public double TrapezoidalMethod(int precision)
        {
            var h = (Max - Min) / precision;
            var integral = h / 2 * Function.ValueInPoint(Min) + h / 2 * Function.ValueInPoint(Max);

            double sum = default;

            for (var i = 1; i < precision - 1; i++)
                sum += Function.ValueInPoint(X(i, h)) * h;

            integral += sum;
            return integral;
        }

        public double TrapezoidalMethod(string infix, int precision)
        {
            var h = (Max - Min) / precision;
            var integral = h / 2 * Function.ValueInPoint(infix, Min)
                           + h / 2 * Function.ValueInPoint(infix, Max);

            double sum = default;

            for (var i = 1; i < precision - 1; i++)
                sum += Function.ValueInPoint(infix, X(i, h)) * h;

            integral += sum;
            return integral;
        }

        public double SimpsonMethod(int precision)
        {
            var h = (Max - Min) / precision;
            var integral = h / 3 * (Function.ValueInPoint(Min) + Function.ValueInPoint(Max));

            for (var i = 1; i < precision; i++)
            {
                if (i % 2 != 0)
                    integral += h / 3 * 4 * Function.ValueInPoint(X(i, h));

                if (i % 2 == 0)
                    integral += h / 3 * 2 * Function.ValueInPoint(X(i, h));
            }

            return integral;
        }

        public double SimpsonMethod(string infix, int precision)
        {
            var h = (Max - Min) / precision;

            var integral = h / 3 * (Function.ValueInPoint(infix, Min) + Function.ValueInPoint(infix, Max));

            for (var i = 1; i < precision; i++)
            {
                if (i % 2 != 0)
                    integral += h / 3 * 4 * Function.ValueInPoint(infix, X(i, h));

                if (i % 2 == 0)
                    integral += h / 3 * 2 * Function.ValueInPoint(infix, X(i, h));
            }

            return integral;
        }

        private double X(double i, double h)
        {
            return Min + i * h;
        }
    }
}