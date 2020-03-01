using System;

namespace Assignments5.TicTacToe
{
    public class Layout
    {
        private readonly string[] menuItems;

        public Layout()
        {
            this.menuItems = new string[]
            {
                "1. New Game",
                "2. About the author",
                "3. Quit"
            };
        }

        public void PrintMainMenu()
        {
            foreach (string item in menuItems)
            {
                Console.WriteLine(item);
            }
        }

        public void ChooseMenuOption(out string ans)
        {
            Console.Write("\nType number to go from menu > ");
            ans = Console.ReadLine();
        }

        public void PlayerMoveMessage(char sign)
        {
            Console.Write($"\n {sign}'s move >");
        }

        public void WinnerMessage(char sign)
        {
            Console.WriteLine($"Player {sign} won!");
        }

        public void PrintBoard(char[] boardArray)
        {
            Console.WriteLine("Current board state: ");
            Console.WriteLine(" " + boardArray[0] + " | " + boardArray[1] + " | " + boardArray[2] + " ");
            Console.WriteLine("-----------");
            Console.WriteLine(" " + boardArray[3] + " | " + boardArray[4] + " | " + boardArray[5] + " ");
            Console.WriteLine("-----------");
            Console.WriteLine(" " + boardArray[6] + " | " + boardArray[7] + " | " + boardArray[8] + " ");
        }

        public void QuiteMessage(out string s)
        {
            Console.WriteLine("Are you sure you want to quite ? y/n");
            s = Console.ReadLine();
        }

        public void IllegalMoveNotice(char sign)
        {
            Console.WriteLine($"{sign}, Provide an integer number of index of board: ");
        }

        public void GameOverMessage()
        {
            Console.WriteLine("Game over!");
        }
    }
}
