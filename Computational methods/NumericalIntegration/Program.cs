using System;

namespace NumericalIntegration
{
    class Program
    {
        static void Main(string[] args)
        {
            Function function;
            Integrator integrator;
            int min;
            int max;
            Console.WriteLine("Type 1 it yo want to define a polynomial entering coefficients separated by space");
            Console.WriteLine("Type 2 if you want to define polynomial be Infix notation");
            int UserInput = Auxiliary.InputOfTypeInt(1, 2);
            switch (UserInput)
            {
                case 1:
                    while (true)
                    {
                        Console.WriteLine("Enter the coefficients separated by space > ");
                        try
                        {
                            string Coefficients = Console.ReadLine();
                            function = new Function(Coefficients);
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
                        Console.WriteLine("Enter the lower intergration limit (integer): ");
                        try
                        {
                            min = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message + "Try again");
                        }
                    }
                    while (true)
                    {
                        Console.WriteLine("Enter the upper intergration limit (integer): ");
                        try
                        {
                            max = int.Parse(Console.ReadLine());
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
                    string Infix = Console.ReadLine();
                    while (true)
                    {
                        Console.WriteLine("Enter the lower intergration limit (integer): ");
                        try
                        {
                            min = int.Parse(Console.ReadLine());
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message + "Try again");
                        }
                    }
                    while (true)
                    {
                        Console.WriteLine("Enter the upper intergration limit (integer): ");
                        try
                        {
                            max = int.Parse(Console.ReadLine());
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
                    Console.WriteLine(integrator.TrapezoidalMethod(Infix, 777));
                    Console.WriteLine("By Simpson's and RNP Method, Integral is: ");
                    Console.WriteLine(integrator.SimpsonMethod(Infix, 777));
                    break;
            }
        }
    }
}
