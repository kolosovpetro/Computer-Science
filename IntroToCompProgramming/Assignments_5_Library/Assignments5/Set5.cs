using Assignments5.TicTacToe;
using System;
using System.Collections.Generic;

namespace Assignments5
{
    public class Set5
    {
        public static void Execute()
        {
            // Difference in modification of references vs value types

            int i = 0;
            int[] t = { 5 };
            Modify(ref i);
            Modify(t);
            Console.WriteLine(i);
            Console.WriteLine(t[0]);

            // Example of out keyword usage

            int x = 1;
            Console.WriteLine(x);
            ModifyingProcedure(out x);
            Console.WriteLine(x);
            Console.WriteLine("Press and key to continue...");
            Console.ReadKey();
            Console.Clear();

            // Divide your tic-tac-toe game into functions and classes according to functionality 
            // (e.g., separate class form game mechanics and separate class for displaying).

            var layout = new Layout();
            var engine = new GameEngine();

            while (engine.GetMainLoop())
            {
                layout.PrintMainMenu();
                layout.ChooseMenuOption(out string opt);

                if (Enum.TryParse(opt, out MainMenu menuTerm))
                {
                    switch (menuTerm)
                    {
                        case MainMenu.NewGame:
                            for (int j = 0; j < engine.GetBoardArray().Length; j++)
                            {
                                layout.PrintBoard(engine.GetBoardArray());
                                layout.PlayerMoveMessage(engine.GetCurrentSign());

                                int moveIndex;

                                while (!engine.LegalMove(Console.ReadLine(), out moveIndex))
                                {
                                    layout.IllegalMoveNotice(engine.GetCurrentSign());
                                }

                                engine.PerformMove(moveIndex);

                                if (engine.WinConditions())
                                {
                                    Console.Clear();
                                    layout.PrintBoard(engine.GetBoardArray());
                                    layout.WinnerMessage(engine.GetCurrentSign());
                                    Console.WriteLine("[Press Enter to return to Main menu...]");
                                    Console.ReadKey();
                                    engine.Reset();
                                    Console.Clear();
                                    break;
                                }

                                engine.SignSwitch();
                                Console.Clear();
                            }

                            layout.GameOverMessage();
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
                            layout.QuiteMessage(out string q);        // question for main loop break
                            if (q.ToLower() == "y")
                                engine.SetMainLoop();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            // Modify your solution to the previous exercise so that the user can enter as many 
            // contacts as he/she wants.
            // Implement a constructor in the contact structure which will allow for creating a complete
            // contact from data passed as parameters. 
            // Next, display all the contacts from the list.
            // Each contact should be displayed using a function implemented inside the contact structure.

            Console.Clear();
            Console.WriteLine("Welcome to contact list application.");
            var contacts = new List<Contact>();

            while (true)
            {
                Console.WriteLine("Enter first name: ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter last name: ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter phone number: ");
                string phoneNumber = Console.ReadLine();
                Console.WriteLine("Enter email: ");
                string email = Console.ReadLine();

                contacts.Add(new Contact(firstName, lastName, phoneNumber, email));

                Console.WriteLine("Wish you to add another one contact ? y/n");
                string ans = Console.ReadLine();
                if (ans != null && ans.ToLower() == "n") break;
            }

            Console.WriteLine("All contacts from list: ");

            foreach (var item in contacts)
            {
                Console.WriteLine(item.FullData);
            }
        }

        // Example how to modify value type properly

        private static void Modify(ref int value)
        {
            if (value <= 0) 
                throw new ArgumentOutOfRangeException(nameof(value));

            value = 5;
        }

        // Example how to modify reference type properly

        private static void Modify(int[] a)
        {
            a[0] = 5;
        }

        // Returning values from voids

        private static void ModifyingProcedure(out int a)
        {
            a = 23;
        }


    }
}
