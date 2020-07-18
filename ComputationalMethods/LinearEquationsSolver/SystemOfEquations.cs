using System.Collections.Generic;
using static System.Console;
using static LinearEquationsSolver.Auxiliary;
using static LinearEquationsSolver.NumericalMethods;

namespace LinearEquationsSolver
{
    internal class SystemOfEquations
    {
        private readonly List<Equation> _systemOfEquations = new List<Equation>();
        private readonly NumericalMethods _numericalMethods = new NumericalMethods();
        private double[][] _augmentedMatrix;
        private double[] _solutions;
        private double[][] _eliminatedMatrix;

        private double[][] AugMatrix()
        {
            var size = _systemOfEquations.Count;
            var array = new double[size][];

            for (var i = 0; i < array.Length; i++)
            {
                var listTerm = _systemOfEquations[i].GetAugMatrixRow;
                var arrayTerm = new double[listTerm.Length];

                for (var t = 0; t < arrayTerm.Length; t++)
                    arrayTerm[t] = double.Parse(listTerm[t]);

                array[i] = arrayTerm;
            }

            return array;
        }

        private void SetSolutions()
        {
            SetAugMatrix();
            _solutions = _numericalMethods.SolveLinearEquations(this._augmentedMatrix);
        }

        private void SetAugMatrix()
        {
            _augmentedMatrix = AugMatrix();
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
                WriteLine(item.GetEquationForm);
            }
        }

        public void PrintAugMatrix()
        {
            SetAugMatrix();
            foreach (var item in _augmentedMatrix)
            {
                PrintArray(item);
                WriteLine();
            }
        }

        public void PrintSolutions()
        {
            SetSolutions();

            for (var i = 0; i < _solutions.Length; i++)
            {
                WriteLine($"x{i + 1} = {_solutions[i]}");
            }
        }

        private void SetEliminatedMatrix()
        {
            SetAugMatrix();
            _eliminatedMatrix = ForwardElimination(_augmentedMatrix);
        }

        public void PrintEliminatedMatrix()
        {
            SetEliminatedMatrix();
            foreach (var item in _eliminatedMatrix)
            {
                PrintArray(item);
                WriteLine();
            }
        }
    }
}