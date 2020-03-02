using System;
using System.IO;
using System.Linq;

namespace Assignments_7.TicTacToe
{
    class GameEngine
    {
        private char[] boardArray;
        private const char crossSign = 'X';
        private const char roundSign = 'O';
        private char currentSign;
        private bool mainLoop;
        private string crossPlayerName;
        private string roungPlayerName;
        private const string statsFileFolder = "../../GameStatistics";
        private const string statsFileName = "Stats.txt";
        private readonly string statsFileFullPath = statsFileFolder + '/' + statsFileName;
        public char CrossSign => crossSign;
        public char RoundSign => roundSign;

        public GameEngine()
        {
            this.boardArray = new char[9];
            for (int i = 0; i < boardArray.Length; i++)
                boardArray[i] = ' ';
            this.currentSign = roundSign;
            this.mainLoop = true;
        }

        /// <summary>
        /// Getter for sign of curent player. Can be either O or X.
        /// </summary>
        /// <returns>character current sign</returns>
        public char GetCurrentSign()
        {
            return this.currentSign;
        }

        /// <summary>
        /// Performs move to particular index of borad array
        /// </summary>
        /// <param name="index">Index of players move</param>
        public void PerformMove(int index)
        {
            this.boardArray[index] = currentSign;
        }

        /// <summary>
        /// Checks if current player is winner of the game session.
        /// </summary>
        /// <returns>Returns true if current player won</returns>
        public bool WinConditions()
        {
            return (boardArray[0] & boardArray[1] & boardArray[2] & currentSign) == currentSign
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
        }

        /// <summary>
        /// Switches the sign in order to permit other player to move.
        /// </summary>
        public void SignSwitch()
        {
            currentSign = currentSign == crossSign ? roundSign : crossSign;
        }

        /// <summary>
        /// Return board array with current state.
        /// </summary>
        /// <returns>Char array representing borad with save state</returns>
        public char[] GetBoardArray()
        {
            return this.boardArray;
        }

        /// <summary>
        /// Method to break game mainloop when user wants to quite
        /// </summary>
        public void SetMainloop()
        {
            this.mainLoop = false;
        }

        /// <summary>
        /// Returns the main loop condition, if false - breakes main loop.
        /// </summary>
        /// <returns>Boolean mainloop</returns>
        public bool GetMainLoop()
        {
            return this.mainLoop;
        }

        /// <summary>
        /// Checks if player performs legal move
        /// </summary>
        /// <param name="move">Curent move index</param>
        /// <param name="index">Parsed move index and outed</param>
        /// <returns></returns>
        public bool LegalMove(string move, out int index)
        {
            return int.TryParse(move, out index)
                && index >= 0 && index < 9
                && boardArray[index] == ' ';
        }

        /// <summary>
        /// Resets the board state
        /// </summary>
        public void Reset()
        {
            this.boardArray = new char[9];
            for (int i = 0; i < boardArray.Length; i++)
                boardArray[i] = ' ';
            this.currentSign = roundSign;
        }

        /// <summary>
        /// Setter for Cross player nickname
        /// </summary>
        /// <param name="newName">Name of cross player</param>
        public void SetCrossPlayerName(string newName)
        {
            this.crossPlayerName = newName;
        }

        /// <summary>
        /// Setter for Round player nickname
        /// </summary>
        /// <param name="newName">Name of round player</param>
        public void SetRoundPlayerName(string newName)
        {
            this.roungPlayerName = newName;
        }

        /// <summary>
        /// Saves game result along with player names to text file.
        /// </summary>
        public void SaveStatistics()
        {
            if (!Directory.Exists(statsFileFolder))
            {
                Directory.CreateDirectory(statsFileFolder);
            }

            using (StreamWriter sw = new StreamWriter(statsFileFullPath, true))
            {
                switch (this.GetCurrentSign())
                {
                    case crossSign:
                        sw.WriteLine($"{crossPlayerName} 1");
                        sw.WriteLine($"{roungPlayerName} 0");
                        break;
                    default:
                        sw.WriteLine($"{crossPlayerName} 0");
                        sw.WriteLine($"{roungPlayerName} 1");
                        break;
                }
            }
        }

        /// <summary>
        /// Reads players statistics from stat text file
        /// </summary>
        /// <param name="playerName">Name of player to display statistics</param>
        /// <returns></returns>
        public (int, int) playerStats(string playerName)
        {
            int gamesCount = 0, winsCount = 0;

            using (StreamReader sr = new StreamReader(statsFileFullPath))
            {
                while (!sr.EndOfStream)
                {
                    string curr = sr.ReadLine();
                    string[] splited = curr.Split(' ');
                    if (splited.Contains(playerName))
                    {
                        gamesCount++;

                        switch (splited[1])
                        {
                            case "1":
                                winsCount++;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            return (gamesCount, winsCount);
        }

        /// <summary>
        /// Displays statistics of player.
        /// </summary>
        /// <param name="playerName">Name of player</param>
        public void DisplayStats(string playerName)
        {
            (int, int) stats = this.playerStats(playerName);
            switch (stats.Item1)
            {
                case 0:
                    Console.WriteLine("There is no such player in database.");
                    break;
                default:
                    Console.WriteLine($"Player {playerName} has the following stats: " +
                        $"{stats.Item1} games, " +
                $"{stats.Item2} wins " +
                $"and winrate {(double)stats.Item2 / stats.Item1 * 100} %");
                    break;
            }
        }
    }
}
