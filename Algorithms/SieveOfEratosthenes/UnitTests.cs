using NUnit.Framework;

namespace SieveOfEratosthenes
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void AllTrueSieveTest()
        {
            var sieve = new SimpleSieve(10);
            var allTrueSieve = sieve.AllTrueSieve();
            Assert.That(allTrueSieve,
                Is.EqualTo(new[] {false, false, true, true, true, true, true, true, true, true}));
        }

        [Test]
        public void ExcludeTest()
        {
            var sieve = new SimpleSieve(20);
            var testArray = sieve.AllTrueSieve();
            sieve.ExcludeDivisible(3, testArray);
            var case1 = testArray[6] == false;
            var case2 = testArray[9] == false;
            var case3 = testArray[12] == false;
            var case4 = testArray[15] == false;
            var case5 = testArray[18] == false;
            Assert.That(case1, Is.EqualTo(true));
            Assert.That(case2, Is.EqualTo(true));
            Assert.That(case3, Is.EqualTo(true));
            Assert.That(case4, Is.EqualTo(true));
            Assert.That(case5, Is.EqualTo(true));
        }

        [Test]
        public void SieveTest()
        {
            var sieve = new SimpleSieve(12);
            var primes = sieve.GenerateSieve();
            Assert.That(primes,
                Is.EqualTo(new[] {false, false, true, true, false, true, false, true, false, false, false, true}));
        }
    }
}