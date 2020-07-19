using System;
using System.Text;

namespace Assignments4
{
    public enum MainMenu
    {
        NewGame = 1,
        About = 2,
        Quit = 3
    }

    public class Set4
    {
        public static void Execute()
        {
            // When solving the exercises remember to make sure your program doesn't crash 
            // regardless of user’s input.

            // Write a program which reads 20 numbers given by the user and prints them out
            // in reverse order

            Random r = new Random();                    // in order to skip this task faster; 
                                                        // correct solution is commented in loop
            StringBuilder sb = new StringBuilder();

            int num;                                    // var for array term

            Console.WriteLine("Program which reads 20 numbers given by the user " +
                "and prints them out in reverse order");

            var arr = new int[20];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Provide a number: ");

                //while (!int.TryParse(Console.ReadLine(), out num))
                //{
                //    Console.WriteLine("Provide an integer number: ");
                //}

                //arr[i] = num;

                num = r.Next(0, 100);
                arr[i] = num;
                Console.WriteLine(num);
            }

            for (int i = 0; i < arr.Length; i++)
                sb.Append(arr[arr.Length - 1 - i] + ", ");     // append values to str builder
            Console.WriteLine(sb.ToString());                  // print reversed array

            // Write a program which asks the user how many numbers he wants to provide, 
            // then reads these numbers, stores them in an array, calculates their average 
            // and prints it out in the following format:
            // The average of numbers 1 2 3 4 5 6 is 3.5

            Console.WriteLine("Get from user, calculate average, print");
            int size;
            double avg = default;

            Console.WriteLine("Enter the size of array: ");
            while (!int.TryParse(Console.ReadLine(), out size))
            {
                Console.WriteLine("Provide an integer number: ");
            }

            arr = new int[size];

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Provide a number: ");

                //while (!int.TryParse(Console.ReadLine(), out num))
                //{
                //    Console.WriteLine("Provide an integer number: ");
                //}

                //arr[i] = num;

                num = r.Next(0, 100);
                arr[i] = num;
                Console.WriteLine(num);
            }

            foreach (var t in arr)
                avg += (double)t / size;                        // calculating average

            sb.Append("\nThe average of array: ");              // append label message

            for (int i = 0; i < arr.Length; i++)
                sb.Append(arr[arr.Length - 1 - i] + ", ");      // sb append array terms

            sb.Append($"is {avg}");                             // sb append average value

            Console.WriteLine(sb.ToString());                   // print formatted string

            // Write a program which will sort an array of numbers given by the user. 
            // In your solution implement bubble sort algorithm.

            Console.WriteLine("Bubble sort of array: ");
            bool swapped = true;
            int step = 0;

            while (swapped)
            {
                swapped = false;

                while (step < arr.Length - 1)
                {

                    if (arr[step] > arr[step + 1])
                    {
                        int swap = arr[step];
                        arr[step] = arr[step + 1];
                        arr[step + 1] = swap;
                        swapped = true;
                    }

                    step++;
                }

                Console.WriteLine("Sorted array: ");

                foreach (var term in arr)
                {
                    Console.Write(term + " ");
                }
            }


            // Write a program which will draw a frequency histogram of numbers given by the user. 
            // The numbers should be in the range between 1 and 5.
            // Example execution of the program is given below.

            Console.WriteLine("\nProgram which draws a frequency histogram of numbers given by the user.");
            Console.WriteLine("Enter the size of array: ");

            while (!int.TryParse(Console.ReadLine(), out size))
            {
                Console.WriteLine("Provide an integer number: ");
            }

            arr = new int[size];

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Provide a number: ");

                //while (!int.TryParse(Console.ReadLine(), out num))
                //{
                //    Console.WriteLine("Provide an integer number: ");
                //}

                //arr[i] = num;

