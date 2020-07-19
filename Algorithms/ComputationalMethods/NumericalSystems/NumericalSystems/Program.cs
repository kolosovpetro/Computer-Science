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
                    break;

                var converter = new Processor(userInput);
                
                Console.WriteLine(converter.Base);
                Console.WriteLine(converter.Decimal);
                Console.WriteLine(converter.Binary);
                Console.WriteLine(converter.Octal);
                Console.WriteLine(converter.Hexagonal);
                Console.WriteLine("Press Enter to continue with other number");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
