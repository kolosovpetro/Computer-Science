using System;

namespace NumericalSystems
{
    internal static class Program
    {
        private static void Main()
        {
            while (true)
            {
                Console.WriteLine("Type X to quit or");
                Console.WriteLine("Write a number to convert: ");
                var userInput = Console.ReadLine();

                if (userInput == "X")
                {
                    break;
                }

                var converter = new NumericalConverter(userInput);
                
                Console.WriteLine(converter.PrintBase);
                Console.WriteLine(converter.PrintDecimalForm);
                Console.WriteLine(converter.PrintBinaryForm);
                Console.WriteLine(converter.PrintOctalForm);
                Console.WriteLine(converter.PrintHexForm);
                Console.WriteLine("Press Enter to continue with other number");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
