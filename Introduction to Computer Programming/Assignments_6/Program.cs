﻿using Assignments_6.TicTacToe;
using System;

namespace Assignments_6
{
    internal class Program
    {
        private static void Main()
        {
            // Jean-Luc Picard’s journal. Write a program which reads lines of text written by the user 
            // in the console and writes them into Captain’s journal. 
            // To start writing into the journal the user should enter “start”. 
            // To end writing into the journal the user should enter “stop”. 
            // Whatever the user enters before “start” or after “stop” should be discarded. 
            // After entering the whole content, the program should create a file titled 
            //<current-date>.txt 
            // with the content in the following format:
            // Captain’s log
            // Star date < current date >
            // First line…
            // Second line…
            // …
            // Jean - Luc Picard

            var cj = new CaptainsJournal();
            Console.WriteLine("Welcome to captain's log. Type start to proceed ...");
            Console.WriteLine($"Current date: {DateTime.Now:dd/MM/yyyy}");
            cj.WriteLog();

            // Add another option – Stats – to your tic-tac-toe game.
            // After selecting New game both players should enter their usernames. 
            // After finishing each game the program should write the result of the game into a text file 
            // before going back to the main menu.
            // After selecting Stats the program should print out a list of all players 
            // whose scores are recorded in the stats file and ask the user if he / she wants to see 
            // stats for a single player or for a pair. 
            // If the user selects stats for a single player, he / she has to provide his username 
            // and the program prints the number of this player’s games and the ratio of won games to 
            // total games.
            // In case of selecting stats for a pair of players, 
            // the program asks for both players’ names and prints out the total number of
            //their games and what percent of games each of them won.

            Layout layout = new Layout();
            GameEngine ge = new GameEngine();

            while (ge.GetMainLoop())
            {
                layout.PrintMainMenu();
                layout.ChooseMenuOption(out string opt);

                if (Enum.TryParse(opt, out MainMenu menuTerm))
                {
                    switch (menuTerm)
                    {
                        case MainMenu.NewGame:
                            layout.NicknameRequest(ge.CrossSign);
                            ge.SetCrossPlayerName(Console.ReadLine());
                            layout.NicknameRequest(ge.RoundSign);
                            ge.SetRoundPlayerName(Console.ReadLine());

                            for (int j = 0; j < ge.GetBoardArray().Length; j++)
                            {
                                layout.PrintBoard(ge.GetBoardArray());
                                layout.PlayerMoveMessage(ge.GetCurrentSign(), ge.CurrentPlayer);

                                int moveIndex;

                                while (!ge.LegalMove(Console.ReadLine(), out moveIndex))
                                {
                                    layout.IllegalMoveNotice(ge.GetCurrentSign());
                                }

                                ge.PerformMove(moveIndex);

                                if (ge.WinConditions())
                                {
                                    Console.Clear();
                                    layout.PrintBoard(ge.GetBoardArray());
                                    layout.WinnerMessage(ge.GetCurrentSign(), ge.CurrentPlayer);
                                    ge.SaveStatistics();
                                    Console.WriteLine("[Press Enter to return to Main menu ...]");
                                    Console.ReadKey();
                                    ge.Reset();
                                    Console.Clear();
                                    break;
                                }

                                ge.SignSwitch();
                                ge.PlayerNameSwitch();
                                Console.Clear();
                            }

                            layout.GameOverMessage();       // here is to be added stats of tie
                                                            // but I'm too lazy to overload methods
                            Console.Clear();
                            break;
                        case MainMenu.About:
                            Console.Clear();
                            Console.WriteLine("Author Petro Kolosov: https://github.com/kolosovpetro");
                            Console.WriteLine("[Press Enter to return to Main menu ...]");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case MainMenu.Stats:
                            Console.WriteLine("Here stats will be implemented ... ");
                            Console.WriteLine("Enter the name of player you wanna see statistics of: ");
                            ge.DisplayStats(Console.ReadLine());
                            Console.WriteLine("[Press Enter to return to Main menu ...]");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case MainMenu.Quit:
                            Console.Clear();
                            layout.QuiteMessage(out string q);        // question for main loop break
                            if (q.ToLower() == "y")
                                ge.SetMainLoop();
                            break;
                        case MainMenu.Unassigned:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }
    }
}
