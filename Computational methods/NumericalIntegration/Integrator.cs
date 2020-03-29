﻿using NumericalIntegration.Exceptions;
using NumericalIntegration.Interfaces;

namespace NumericalIntegration
{
    internal class Integrator : IDiscreteIntegrable
    {
        public double Min { get; }
        public double Max { get; }
        public Function Function { get; }

        public Integrator(double newMin, double newMax, Function newFunction)
        {
            if (newMin > newMax)
                throw new WrongIntegralBoundsException("Upper bound cannot be lesser than lower.");
            Min = newMin;
            Max = newMax;
            Function = newFunction;
        }

        public Integrator(double newMin, double newMax)
        {
            if (newMin > newMax)
                throw new WrongIntegralBoundsException("Upper bound cannot be lesser than lower.");
            Min = newMin;
            Max = newMax;
            Function = new Function();
        }

        public double TrapezoidalMethod(int precision)
        {
            double h = (Max - Min) / precision;
            double integral = h / 2 * Function.ValueInPoint(Min) + h / 2 * Function.ValueInPoint(Max);

            double sum = default;

            for (int i = 1; i < precision - 1; i++)
                sum += Function.ValueInPoint(X(i, h)) * h;

            integral += sum;
            return integral;
        }

        public double TrapezoidalMethod(string infix, int precision)
        {
            double h = (Max - Min) / precision;
            double integral = (h / 2) * Function.ValueInPoint(infix, Min) + (h / 2) * Function.ValueInPoint(infix, Max);

            double sum = default;

            for (int i = 1; i < precision - 1; i++)
                sum += Function.ValueInPoint(infix, X(i, h)) * h;

            integral += sum;
            return integral;
        }

        public double SimpsonMethod(int precision)
        {
            double h = (Max - Min) / precision;
            double integral = h / 3 * (Function.ValueInPoint(Min) + Function.ValueInPoint(Max));

            for (int i = 1; i < precision; i++)
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
            double h = (Max - Min) / precision;

            double integral = h / 3 * (Function.ValueInPoint(infix, Min) + Function.ValueInPoint(infix, Max));

            for (int i = 1; i < precision; i++)
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
