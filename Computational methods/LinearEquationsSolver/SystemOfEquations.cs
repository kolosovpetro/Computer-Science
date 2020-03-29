using System;
using System.Collections.Generic;
using System.Linq;

namespace LinearEquationsSolver
{
    internal class SystemOfEquations
    {
        private readonly List<Equation> _systemOfEquations = new List<Equation>();
        private readonly NumericalMethods _nm = new NumericalMethods();
        private double[][] _augmentedMatrix;
        private double[] _solutions;
        private double[][] _eliminatedMatrix;

        private double[][] AugMatrix()
        {
            int arraySize = _systemOfEquations.Count();
            double[][] array = new double[arraySize][];

            for (int i = 0; i < array.Length; i++)
            {
                string[] listTerm = _systemOfEquations[i].GetAugMatrixRow;
                double[] arrayTerm = new double[listTerm.Length];

                for (int t = 0; t < arrayTerm.Length; t++)
                {
                    arrayTerm[t] = double.Parse(listTerm[t]);
                }

                array[i] = arrayTerm;
            }

            return array;
        }

        private void SetSolutions()
        {
            SetAugMatrix();
            _solutions = _nm.SolveLinearEquations(this._augmentedMatrix);
        }

        private void SetAugMatrix()
        {
            _augmentedMatrix = AugMatrix();
        }

        public double[][] GetAugMatrix
        {
            get
            {
                SetAugMatrix();
                return _augmentedMatrix;
            }
        }

        public double[][] GetEliminatedMatrix
        {
            get
            {
                SetEliminatedMatrix();
                return _eliminatedMatrix;
            }
        }

        public double[] GetSolutions
        {
            get
            {
                SetSolutions();
                return _solutions;
            }
        }

        public void AddEquation(Equation eq)
        {
            _systemOfEquations.Add(eq);
        }

        public void PrintSystem()
        {
            foreach (var item in _systemOfEquations)
            {
                Console.WriteLine(item.GetEquationForm);
            }
        }

        public void PrintAugMatrix()
        {
            SetAugMatrix();
            foreach (var item in _augmentedMatrix)
            {
                Auxiliary.printArray(item);
                Console.WriteLine();
            }
        }

        public void PrintSolutions()
        {
            SetSolutions();

            for (int i = 0; i < _solutions.Length; i++)
            {
                Console.WriteLine($"x{i + 1} = {_solutions[i]}");
            }
        }

        private void SetEliminatedMatrix()
        {
            SetAugMatrix();
            _eliminatedMatrix = _nm.ForwardElimination(_augmentedMatrix);
        }

        public void PrintEliminatedMatrix()
        {
            SetEliminatedMatrix();
            foreach (var item in _eliminatedMatrix)
            {
                Auxiliary.printArray(item);
                Console.WriteLine();
            }
        }
    }
}
