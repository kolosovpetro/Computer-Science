using System;

namespace Assignments_7.TicTacToe
{
    class Layout
    {
        private readonly string[] menuItems;

        public Layout()
        {
            this.menuItems = new string[]
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
            foreach (string item in menuItems)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Displays a request to user to choose corresponding item from menu
        /// </summary>
        /// <param name="ans">Number user provides</param>
        /// <see cref="ChooseMenuOption(out string)"/>
        public void ChooseMenuOption(out string ans)
        {
            Console.Write("\nType number to go from menu > ");
            ans = Console.ReadLine();
        }

        /// <summary>
        /// Displays the move notification message to current player
        /// </summary>
        /// <param name="sign"></param>
        /// <see cref="PlayerMoveMessage(char)"/>
        public void PlayerMoveMessage(char sign)
        {
            Console.Write($"\n {sign}'s move >");
        }

        /// <summary>
        /// Shows message to the winner along with a player's sign
        /// </summary>
        /// <param name="sign">Sign of current player, 'O' or 'X'</param>
        public void WinnerMessage(char sign)
        {
            Console.WriteLine($"Player {sign} won!");
        }

        /// <summary>
        /// Displays tic tac toe board.
        /// </summary>
        /// <param name="boardArray">Char array representing a board</param>
        /// <see cref="PrintBoard(char[])"/>
        public void PrintBoard(char[] boardArray)
        {
            Console.WriteLine("Current board state: ");
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
        /// Displays illegal move message to curent player
        /// </summary>
        /// <param name="sign"></param>
        public void IllegalMoveNotice(char sign)
        {
            Console.WriteLine($"{sign}, Provide an integer number of index of board: ");
        }

        /// <summary>
        /// Displays gameover message
        /// </summary>
        public void GameOverMessage()
        {
            Console.WriteLine("Game over!");
        }

        /// <summary>
        /// Displays request message for player's nickname
        /// </summary>
        /// <param name="sign">Current player sign</param>
        public void NicknameRequest(char sign)
        {
            Console.WriteLine($"Player {sign} enter your nickname: ");
        }
    }
}
