using System;

namespace LinearEquationsSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                SystemOfEquations SystemOfLinEquations = new SystemOfEquations();

                Console.WriteLine("Welcome to linear equation solver. ");
                Console.WriteLine("To get equation, type an integer coefficients in line, separated by space.");
                Console.WriteLine("When system is ready, enter END to bash.");
                int step = 0;

                while (true)
                {
                    Console.Write($"Eq #{step} > ");
                    string entry = Console.ReadLine();
                    if (entry.ToLower() == "end")
                    {
                        break;
                    }
                    SystemOfLinEquations.AddEquation(new Equation(entry));
                    step++;
                }

                try
                {
                    Console.WriteLine("We have now the system: ");
                    SystemOfLinEquations.PrintSystem();
                    Console.WriteLine("The Augmented matrix is: ");
                    SystemOfLinEquations.PrintAugMatrix();
                    Console.WriteLine("Forward Elimintation is: ");
                    SystemOfLinEquations.PrintElimMatrix();
                    Console.WriteLine("And solutions are: ");
                    SystemOfLinEquations.PrintSolutions();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                Console.WriteLine("If you want to solve other system - press any key");
                    Console.WriteLine("If you want to quite - press X");
                
                string ExitOrNot = Console.ReadLine();
                if (ExitOrNot.ToLower() == "x")
                {
                    break;
                }
                Console.Clear();
            }

        }



    }
}


