using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments_7
{
    [TestFixture]
    class UnitTests
    {
        BankAccount ba = new BankAccount(5.0);

        [Test]
        public void ValidWithdrawn()
        {
            ba.Deduct(2.3);
            Assert.That(ba.GetAccountBalance, Is.EqualTo(2.7));
        }

        [Test]
        public void NegativeAmountWithdrawn()
        {
            Assert.Throws<NegativeAmountException>(() => ba.Deduct(-20.5));
        }

        [Test]
        public void NotEnoughMoneyWithdrawn()
        {
            Assert.Throws<NotEnoughMoneyException>(() => ba.Deduct(7.5));
        }
    }
}
