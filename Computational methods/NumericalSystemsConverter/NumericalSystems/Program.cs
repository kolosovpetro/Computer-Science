using System;

namespace NumericalSystems
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = null;

            while (true)
            {
                Console.WriteLine("Type X to quit or");
                Console.WriteLine("Write a number to convert: ");
                userInput = Console.ReadLine();

                if (userInput == "X")
                {
                    break;
                }

                newNumConverter newConverter = new newNumConverter(userInput);
                Console.WriteLine(newConverter.PrintBase);
                Console.WriteLine(newConverter.PrintDecimalForm);
                Console.WriteLine(newConverter.PrintBinaryForm);
                Console.WriteLine(newConverter.PrintOctalForm);
                Console.WriteLine(newConverter.PrintHexForm);
                Console.WriteLine("Press Enter to continue with other number");
                Console.ReadKey();
                Console.Clear();
            }

            //string t = "00,1235";
            //string d = "00.1235";
            //Console.WriteLine(double.TryParse(t, out double t1));
            //Console.WriteLine(double.TryParse(d, out double d1));
            //Console.WriteLine(t1);
            //Console.WriteLine(d1);

        }
    }
}
