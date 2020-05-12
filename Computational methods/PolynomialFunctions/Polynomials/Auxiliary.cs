using System;

namespace PolynomialFunctions.Polynomials
{
    internal static class Auxiliary
    {
        public static int InputOfTypeInt()
        {
            const string message = "Enter the number of type integer: ";
            Console.WriteLine(message);
            int userInputInt;

            while (!int.TryParse(Console.ReadLine(), out userInputInt))
            {
                Console.WriteLine("Ops, try again. " + message);
            }

            return userInputInt;
        }
    }
}
