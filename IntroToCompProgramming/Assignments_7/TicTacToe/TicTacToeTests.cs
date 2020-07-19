using NUnit.Framework;

namespace Assignments_7.TicTacToe
{
    [TestFixture]
    internal class TicTacToeTests
    {
        private readonly GameEngine _ge = new GameEngine();
        private readonly Player _crossPlayer = new Player("Petro", 'X');
        private readonly Player _roundPlayer = new Player("Olejka", 'O');

        [Test]
        public void PlayerSwitchTest()
        {
            _ge.SetCrossPlayer(_crossPlayer);
            _ge.SetRoundPlayer(_roundPlayer);

            Assert.That(_ge.CurrentPlayer.PlayerName, Is.EqualTo("Olejka"));
            Assert.That(_ge.CurrentPlayer.PlayerSign, Is.EqualTo('O'));

            _ge.PlayerSwitch();

            Assert.That(_ge.CurrentPlayer.PlayerName, Is.EqualTo("Petro"));
            Assert.That(_ge.CurrentPlayer.PlayerSign, Is.EqualTo('X'));
        }

        [Test]
        public void BreakMainLoopTest()
        {
            _ge.BreakMainLoop();
            Assert.That(_ge.MainLoop, Is.EqualTo(false));
        }

        [Test]
        public void TestWinConditions()
        {
            Assert.That(_ge.HaveWinner, Is.EqualTo(false));
        }
    }
}
