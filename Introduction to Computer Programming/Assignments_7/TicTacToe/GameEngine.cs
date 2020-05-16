using System;
using System.IO;
using System.Linq;

namespace Assignments_7.TicTacToe
{
    public class GameEngine
    {
        public char[] BoardArray { get; private set; }
        public Player CrossPlayer { get; private set; }
        public Player RoundPlayer { get; private set; }
        public Player CurrentPlayer { get; private set; }
        public bool HaveWinner => WinConditions();
        private char CurrentSign => CurrentPlayer.PlayerSign;
        public bool MainLoop { get; private set; }
        private const string StatsFileFolder = "../../GameStatistics";
        private const string StatsFileName = "Stats.txt";
        private readonly string _statsFileFullPath = StatsFileFolder + '/' + StatsFileName;

        public GameEngine()
        {
            BoardArray = new char[9];
            for (int i = 0; i < BoardArray.Length; i++)
                BoardArray[i] = ' ';

            MainLoop = true;
        }

        /// <summary>
        /// Getter for sign of current player. Can be either O or X.
        /// </summary>
        /// <returns>character current sign</returns>
        public char GetCurrentSign()
        {
            return CurrentSign;
        }

        /// <summary>
        /// Performs move to particular index of board array
        /// </summary>
        /// <param name="index">Index of players move</param>
        public void PlayerMove(int index)
        {
            BoardArray[index] = CurrentSign;
        }

        /// <summary>
        /// Checks if current player is winner of the game session.
        /// </summary>
        /// <returns>Returns true if current player won</returns>
        public bool WinConditions()
        {
            return (BoardArray[0] & BoardArray[1] & BoardArray[2] & CurrentSign) == CurrentSign
                ||
                (BoardArray[0] & BoardArray[3] & BoardArray[6] & CurrentSign) == CurrentSign
                ||
                (BoardArray[0] & BoardArray[4] & BoardArray[8] & CurrentSign) == CurrentSign
                ||
                (BoardArray[1] & BoardArray[4] & BoardArray[7] & CurrentSign) == CurrentSign
                ||
                (BoardArray[2] & BoardArray[5] & BoardArray[8] & CurrentSign) == CurrentSign
                ||
                (BoardArray[2] & BoardArray[4] & BoardArray[6] & CurrentSign) == CurrentSign
                ||
                (BoardArray[3] & BoardArray[4] & BoardArray[5] & CurrentSign) == CurrentSign
                ||
                (BoardArray[6] & BoardArray[7] & BoardArray[8] & CurrentSign) == CurrentSign;
        }

        /// <summary>
        /// Switches the sign in order to permit other player to move.
        /// </summary>
        public void PlayerSwitch()
        {
            CurrentPlayer = CurrentPlayer == CrossPlayer ? RoundPlayer : CrossPlayer;
        }

        /// <summary>
        /// Method to break game main loop when user wants to quite
        /// </summary>
        public void BreakMainLoop()
        {
            MainLoop = false;
        }

        /// <summary>
        /// Checks if player performs legal move
        /// </summary>
        /// <param name="move">Current move index</param>
        /// <param name="index">Parsed move index and outed</param>
        /// <returns></returns>
        public bool LegalMove(string move, out int index)
        {
            return int.TryParse(move, out index)
                && index >= 0 && index < 9
                && BoardArray[index] == ' ';
        }

        /// <summary>
        /// Resets the board state
        /// </summary>
        public void Reset()
        {
            BoardArray = new GameEngine().BoardArray;
            CrossPlayer = null;
            RoundPlayer = null;
        }

        /// <summary>
        /// Setter for Cross player nickname
        /// </summary>
        /// <param name="player">Name of cross player</param>
        public void SetCrossPlayer(Player player)
        {
            CrossPlayer = player;
        }

        /// <summary>
        /// Setter for Round player nickname
        /// </summary>
        /// <param name="player">Name of round player</param>
        public void SetRoundPlayer(Player player)
        {
            RoundPlayer = player;
            CurrentPlayer = player;
        }

        /// <summary>
        /// Saves game result along with player names to text file.
        /// </summary>
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
                        sw.WriteLine($"{CrossPlayer.PlayerName} 1");
                        sw.WriteLine($"{RoundPlayer.PlayerName} 0");
                        break;
                    case 'O':
                        sw.WriteLine($"{CrossPlayer.PlayerName} 0");
                        sw.WriteLine($"{RoundPlayer.PlayerName} 1");
                        break;
                }
            }
        }

        /// <summary>
        /// Reads players statistics from stat text file
        /// </summary>
        /// <param name="playerName">Name of player to display statistics</param>
        /// <returns></returns>
        public (int, int) PlayerStats(string playerName)
        {
            int gamesCount = 0, winsCount = 0;

            using (var sr = new StreamReader(_statsFileFullPath))
            {
                while (!sr.EndOfStream)
                {
                    var currentLine = sr.ReadLine();

                    if (currentLine == null) continue;
                    var split = currentLine.Split(' ');

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

            return (gamesCount, winsCount);
        }

        /// <summary>
        /// Displays statistics of player.
        /// </summary>
        /// <param name="playerName">Name of player</param>
        public void DisplayStats(string playerName)
        {
            var (item1, item2) = PlayerStats(playerName);
            switch (item1)
            {
                case 0:
                    Console.WriteLine("There is no such player in database.");
                    break;
                default:
                    Console.WriteLine($"Player {playerName} has the following stats: " +
                        $"{item1} games, " +
                $"{item2} wins " +
                $"and Win Rate {(double)item2 / item1 * 100} %");
                    break;
            }
        }
    }
}
