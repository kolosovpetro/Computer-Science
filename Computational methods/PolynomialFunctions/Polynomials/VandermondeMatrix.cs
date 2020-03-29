using System;
using System.Collections.Generic;

namespace PolynomialFunctions.Polynomials
{
    internal class VandermondeMatrix : IOrderable
    {
        public List<Point> Points { get; }
        public int Order => Points.Count - 1;
        public double[][] AugmentedMatrix => GetAugmentedMatrix();
        public double[] Solutions => GetSolutions();

        public VandermondeMatrix()
        {
            Points = new List<Point>();
        }

        public void PrintOrder()
        {
            Console.WriteLine($"Resulting polynomial will be of the order {Order}.");
        }

        public void AddPoint(Point p)
        {
            Points.Add(p);
        }

        private double[] GetAugmentedMatrixRow(Point p)
        {
            int X = p.X;
            int Y = p.Y;
            int size = Order + 2;
            double[] augmentedMatrixRow = new double[size];

            for (int i = 0; i < size; i++)
                augmentedMatrixRow[i] = Math.Pow(X, size - 2 - i);

            augmentedMatrixRow[size - 1] = Y;
            return augmentedMatrixRow;
        }

        private double[][] GetAugmentedMatrix()
        {
            int Size = Order + 1;
            double[][] augmentedMatrix = new double[Size][];

            for (int i = 0; i < augmentedMatrix.Length; i++)
                augmentedMatrix[i] = GetAugmentedMatrixRow(Points[i]);

            return augmentedMatrix;
        }


        private double[] GetSolutions()
        {
            return NumericalMethods.SolveLinearEquations(AugmentedMatrix);
        }
    }
}
