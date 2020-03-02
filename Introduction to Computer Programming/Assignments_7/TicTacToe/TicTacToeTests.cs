using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_7.TicTacToe
{
    [TestFixture]
    class TicTacToeTests
    {
        GameEngine ge = new GameEngine();

        [Test]
        public void SignSwitchTest()
        {
            Assert.That(ge.GetCurrentSign(), Is.EqualTo('O'));
            ge.SignSwitch();
            Assert.That(ge.GetCurrentSign(), Is.EqualTo('X'));
        }

        [Test]
        public void SetMainloopTest()
        {
            ge.SetMainloop();
            Assert.That(ge.GetMainLoop(), Is.EqualTo(false));
        }

        [Test]
        public void TestWinConditions()
        {
            Assert.That(ge.WinConditions(), Is.EqualTo(false));
        }
    }
}
