using System;
using Assignments_7.TicTacToe;

namespace TicTacToeConsoleUI
{
    internal class Program
    {
        private static void Main()
        {
            var engine = new GameEngine();
            var layout = new Layout();

            while (engine.MainLoop)
            {
                layout.PrintMainMenu();
                layout.ChooseMenuOption(out string option);

                if (Enum.TryParse(option, out MainMenu menuTerm))
                {
                    switch (menuTerm)
                    {
                        case MainMenu.NewGame:
                            engine.Reset();

                            Console.WriteLine("Welcome to tic tac toe game.");

                            Console.WriteLine("Enter player's (O) name: ");
                            var playerName = Console.ReadLine();
                            var roundPlayer = new Player(playerName, 'O');

                            Console.WriteLine("Enter player's (X) name: ");
                            playerName = Console.ReadLine();
                            var crossPlayer = new Player(playerName, 'X');

                            Console.WriteLine("System is setting player names ... ");
                            engine.SetRoundPlayer(roundPlayer);
                            engine.SetCrossPlayer(crossPlayer);

                            foreach (var _ in engine.BoardArray)
                            {
                                Console.Clear();
                                layout.PrintBoard(engine.BoardArray);
                                layout.PlayerMoveMessage(engine.CurrentPlayer);

                                int moveIndex;

                                while (!engine.LegalMove(Console.ReadLine(), out moveIndex))
                                {
                                    layout.IllegalMoveNotice(engine.CurrentPlayer);
                                }

                                engine.PlayerMove(moveIndex);

                                if (engine.HaveWinner)
                                {
                                    Console.Clear();
                                    layout.PrintBoard(engine.BoardArray);
                                    layout.WinnerMessage(engine.CurrentPlayer);
                                    engine.SaveStatistics();
                                    Console.WriteLine("[Press Enter to return to Main menu...]");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }

                                engine.PlayerSwitch();
                            }

                            if (!engine.HaveWinner)
                            {
                                layout.GameOverMessage();
                                Console.ReadKey();
                            }

                            Console.Clear();
                            break;

                        case MainMenu.About:
                            Console.Clear();
                            Console.WriteLine("Author Petro Kolosov: https://github.com/kolosovpetro");
                            Console.WriteLine("[Press Enter to return to Main menu...]");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case MainMenu.Stats:
                            Console.WriteLine("Here stats will be implemented ... ");
                            Console.WriteLine("Enter the name of player you wanna see statistics of: ");
                            engine.DisplayStats(Console.ReadLine());
                            Console.WriteLine("[Press Enter to return to Main menu ...]");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case MainMenu.Quit:
                            Console.Clear();
                            layout.QuiteMessage(out string q);        // question for main loop break
                            if (q.ToLower() == "y")
                                engine.BreakMainLoop();
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
