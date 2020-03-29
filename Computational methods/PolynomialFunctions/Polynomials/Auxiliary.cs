using System;

namespace PolynomialFunctions.Polynomials
{
    internal class Auxiliary
    {
        public static int InputOfTypeInt()
        {
            string message = $"Enter the number of type integer: ";
            Console.WriteLine(message);
            int UserInputInt;

            while (!int.TryParse(Console.ReadLine(), out UserInputInt))
            {
                Console.WriteLine("Ops, try again. " + message);
            }

            return UserInputInt;
        }
    }
}
