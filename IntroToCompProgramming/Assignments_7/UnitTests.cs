using NUnit.Framework;

namespace Assignments_7
{
    [TestFixture]
    internal class UnitTests
    {
        private readonly BankAccount _ba = new BankAccount(5.0);

        [Test]
        public void ValidWithdrawn()
        {
            _ba.Deduct(2.3);
            Assert.That(_ba.GetAccountBalance, Is.EqualTo(2.7));
        }

        [Test]
        public void NegativeAmountWithdrawn()
        {
            Assert.Throws<NegativeAmountException>(() => _ba.Deduct(-20.5));
        }

        [Test]
        public void NotEnoughMoneyWithdrawn()
        {
            Assert.Throws<NotEnoughMoneyException>(() => _ba.Deduct(7.5));
        }
    }
}
