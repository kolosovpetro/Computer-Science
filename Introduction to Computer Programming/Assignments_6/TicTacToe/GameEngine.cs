using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_6.TicTacToe
{
    class GameEngine
    {
        private char[] boardArray;
        private const char crossSign = 'X';
        private const char roundSign = 'O';
        private char currentSign;
        private bool mainLoop;
        private const string statsFileFolder = "../../GameStatistics";
        private const string statsFileName = "Stats.txt";
        private readonly string statsFileFullPath = statsFileFolder + '/' + statsFileName;
        private string crossPlayerName;
        private string roungPlayerName;
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

        public char GetCurrentSign()
        {
            return this.currentSign;
        }

        public void PerformMove(int index)
        {
            this.boardArray[index] = currentSign;
        }

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

        public void SignSwitch()
        {
            currentSign = currentSign == crossSign ? roundSign : crossSign;
        }

        public char[] GetBoardArray()
        {
            return this.boardArray;
        }

        public void SetMainloop()
        {
            this.mainLoop = false;
        }

        public bool GetMainLoop()
        {
            return this.mainLoop;
        }

        public bool LegalMove(string move, out int index)
        {
            return int.TryParse(move, out index)
                && index >= 0 && index < 9
                && boardArray[index] == ' ';
        }

        public void Reset()
        {
            this.boardArray = new char[9];
            for (int i = 0; i < boardArray.Length; i++)
                boardArray[i] = ' ';
            this.currentSign = roundSign;
        }

        public void SetCrossPlayerName(string newName)
        {
            this.crossPlayerName = newName;
        }

        public void SetRoundPlayerName(string newName)
        {
            this.roungPlayerName = newName;
        }

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
