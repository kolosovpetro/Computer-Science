﻿using System;
using System.Linq;
using PolynomialFunctions.Exceptions;
using PolynomialFunctions.Polynomials;

namespace PolynomialFunctions
{
    internal class Program
    {
        private static void Main()
        {
            Point p;
            VandermondeMatrix vm = new VandermondeMatrix();
            Console.WriteLine("To finish adding of points type END.");
            Console.WriteLine($"Enter the coordinates of the point, separated by space: ");
            int Step = default;

            while (true)
            {
                Console.WriteLine($"Point {Step} coordinates > ");
                try
                {
                    string Point = Console.ReadLine();

                    if (Point != null && Point.ToLower() == "end")
                        break;

                    if (Point != null)
                    {
                        var Values = Point.Split(' ');
                        if (Values.Contains(" ") || Values.Length != 2)
                            throw new PointFormattingException("Point coordinates must be two integers separated by space.");
                        int X = int.Parse(Values[0]);
                        int Y = int.Parse(Values[1]);
                        p = new Point(X, Y);
                        vm.AddPoint(p);
                    }

                    Step++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            vm.PrintOrder();

            double[] solutions = NumericalMethods.SolveLinearEquations(vm.AugmentedMatrix);
            Polynomial pm1 = new Polynomial(solutions);
            Console.WriteLine("Resulting polynomial is: ");
            Console.WriteLine(pm1.Display);
            Console.WriteLine("The values are: ");
            Console.WriteLine(pm1.DisplayPolynomialValues());
            Console.WriteLine("Derivative is: ");
            Console.WriteLine(pm1.Derivative);
            Console.WriteLine("Guess the root (int) : ");
            int NewRoot = Auxiliary.InputOfTypeInt();

            try
            {
                double Root = pm1.GuessRoot(NewRoot);
                Console.WriteLine($"Yes, root is at: {Root}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
