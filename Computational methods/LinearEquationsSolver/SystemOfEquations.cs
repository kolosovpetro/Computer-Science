using System;
using System.Collections.Generic;
using System.Linq;

namespace LinearEquationsSolver
{
    class SystemOfEquations
    {
        private List<Equation> SystemOfEquat = new List<Equation>();
        private NumericalMethods nm = new NumericalMethods();
        private double[][] AugmentedMatrix;
        private double[] Solutions;
        private double[][] EliminatedMatrix;

        private double[][] AugMatrix()
        {
            int arraySize = SystemOfEquat.Count();
            double[][] array = new double[arraySize][];

            for (int i = 0; i < array.Length; i++)
            {
                string[] ListTerm = SystemOfEquat[i].GetAugMatrixRow;
                double[] arrayTerm = new double[ListTerm.Length];

                for (int t = 0; t < arrayTerm.Length; t++)
                {
                    arrayTerm[t] = double.Parse(ListTerm[t]);
                }

                array[i] = arrayTerm;
            }

            return array;
        }
        private void SetSolutions()
        {
            SetAugMatrix();
            this.Solutions = nm.SolveLinearEquations(this.AugmentedMatrix);
        }
        private void SetAugMatrix()
        {
            this.AugmentedMatrix = AugMatrix();
        }
        public double[][] GetAugMatrix
        {
            get
            {
                SetAugMatrix();
                return this.AugmentedMatrix;
            }
        }
        public double[][] GetElimMatrix
        {
            get
            {
                SetElimMatrix();
                return this.EliminatedMatrix;
            }
        }
        public double[] GetSolutions
        {
            get
            {
                SetSolutions();
                return this.Solutions;
            }
        }
        public void AddEquation(Equation eq)
        {
            SystemOfEquat.Add(eq);
        }
        public void PrintSystem()
        {
            foreach (Equation item in SystemOfEquat)
            {
                Console.WriteLine(item.GetEquationForm);
            }
        }
        public void PrintAugMatrix()
        {
            SetAugMatrix();
            for (int i = 0; i < AugmentedMatrix.Length; i++)
            {
                Auxiliary.printArray(AugmentedMatrix[i]);
                Console.WriteLine();
            }
        }
        public void PrintSolutions()
        {
            SetSolutions();

            for (int i = 0; i < Solutions.Length; i++)
            {
                Console.WriteLine($"x{i + 1} = {Solutions[i]}");
            }
        }
        private void SetElimMatrix()
        {
            SetAugMatrix();
            this.EliminatedMatrix = nm.ForwardElimination(this.AugmentedMatrix);
        }
        public void PrintElimMatrix()
        {
            SetElimMatrix();
            for (int i = 0; i < EliminatedMatrix.Length; i++)
            {
                Auxiliary.printArray(EliminatedMatrix[i]);
                Console.WriteLine();
            }
        }
    }
}
