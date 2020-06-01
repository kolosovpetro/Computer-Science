using System;
using System.Linq;
using PolynomialFunctions.Exceptions;
using PolynomialFunctions.Polynomials;

namespace PolynomialFunctions
{
    internal static class Program
    {
        private static void Main()
        {
            var vm = new VandermondeMatrix();
            Console.WriteLine("To finish adding of points type END.");
            Console.WriteLine($"Enter the coordinates of the point, separated by space: ");
            int step = default;

            while (true)
            {
                Console.WriteLine($"Point {step} coordinates > ");
                try
                {
                    var point = Console.ReadLine();

                    if (point != null && point.ToLower() == "end")
                        break;

                    if (point != null)
                    {
                        var values = point.Split(' ');

                        if (values.Contains(" ") || values.Length != 2)
                            throw new PointFormattingException(
                                "Point coordinates must be two integers separated by space.");

                        var x = int.Parse(values[0]);
                        var y = int.Parse(values[1]);
                        var p = new Point(x, y);
                        vm.AddPoint(p);
                    }

                    step++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            vm.PrintOrder();

            var solutions = NumericalMethods.SolveLinearEquations(vm.AugmentedMatrix);
            var pm1 = new Polynomial(solutions);
            Console.WriteLine("Resulting polynomial is: ");
            Console.WriteLine(pm1.Display);
            Console.WriteLine("The values are: ");
            Console.WriteLine(pm1.DisplayPolynomialValues());
            Console.WriteLine("Derivative is: ");
            Console.WriteLine(pm1.Derivative);
            Console.WriteLine("Guess the root (int) : ");

            var guessRoot = Auxiliary.InputOfTypeInt();

            try
            {
                var root = pm1.GuessRoot(guessRoot);
                Console.WriteLine($"Yes, root is at: {root}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}