                num = r.Next(1, 6);
                arr[i] = num;
                Console.WriteLine(num);
            }

            Console.WriteLine("Frequency diagram: ");

            for (int i = 0; i < 5; i++)
            {
                string row = i + ". ";
                int count = 0;

                for (int j = 0; j < size; j++)
                    if (arr[j] == i) count++;

                for (int j = 0; j < count; j++)
                    row += "*";

                Console.WriteLine(row);
            }

            // Write a program which will print all prime numbers between 1 and the number given by the user. 
            // In your solution implement the sieve of Eratosthenes.

            Console.WriteLine("\nSieve of Eratosthenes.");
            Console.WriteLine("Enter integer: ");

            while (!int.TryParse(Console.ReadLine(), out size))
            {
                Console.WriteLine("Provide an integer number: ");
            }

            bool[] sieve = new bool[size];

            for (int i = 0; i < sieve.Length; i++)
            {
                sieve[i] = true;
            }

            for (int i = 2; i < Math.Sqrt(size); i++)
            {
                if (sieve[i])
                {
                    for (int j = (i * i); j < size; j = j + i)
                    {
                        sieve[j] = false;
                    }
                }
            }

            Console.WriteLine("List of prime numbers up to given number are : ");

            for (int i = 2; i < sieve.Length; i++)
            {
                if (sieve[i])
                {
                    Console.Write(i + ", ");
                }
            }

            Console.WriteLine("\nPress and key to continue ... ");
            Console.ReadKey();

            // Modify your tic-tac-toe game from the previous assignment so that the game state (the board) is
            // stored in an array

            Console.Clear();
            string[] menuItems = new string[] { "1. New Game", "2. About the author", "3. Quit" }; // menu layout
            char[] boardArray = new char[9];    // array for storing board state
            const char crossSign = 'X';
            const char roundSign = 'O';
            char currentSign = crossSign;

            string ans = default;

            while (true)
            {
                foreach (var item in menuItems) Console.WriteLine(item); // main menu layout
                Console.Write("\nType number to go from menu > ");
                string userInput = Console.ReadLine();

                if (Enum.TryParse(userInput, out MainMenu menuTerm))
                {
                    switch (menuTerm)
                    {
                        case MainMenu.NewGame:
                            Console.Clear();

                            // fill array with ' ' for fancy spacing

                            for (int i = 0; i < boardArray.Length; i++) boardArray[i] = ' ';

                            Console.WriteLine("Tic tac toe board: \n");

                            for (int i = 0; i < boardArray.Length; i++)
                            {
                                Console.WriteLine("Current board state: ");
                                Console.WriteLine(" " + boardArray[0] + " | " + boardArray[1] + " | " + boardArray[2] + " ");
                                Console.WriteLine("-----------");
                                Console.WriteLine(" " + boardArray[3] + " | " + boardArray[4] + " | " + boardArray[5] + " ");
                                Console.WriteLine("-----------");
                                Console.WriteLine(" " + boardArray[6] + " | " + boardArray[7] + " | " + boardArray[8] + " ");

                                Console.Write($"\n {currentSign}'s move >");

                                int index;
                                while (!(int.TryParse(Console.ReadLine(), out index)
                                         && index >= 0 && index < 9 && boardArray[index] == ' '))
                                    Console.WriteLine($"{currentSign}, Provide an integer number of index of board: ");

                                boardArray[index] = currentSign;

                                bool winConditions =
                                    (boardArray[0] & boardArray[1] & boardArray[2] & currentSign) == currentSign
                                    ||
                                    (boardArray[0] & boardArray[3] & boardArray[6] & currentSign) == currentSign
                                    ||
                                    (boardArray[0] & boardArray[4] & boardArray[8] & currentSign) == currentSign
                                    ||
                                    (boardArray[1] & boardArray[4] & boardArray[7] & currentSign) == currentSign
                                    ||
                                    (boardArray[2] & boardArray[5] & boardArray[8] & currentSign) == currentSign
                                    ||
                                    (boardArray[2] & boardArray[4] & boardArray[6] & currentSign) == currentSign
                                    ||
                                    (boardArray[3] & boardArray[4] & boardArray[5] & currentSign) == currentSign
                                    ||
                                    (boardArray[6] & boardArray[7] & boardArray[8] & currentSign) == currentSign;

                                if (winConditions)
                                {
                                    Console.WriteLine($"Player {currentSign} won!");
                                    Console.WriteLine("[Press Enter to return to Main menu...]");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }

                                currentSign = currentSign == crossSign ? roundSign : crossSign;     // ternary operator example
                            }

                            Console.WriteLine("Game over!");
                            Console.Clear();
                            break;
                        case MainMenu.About:
                            Console.Clear();
                            Console.WriteLine("Author Petro Kolosov: https://github.com/kolosovpetro");
                            Console.WriteLine("[Press Enter to return to Main menu...]");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case MainMenu.Quit:
                            Console.Clear();
                            Console.WriteLine("Are you sure want to quit ? y/n");
                            ans = Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Wrong input to menu. Try again.");
                            break;
                    }
                }

                if (ans == "y") break;
            }
        }
    }
}
