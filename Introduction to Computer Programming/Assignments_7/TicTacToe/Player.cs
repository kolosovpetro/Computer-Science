namespace Assignments_7.TicTacToe
{
    public class Player
    {
        public string PlayerName { get; }
        public char PlayerSign { get; }

        public Player(string playerName, char playerSign)
        {
            PlayerName = playerName;
            PlayerSign = playerSign;
        }

    }
}
