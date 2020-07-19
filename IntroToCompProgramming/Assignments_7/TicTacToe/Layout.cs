using System;

namespace Assignments_7.TicTacToe
{
    public class Layout
    {
        private readonly string[] _menuItems;

        public Layout()
        {
            _menuItems = new[]
            {
                "1. New Game",
                "2. About the author",
                "3. Statistics",
                "4. Quit"
            };
        }

        /// <summary>
        /// Method in order to print tic tac toe menu to console
        /// </summary>
        /// <see cref="PrintMainMenu"/>
        public void PrintMainMenu()
        {
            foreach (var item in _menuItems)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Displays a request to user to choose corresponding item from menu
        /// </summary>
        /// <param name="choose">Number user provides</param>
        /// <see cref="ChooseMenuOption(out string)"/>
        public void ChooseMenuOption(out string choose)
        {
            Console.Write("\nType number to go from menu > ");
            choose = Console.ReadLine();
        }

        /// <summary>
        /// Displays the move notification message to current player
        /// </summary>
        /// <param name="sign"></param>
        /// <see cref="PlayerMoveMessage(char)"/>
        public void PlayerMoveMessage(char sign)
        {
            Console.Write($"\n{sign}'s move >");
        }

        public void PlayerMoveMessage(Player player)
        {
            Console.Write($"\n{player.PlayerName} {player.PlayerSign}'s move > ");
        }

        public void WinnerMessage(Player player)
        {
            Console.WriteLine($"Player {player.PlayerName} ({player.PlayerSign}) won!");
        }

        /// <summary>
        /// Displays tic tac toe board.
        /// </summary>
        /// <param name="boardArray">Char array representing a board</param>
        /// <see cref="PrintBoard(char[])"/>
        public void PrintBoard(char[] boardArray)
        {
            Console.WriteLine("Current board state: \n");
            Console.WriteLine(" " + boardArray[0] + " | " + boardArray[1] + " | " + boardArray[2] + " ");
            Console.WriteLine("-----------");
            Console.WriteLine(" " + boardArray[3] + " | " + boardArray[4] + " | " + boardArray[5] + " ");
            Console.WriteLine("-----------");
            Console.WriteLine(" " + boardArray[6] + " | " + boardArray[7] + " | " + boardArray[8] + " ");
        }

        /// <summary>
        /// Displays confirmation message in order if user wants to quite the game.
        /// </summary>
        /// <param name="s">String which returned</param>
        /// <see cref="QuiteMessage(out string)"/>
        public void QuiteMessage(out string s)
        {
            Console.WriteLine("Are you sure you want to quite ? y/n");
            s = Console.ReadLine();
        }

        /// <summary>
        /// Displays illegal move message to current player
        /// </summary>
        /// <param name="player"></param>
        public void IllegalMoveNotice(Player player)
        {
            Console.WriteLine($"{player.PlayerName} ({player.PlayerSign}), " +
                              $"Provide an integer number of index of board: ");
        }

        /// <summary>
        /// Displays game over message
        /// </summary>
        public void GameOverMessage()
        {
            Console.WriteLine("Game over with Tie.");
        }
    }
}
