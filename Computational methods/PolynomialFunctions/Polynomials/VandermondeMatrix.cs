using System;
using System.Collections.Generic;

namespace PolynomialFunctions.Polynomials
{
    internal class VandermondeMatrix
    {
        private List<Point> Points { get; }
        public int Order => Points.Count - 1;
        public double[][] AugmentedMatrix => GetAugmentedMatrix();

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
            var x = p.X;
            var y = p.Y;
            var size = Order + 2;
            var augmentedMatrixRow = new double[size];

            for (var i = 0; i < size; i++)
                augmentedMatrixRow[i] = Math.Pow(x, size - 2 - i);

            augmentedMatrixRow[size - 1] = y;
            
            return augmentedMatrixRow;
        }

        private double[][] GetAugmentedMatrix()
        {
            var size = Order + 1;
            var augmentedMatrix = new double[size][];

            for (var i = 0; i < augmentedMatrix.Length; i++)
                augmentedMatrix[i] = GetAugmentedMatrixRow(Points[i]);

            return augmentedMatrix;
        }
    }
}
