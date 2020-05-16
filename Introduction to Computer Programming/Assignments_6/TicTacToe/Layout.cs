﻿using System;

namespace Assignments_6.TicTacToe
{
    internal class Layout
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

        public void PrintMainMenu()
        {
            foreach (var item in _menuItems)
            {
                Console.WriteLine(item);
            }
        }

        public void ChooseMenuOption(out string ans)
        {
            Console.Write("\nType number to go from menu > ");
            ans = Console.ReadLine();
        }

        public void PlayerMoveMessage(char sign, string playerName)
        {
            Console.Write($"\n{playerName} {sign}'s move > ");
        }

        public void WinnerMessage(char sign, string playerName)
        {
            Console.WriteLine($"Player {playerName} with sign {sign} won!");
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

        public void NicknameRequest(char sign)
        {
            Console.WriteLine($"Player {sign} enter your nickname: ");
        }
    }
}
