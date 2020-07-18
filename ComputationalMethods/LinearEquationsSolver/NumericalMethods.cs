using System;
using System.Collections.Generic;

namespace LinearEquationsSolver
{
    internal class NumericalMethods
    {
        public static double[][] ForwardElimination(double[][] augmentedMatrix)
        {
            var n0 = augmentedMatrix.Length;
            var n1 = augmentedMatrix[0].Length;

            for (var k = 0; k < n0; k++)
            {
                for (var i = k + 1; i < n1 - 1; i++)
                {
                    var factor = augmentedMatrix[i][k] / augmentedMatrix[k][k];

                    for (var j = k; j < n1; j++)
                    {
                        augmentedMatrix[i][j] -= factor * augmentedMatrix[k][j];
                    }
                }
            }

            return augmentedMatrix;
        }

        public double[] SolveLinearEquations(double[][] rows)
        {
            var length = rows[0].Length;

            for (var i = 0; i < rows.Length - 1; i++)
            {
                if (Math.Abs(rows[i][i]) < 0 && !Pivot(rows, i, i))
                    return null;

                // Forward Elimination
                for (var j = i; j < rows.Length; j++)
                {
                    var arr1 = new double[length];

                    for (var x = 0; x < length; x++)
                    {
                        arr1[x] = rows[j][x];
                        if (Math.Abs(rows[j][i]) < 0)
                            arr1[x] = arr1[x] / rows[j][i];
                    }

                    rows[j] = arr1;
                }


                for (var y = i + 1; y < rows.Length; y++)
                {
                    var arr2 = new double[length];
                    for (var g = 0; g < length; g++)
                    {
                        arr2[g] = rows[y][g];

                        if (Math.Abs(rows[y][i]) > 0)
                        {
                            arr2[g] = arr2[g] - rows[i][g];
                        }
                    }

                    rows[y] = arr2;
                }
            }

            return BackwardSubstitution(rows);
        }

        private static bool Pivot(IList<double[]> rows, int row, int column)
        {
            var swapped = false;

            for (var z = rows.Count - 1; z > row; z--)
            {
                if (Math.Abs(rows[z][row]) > 0)
                {
                    var temp = rows[z];
                    rows[z] = rows[column];
                    rows[column] = temp;
                    swapped = true;
                }
            }

            return swapped;
        }

        private static double[] BackwardSubstitution(double[][] rows)
        {
            var length = rows[0].Length;
            var result = new double[rows.Length];
            for (var i = rows.Length - 1; i >= 0; i--)
            {
                var val = rows[i][length - 1];

                for (var x = length - 2; x > i - 1; x--)
                    val -= rows[i][x] * result[x];

                result[i] = val / rows[i][i];

                if (!IsValidResult(result[i]))
                    return null;
            }

            return result;
        }

        private static bool IsValidResult(double result)
        {
            return !(double.IsNaN(result) || double.IsInfinity(result));
        }
    }
}