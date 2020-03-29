using System;

namespace Assignments_1
{
    internal class Program
    {
        private static void Main()
        {
            // "Hello, World!"
            Console.WriteLine("Hello, World!");

            // Write a program which will calculate an area of a rectangle with dimensions 
            // stored in variables a and b. 
            // Store the result in an additional variable before printing it to the console.

            int a = 10;
            int b = 20;
            int c = a * b;
            Console.WriteLine($"Area of rectangle is: {c}");

            // Given the code presented below, do the following exercises without copying 
            // the code into the code editor:
            // (1) Indicate errors which will occur during compilation.
            // (2) Indicate errors which will occur during execution.
            // (3) Fix the errors.

            // y = 0;
            int y = 0;

            // int x = Console.ReadLine(); - surely won't compile without parsing string
            Console.WriteLine("Provide an integer: ");
            var x = int.Parse(Console.ReadLine());

            // Console.WriteLine(x / y); - definitely causes division by zero exception
            Console.WriteLine("Area: ");
            Console.WriteLine(x * y);

            // Write a program which will convert a value from PLN to USD. 
            // For now, do not read the value from the console.

            double convertedValue = 12.5f; // pln
            double plnToUsdExchangeRate = 4.3f; // 1 usd = 4.3 pln
            double usdAmount = convertedValue / plnToUsdExchangeRate; // convert the pln amount to usd
            Console.WriteLine($"Pln {convertedValue} to USD is {usdAmount} USD"); // write result to console

            // Modify the solution to the previous exercise so that this time the value to be converted 
            // comes from the console as user input.

            Console.WriteLine("Another conversion of pln to usd.");
            Console.WriteLine("Provide new amount to convert: ");
            convertedValue = double.Parse(Console.ReadLine()); // may throw wrong input format exception
            usdAmount = convertedValue / plnToUsdExchangeRate; // convert the pln amount to usd
            Console.WriteLine($"Pln {convertedValue} to USD is {usdAmount} USD"); // write result to console

            // Write a program which will compute the value of a quadratic function y = ax2 + bx + c 
            // at a given point x.
            // The coefficients a, b, c and point x should be provided by the user during the execution.
            // Make sure the program has a reasonably clear interface.

            Console.WriteLine("Welcome to program to compute the value " +
                "of a quadratic function y = ax2 + bx + c");
            Console.WriteLine("Provide coefficient a: ");
            a = int.Parse(Console.ReadLine()); // may throw wrong input format exception
            Console.WriteLine("Provide coefficient b: ");
            b = int.Parse(Console.ReadLine()); // may throw wrong input format exception
            Console.WriteLine("Provide coefficient c: ");
            c = int.Parse(Console.ReadLine()); // may throw wrong input format exception
            Console.WriteLine("Provide value x: ");
            x = int.Parse(Console.ReadLine()); // may throw wrong input format exception
            double res = a * Math.Pow(x, 2) + b * x + c;
            Console.WriteLine($"Result is: {res}");

            // . Write a program which will ask a user to provide a (non-integer) number 
            // and output it as an integer.

            Console.WriteLine("Provide number to be floored: ");
            double notFloored = double.Parse(Console.ReadLine());   // may throw wrong input format exception
            int floored = (int)notFloored;                          // casting to int
            Console.WriteLine($"Result is: {floored}");

            // Draw a filled rectangle made with “*” of width 5 and height 3.
            int height = 3;
            int width = 5;
            const char sign = '*';

            Console.WriteLine("Rectangle 5x3 of * :");

            for (int i = 0; i < height; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < width; j++)
                {
                    Console.Write(sign);
                }
            }

            // Draw a tic-tac-toe board using console symbols.
            // Modify the program from the previous exercise by adding 9 variables which will hold the game state. 
            // Assume that only space bar, “X” and „O” are allowed. Next, draw the board again, however, this time 
            // make it reflect the state that is stored in the variables.
            // Modify the solution from the previous exercise so that the program will draw the board with a 
            // state provided by the user.An example execution is presented below.

            string[] fields = new string[9]; // array for storing board state

            for (int i = 0; i < fields.Length; i++)
            {
                fields[i] = " "; // fill array with " " for fancy spacing
            }

            Console.WriteLine("Tic tac toe board: \n");
            for (int i = 0; i < fields.Length; i++)
            {
                Console.WriteLine("Current board state: ");
                Console.WriteLine(" " + fields[0] + " | " + fields[1] + " | " + fields[2] + " ");
                Console.WriteLine("-----------");
                Console.WriteLine(" " + fields[3] + " | " + fields[4] + " | " + fields[5] + " ");
                Console.WriteLine("-----------");
                Console.WriteLine(" " + fields[6] + " | " + fields[7] + " | " + fields[8] + " ");
                Console.WriteLine("Enter the state of field" + i);
                fields[i] = Console.ReadLine();

            }
        }
    }
}
