using System;
using System.IO;
using System.Linq;

namespace Assignments_6.TicTacToe
{
    internal class GameEngine
    {
        private char[] _boardArray;
        public readonly char CrossSign = 'X';
        public readonly char RoundSign = 'O';
        private char _currentSign;
        private bool _mainLoop;
        private const string StatsFileFolder = "../../GameStatistics";
        private const string StatsFileName = "Stats.txt";
        private readonly string _statsFileFullPath = StatsFileFolder + '/' + StatsFileName;
        private string _crossPlayerName;
        private string _roundPlayerName;
        public string CurrentPlayer { get; private set; }

        public GameEngine()
        {
            _boardArray = new char[9];
            for (int i = 0; i < _boardArray.Length; i++)
                _boardArray[i] = ' ';

            _currentSign = RoundSign;
            _mainLoop = true;
        }

        public char GetCurrentSign()
        {
            return _currentSign;
        }

        public void PerformMove(int index)
        {
            _boardArray[index] = _currentSign;
        }

        public bool WinConditions()
        {
            return (_boardArray[0] & _boardArray[1] & _boardArray[2] & _currentSign) == _currentSign
                ||
                (_boardArray[0] & _boardArray[3] & _boardArray[6] & _currentSign) == _currentSign
                ||
                (_boardArray[0] & _boardArray[4] & _boardArray[8] & _currentSign) == _currentSign
                ||
                (_boardArray[1] & _boardArray[4] & _boardArray[7] & _currentSign) == _currentSign
                ||
                (_boardArray[2] & _boardArray[5] & _boardArray[8] & _currentSign) == _currentSign
                ||
                (_boardArray[2] & _boardArray[4] & _boardArray[6] & _currentSign) == _currentSign
                ||
                (_boardArray[3] & _boardArray[4] & _boardArray[5] & _currentSign) == _currentSign
                ||
                (_boardArray[6] & _boardArray[7] & _boardArray[8] & _currentSign) == _currentSign;
        }

        public void SignSwitch()
        {
            _currentSign = _currentSign == CrossSign ? RoundSign : CrossSign;
        }

        public void PlayerNameSwitch()
        {
            CurrentPlayer = CurrentPlayer == _roundPlayerName ? _crossPlayerName : _roundPlayerName;
        }

        public char[] GetBoardArray()
        {
            return _boardArray;
        }

        public void SetMainLoop()
        {
            _mainLoop = false;
        }

        public bool GetMainLoop()
        {
            return _mainLoop;
        }

        public bool LegalMove(string move, out int index)
        {
            return int.TryParse(move, out index) 
                   && index >= 0 
                   && index < 9
                   && _boardArray[index] == ' ';
        }

        public void Reset()
        {
            _boardArray = new GameEngine()._boardArray;
        }

        public void SetCrossPlayerName(string newName)
        {
            _crossPlayerName = newName;
        }

        public void SetRoundPlayerName(string newName)
        {
            _roundPlayerName = newName;
            CurrentPlayer = newName;
        }

        public void SaveStatistics()
        {
            if (!Directory.Exists(StatsFileFolder))
            {
                Directory.CreateDirectory(StatsFileFolder);
            }

            using (var sw = new StreamWriter(_statsFileFullPath, true))
            {
                switch (GetCurrentSign())
                {
                    case 'X':
                        sw.WriteLine($"{_crossPlayerName} 1");
                        sw.WriteLine($"{_roundPlayerName} 0");
                        break;
                    default:
                        sw.WriteLine($"{_crossPlayerName} 0");
                        sw.WriteLine($"{_roundPlayerName} 1");
                        break;
                }
            }
        }

        public (int, int) PlayerStats(string playerName)
        {
            int gamesCount = 0, winsCount = 0;

            using (var sr = new StreamReader(_statsFileFullPath))
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
