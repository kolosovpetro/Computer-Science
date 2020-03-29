namespace Assignments_5.TicTacToe
{
    internal class GameEngine
    {
        private char[] _boardArray;
        private const char CrossSign = 'X';
        private const char RoundSign = 'O';
        private char _currentSign;
        private bool _mainLoop;

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
            return int.TryParse(move, out index) && index >= 0 && index < 9 && _boardArray[index] == ' ';
        }

        public void Reset()
        {
            _boardArray = new GameEngine()._boardArray;
        }
    }
}
