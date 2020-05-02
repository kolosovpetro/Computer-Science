using System;

namespace NumericalIntegration
{
    internal static class Program
    {
        private static void Main()
        {
            Integrator integrator;
            int min;
            int max;

            Console.WriteLine("Type 1 it yo want to define a polynomial entering coefficients separated by space");
            Console.WriteLine("Type 2 if you want to define polynomial be Infix notation");

            int userInput = Auxiliary.InputOfTypeInt(1, 2);

            switch (userInput)
            {
                case 1:
                    Function function;
                    while (true)
                    {
                        Console.WriteLine("Enter the coefficients separated by space > ");
                        try
                        {
                            string coefficients = Console.ReadLine();
                            function = new Function(coefficients);
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    Console.WriteLine("The function we work on:");
                    Console.WriteLine(function.PrintForm);

                    while (true)
                    {
                        Console.WriteLine("Enter the lower integration limit (integer): ");
                        try
                        {
                            min = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Null reference provided."));
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message + "Try again");
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Enter the upper integration limit (integer): ");
                        try
                        {
                            max = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Null reference provided."));
                            
                            if (max < min)
                                throw new Exception("Maximum cannot be lesser than Minimum");

                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message + "Try again");
                        }
                    }

                    integrator = new Integrator(min, max, function);

                    Console.WriteLine($"By Trapezoidal method, with precision 777 iterations, the integral of {function.PrintForm} is > ");
                    Console.WriteLine($"I = {integrator.TrapezoidalMethod(777)}");
                    Console.WriteLine($"By Simpson's method, with precision 777 iterations, the integral of {function.PrintForm} is > ");
                    Console.WriteLine($"I = {integrator.SimpsonMethod(777)}");

                    break;

                case 2:
                    Console.WriteLine("Enter the function in Infix: ");

                    string infix = Console.ReadLine();

                    while (true)
                    {
                        Console.WriteLine("Enter the lower integration limit (integer): ");
                        try
                        {
                            min = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Null reference provided"));
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message + "Try again");
                        }
                    }

                    while (true)
                    {
                        Console.WriteLine("Enter the upper integration limit (integer): ");
                        try
                        {
                            max = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Null reference provided."));
                            
                            if (max < min)
                                throw new Exception("Maximum cannot be lesser than Minimum");

                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message + "Try again");
                        }
                    }

                    integrator = new Integrator(min, max);

                    Console.WriteLine("By Trapezoidal method and RNP, Integral is: ");
                    Console.WriteLine(integrator.TrapezoidalMethod(infix, 777));
                    Console.WriteLine("By Simpson's and RNP Method, Integral is: ");
                    Console.WriteLine(integrator.SimpsonMethod(infix, 777));

                    break;
            }
        }
    }
}
