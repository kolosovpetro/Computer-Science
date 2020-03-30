using System;
using System.IO;
using System.Linq;

namespace Assignments_6.TicTacToe
{
    internal class GameEngine
    {
        private char[] boardArray;
        public readonly char CrossSign = 'X';
        public readonly char RoundSign = 'O';
        private char currentSign;
        private bool mainLoop;
        private const string StatsFileFolder = "../../GameStatistics";
        private const string StatsFileName = "Stats.txt";
        private readonly string statsFileFullPath = StatsFileFolder + '/' + StatsFileName;
        private string crossPlayerName;
        private string roundPlayerName;
        public string CurrentPlayer { get; private set; }

        public GameEngine()
        {
            boardArray = new char[9];
            for (int i = 0; i < boardArray.Length; i++)
                boardArray[i] = ' ';

            currentSign = RoundSign;
            mainLoop = true;
        }

        public char GetCurrentSign()
        {
            return currentSign;
        }

        public void PerformMove(int index)
        {
            boardArray[index] = currentSign;
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
            currentSign = currentSign == CrossSign ? RoundSign : CrossSign;
        }

        public void PlayerNameSwitch()
        {
            CurrentPlayer = CurrentPlayer == roundPlayerName ? crossPlayerName : roundPlayerName;
        }

        public char[] GetBoardArray()
        {
            return boardArray;
        }

        public void SetMainLoop()
        {
            mainLoop = false;
        }

        public bool GetMainLoop()
        {
            return mainLoop;
        }

        public bool LegalMove(string move, out int index)
        {
            return int.TryParse(move, out index)
                && index >= 0 && index < 9
                && boardArray[index] == ' ';
        }

        public void Reset()
        {
            boardArray = new GameEngine().boardArray;
        }

        public void SetCrossPlayerName(string newName)
        {
            crossPlayerName = newName;
        }

        public void SetRoundPlayerName(string newName)
        {
            roundPlayerName = newName;
            CurrentPlayer = newName;
        }

        public void SaveStatistics()
        {
            if (!Directory.Exists(StatsFileFolder))
            {
                Directory.CreateDirectory(StatsFileFolder);
            }

            using (var sw = new StreamWriter(statsFileFullPath, true))
            {
                switch (GetCurrentSign())
                {
                    case 'X':
                        sw.WriteLine($"{crossPlayerName} 1");
                        sw.WriteLine($"{roundPlayerName} 0");
                        break;
                    default:
                        sw.WriteLine($"{crossPlayerName} 0");
                        sw.WriteLine($"{roundPlayerName} 1");
                        break;
                }
            }
        }

        public (int, int) PlayerStats(string playerName)
        {
            int gamesCount = 0, winsCount = 0;

            using (var sr = new StreamReader(statsFileFullPath))
            {
                while (!sr.EndOfStream)
                {
                    string currentLine = sr.ReadLine();

                    if (currentLine != null)
                    {
                        string[] split = currentLine.Split(' ');

                        if (split.Contains(playerName))
                        {
                            gamesCount++;

                            switch (split[1])
                            {
                                case "1":
                                    winsCount++;
                                    break;
                            }
                        }
                    }
                }
            }

            return (gamesCount, winsCount);
        }

        public void DisplayStats(string playerName)
        {
            (int, int) stats = PlayerStats(playerName);
            switch (stats.Item1)
            {
                case 0:
                    Console.WriteLine("There is no such player in database.");
                    break;
                default:
                    Console.WriteLine($"Player {playerName} has the following stats: " +
                        $"{stats.Item1} games, " +
                $"{stats.Item2} wins " +
                $"and Win Rate {(double)stats.Item2 / stats.Item1 * 100} %");
                    break;
            }
        }
    }
}
