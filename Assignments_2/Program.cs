using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // When solving the exercises remember to make sure your program doesn't crash regardless 
            // of user's input.

            // Write a program checking if a number given by the user is even or odd.
            Console.WriteLine("Even or odd.");
            Console.WriteLine("Provide an integer number: ");

            int num;

            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Provide an integer number: ");
            }

            bool divisible = num % 2 == 0;

            switch (divisible)
            {
                case true:
                    Console.WriteLine($"Number {num} is even.");
                    break;
                default:
                    Console.WriteLine($"Number {num} is odd.");
                    break;
            }

            // Write a program calculating the following equation a * b / (a+b), 
            // where a and b are values given by the user.
            int a, b;

            Console.WriteLine("Provide an integer number a: ");
            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Provide an integer number a: ");
            }

            Console.WriteLine("Provide an integer number b: ");
            while (!int.TryParse(Console.ReadLine(), out b))
            {
                Console.WriteLine("Provide an integer number b: ");
            }

            double res = a * b / (a / b);

            Console.WriteLine($"a * b / (a+b) = {res}");

            // Write a program which reads 3 numbers from the user and prints them out 
            // in an ascending order.
            Console.WriteLine("program which reads 3 numbers from the user " +
                "and prints them out in an ascending order.");
            int x, y, z;

            Console.WriteLine("Provide an integer number x: ");
            while (!int.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Provide an integer number x: ");
            }

            Console.WriteLine("Provide an integer number y: ");
            while (!int.TryParse(Console.ReadLine(), out y))
            {
                Console.WriteLine("Provide an integer number x: ");
            }

            Console.WriteLine("Provide an integer number z: ");
            while (!int.TryParse(Console.ReadLine(), out z))
            {
                Console.WriteLine("Provide an integer number x: ");
            }

            // here we initialize sorting network http://pages.ripco.net/~jgamble/nw.html
            int tmp;

            if (x > y) { tmp = x; x = y; y = tmp; }
            if (x > z) { tmp = x; x = z; z = tmp; }
            if (y > z) { tmp = y; y = z; z = tmp; }

            Console.WriteLine($"Sorted: {x}, {y}, {z}");

            // Write a simple calculator, which will allow for basic arithmetic’s 
            // (+, -, *, /) on two numbers.
            // Modify the solution to the previous exercise so that the program runs 
            // as long as the user wants
            int A, B;

            const char plus = '+';
            const char minus = '-';
            const char mult = '*';
            const char div = '/';

            char userSign = default;

            bool signIsCorrect = false;

            while (true)
            {
                Console.WriteLine("Provide first number (A): ");
                while (!int.TryParse(Console.ReadLine(), out A))
                {
                    Console.WriteLine("Provide an integer number A: ");
                }

                Console.WriteLine("Provide first number (B): ");
                while (!int.TryParse(Console.ReadLine(), out B))
                {
                    Console.WriteLine("Provide an integer number B: ");
                }

                while (!signIsCorrect)
                {
                    Console.WriteLine("Provide an operator: ");
                    userSign = Console.ReadLine()[0];
                    signIsCorrect = (userSign == plus) || (userSign == minus) || (userSign == mult)
                        || (userSign == div);
                }

                Console.WriteLine($"Operator provided: {userSign}");

                switch (userSign)
                {
                    case plus:
                        Console.WriteLine($"Sum of A + B = {A + B}");
                        break;
                    case minus:
                        Console.WriteLine($"Difference of A - B = {A - B}");
                        break;
                    case mult:
                        Console.WriteLine($"Multiplication A * B = {A * B}");
                        break;
                    case div:
                        if (A == 0)
                            goto default;
                        Console.WriteLine($"Division A / B = {A / B}");
                        break;
                    default:
                        Console.WriteLine("Division by zero occured. Terminated.");
                        break;
                }

                Console.WriteLine("Type X to quite or any other to continue again.");
                string quite = Console.ReadLine();

                if (quite == "X") break;
            }
        }
    }
}
