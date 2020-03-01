namespace LinearEquationsSolver
{
    class NumericalMethods
    {
        public double[][] ForwardElimination(double[][] AugmentedMatrix)
        {
            int N0 = AugmentedMatrix.Length;
            int N1 = AugmentedMatrix[0].Length;

            for (int k = 0; k < N0; k++)
            {
                for (int i = k + 1; i < N1 - 1; i++)
                {
                    double factor = AugmentedMatrix[i][k] / AugmentedMatrix[k][k];

                    for (int j = k; j < N1; j++)
                    {
                        AugmentedMatrix[i][j] -= factor * AugmentedMatrix[k][j];
                    }
                }
            }

            return AugmentedMatrix;
        }
        public double[] SolveLinearEquations(double[][] rows)
        {
            int length = rows[0].Length;

            for (int i = 0; i < rows.Length - 1; i++)
            {
                if (rows[i][i] == 0 && !Pivot(rows, i, i)) return null;

                // Forward Elimination
                for (int j = i; j < rows.Length; j++)
                {
                    double[] d = new double[length];

                    for (int x = 0; x < length; x++)
                    {
                        d[x] = rows[j][x];
                        if (rows[j][i] != 0) 
                            d[x] = d[x] / rows[j][i];
                    }

                    rows[j] = d;
                }


                for (int y = i + 1; y < rows.Length; y++)
                {
                    double[] f = new double[length];
                    for (int g = 0; g < length; g++)
                    {
                        f[g] = rows[y][g];
                        if (rows[y][i] != 0)
                        {
                            f[g] = f[g] - rows[i][g];
                        }

                    }
                    rows[y] = f;
                }
            }

            return BackwardSubstitution(rows);
        }
        public bool Pivot(double[][] rows, int row, int column)
        {
            bool swapped = false;
            for (int z = rows.Length - 1; z > row; z--)
            {
                if (rows[z][row] != 0)
                {
                    double[] temp = new double[rows[0].Length];
                    temp = rows[z];
                    rows[z] = rows[column];
                    rows[column] = temp;
                    swapped = true;
                }
            }

            return swapped;
        }
        public double[] BackwardSubstitution(double[][] rows)
        {
            double val = 0;
            int length = rows[0].Length;
            double[] result = new double[rows.Length];
            for (int i = rows.Length - 1; i >= 0; i--)
            {
                val = rows[i][length - 1];
                for (int x = length - 2; x > i - 1; x--)
                {
                    val -= rows[i][x] * result[x];
                }
                result[i] = val / rows[i][i];

                if (!IsValidResult(result[i]))
                {
                    return null;
                }
            }
            return result;
        }
        public bool IsValidResult(double result)
        {
            return !(double.IsNaN(result) || double.IsInfinity(result));
        }
    }
}
