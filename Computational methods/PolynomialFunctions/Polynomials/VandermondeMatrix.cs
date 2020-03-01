using System;
using System.Collections.Generic;

namespace PolynomialFunctions
{
    class VandermondeMatrix : IOrderable
    {
        public List<Point> Points { get; private set; }
        public int Order { get { return this.Points.Count - 1; } }
        public double[][] AugVanderMarix { get { return this.GetAugVanderMarix(); } }
        public double[] Solutions { get { return this.GetSolutions(); } }

        public VandermondeMatrix()
        {
            this.Points = new List<Point>();
        }

        public void PrintOrder()
        {
            Console.WriteLine($"Resulting polynomial will be of the order {this.Order}.");
        }

        public void AddPoint(Point p)
        {
            Points.Add(p);
        }
        private double[] GetAugVanderMarixRow(Point p)
        {
            int X = p.X;
            int Y = p.Y;
            int size = this.Order + 2;
            double[] AugVanderMarixRow = new double[size];

            for (int i = 0; i < size; i++)
                AugVanderMarixRow[i] = Math.Pow(X, size - 2 - i);

            AugVanderMarixRow[size - 1] = Y;
            return AugVanderMarixRow;
        }
        private double[][] GetAugVanderMarix()
        {
            int Size = this.Order + 1;
            double[][] AugVanderMarix = new double[Size][];

            for (int i = 0; i < AugVanderMarix.Length; i++)
                AugVanderMarix[i] = GetAugVanderMarixRow(Points[i]);

            return AugVanderMarix;
        }


        private double[] GetSolutions()
        {
            return NumericalMethods.SolveLinearEquations(this.AugVanderMarix);
        }
    }
}
