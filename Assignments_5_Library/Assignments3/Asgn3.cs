using System;
using System.Text;

namespace Assignments3
{
    public enum MainMenu
    {
        NewGame = 1,
        About = 2,
        Quit = 3,
        Unassigned = 4
    }
    public class Asgn3
    {
        public static void Execute()
        {
            // When solving the exercises remember to make sure your program doesn’t crash 
            // regardless of user’s input.

            // Ask the user to give his first name, last name, street, house number, flat number, 
            // zip code, and city, and print it out in the following format.

            string ans;     // variable used to break infinite loops

            Console.WriteLine("Provide user's first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Provide user's last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Provide user's  street: ");
            string streetName = Console.ReadLine();
            Console.WriteLine("Provide user's  house number: ");
            string houseNumber = Console.ReadLine();
            Console.WriteLine("Provide user's  flat number: ");
            string flatNumber = Console.ReadLine();
            Console.WriteLine("Provide user's  zip code: ");
            string zipCode = Console.ReadLine();
            Console.WriteLine("Provide user's city: ");
            string city = Console.ReadLine();

            StringBuilder sb = new StringBuilder();
            sb.Append($"{firstName} {lastName}\n");
            sb.Append($"{streetName} {houseNumber}/{flatNumber}\n");
            sb.Append($"{zipCode} {city}");

            Console.WriteLine(sb.ToString());

            // Design a simple menu with the following options:
            // New game – print out New game and display menu again;
            // About the author – print out the information about the author and display menu again;
            // Quit – the program asks the user for confirmation. If the user confirms, the program quits.
            // If the user doesn’t confirm – the program returns back to menu.

            string[] menuItems = new string[] { "1. New Game", "2. About the author", "3. Quit" };

            foreach (var item in menuItems) Console.WriteLine(item);        // menu layout

            MainMenu menuTerm = MainMenu.Unassigned;
            Console.WriteLine("Type number to go from menu: ");
            string userInput = Console.ReadLine();
            if (Enum.TryParse(userInput, out menuTerm))
            {
                switch (menuTerm)
                {
                    case MainMenu.NewGame:
                        Console.Clear();
                        Console.WriteLine("newgame ... ");
                        foreach (var item in menuItems) Console.WriteLine(item);        // menu layout
                        break;
                    case MainMenu.About:
                        Console.Clear();
                        Console.WriteLine("about author");
                        foreach (var item in menuItems) Console.WriteLine(item);        // menu layout
                        break;
                    case MainMenu.Quit:
                        Console.Clear();
                        Console.WriteLine("quiting...");
                        while (true)
                        {
                            Console.WriteLine("Confirm quite: y");
                            ans = Console.ReadLine();
                            if (ans == "y") break;
                        }
                        break;
                    default:
                        break;
                }
            }

            // Write a program with an Infinite loop, in which the program asks the user in 
            // every pass of the loop should it draw a next random number.If the user confirms, 
            // then the program draws a next random number and prints it to the console.
            // If the user doesn’t confirm – the program ends.

            Random r = new Random();

            while (true)
            {
                Console.WriteLine($"Random number: {r.Next()}");
                Console.WriteLine("Wish you to continue generate random numbers ? y/n");
                ans = Console.ReadLine();
                if (ans.ToLower() == "n") break;
            }

            // Extend the tic-tac-toe game from the previous assignment and add a menu with the following options:
            // a) New game
            // b) About the author
            // c) Exit.
            // Additionally, add a mechanism which will check the score of the game after each move.
            // If one of the players won, the game should end with an appropriate message.

            char[] boardArray = new char[9];    // array for storing board state
            const char crossSign = 'X';
            const char roundSign = 'O';
            char currentSign = crossSign;
            int index;
            ans = default;                      // restore the mainloop veriable to default

            while (true)
            {
                foreach (var item in menuItems) Console.WriteLine(item); // main menu layout
                Console.Write("\nType number to go from menu > ");
                userInput = Console.ReadLine();
                if (Enum.TryParse(userInput, out menuTerm))
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
