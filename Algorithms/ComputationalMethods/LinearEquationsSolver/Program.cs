using System;
using static System.Console;

namespace LinearEquationsSolver
{
    internal static class Program
    {
        private static void Main()
        {
            while (true)
            {
                var systemOfEquations = new SystemOfEquations();

                WriteLine("Welcome to linear equation solver. ");
                WriteLine("To get equation, type an integer coefficients in line, separated by space.");
                WriteLine("When system is ready, enter END to bash.");

                var step = 0;

                while (true)
                {
                    Write($"Eq #{step} > ");
                    var entry = ReadLine();

                    if (entry != null && entry.ToLower() == "end")
                        break;

                    systemOfEquations.AddEquation(new Equation(entry));
                    step++;
                }

                try
                {
                    WriteLine("We have now the system: ");
                    systemOfEquations.PrintSystem();
                    WriteLine("The Augmented matrix is: ");
                    systemOfEquations.PrintAugMatrix();
                    WriteLine("Forward Elimination is: ");
                    systemOfEquations.PrintEliminatedMatrix();
                    WriteLine("And solutions are: ");
                    systemOfEquations.PrintSolutions();
                }

                catch (Exception ex)
                {
                    WriteLine(ex.Message);
                    continue;
                }

                WriteLine("If you want to solve other system - press any key");
                WriteLine("If you want to quite - press X");

                var @continue = ReadLine();

                if (@continue != null && @continue.ToLower() == "x")
                    break;

                Clear();
            }
        }
    }
}