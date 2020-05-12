using System;

namespace LinearEquationsSolver
{
    internal static class Program
    {
        private static void Main()
        {
            while (true)
            {
                var systemOfLinEquations = new SystemOfEquations();

                Console.WriteLine("Welcome to linear equation solver. ");
                Console.WriteLine("To get equation, type an integer coefficients in line, separated by space.");
                Console.WriteLine("When system is ready, enter END to bash.");

                var step = 0;

                while (true)
                {
                    Console.Write($"Eq #{step} > ");
                    string entry = Console.ReadLine();

                    if (entry != null && entry.ToLower() == "end")
                    {
                        break;
                    }

                    systemOfLinEquations.AddEquation(new Equation(entry));
                    step++;
                }

                try
                {
                    Console.WriteLine("We have now the system: ");
                    systemOfLinEquations.PrintSystem();
                    Console.WriteLine("The Augmented matrix is: ");
                    systemOfLinEquations.PrintAugMatrix();
                    Console.WriteLine("Forward Elimination is: ");
                    systemOfLinEquations.PrintEliminatedMatrix();
                    Console.WriteLine("And solutions are: ");
                    systemOfLinEquations.PrintSolutions();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                Console.WriteLine("If you want to solve other system - press any key");
                Console.WriteLine("If you want to quite - press X");

                string exitOrNot = Console.ReadLine();

                if (exitOrNot != null && exitOrNot.ToLower() == "x")
                {
                    break;
                }

                Console.Clear();
            }
        }
    }
}