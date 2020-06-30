using NUnit.Framework;
using FluentAssertions;

namespace SieveOfEratosthenes.AdvSieve
{
    [TestFixture]
    public class AdvSieveTests
    {
        [Test]
        public void ResetTest()
        {
            var advSieve = new AdvancedSieve(10);
            advSieve.ResetSieve();
            var sieve = advSieve.Sieve;
            sieve[0].IsPrime.Should().Be(false);
            sieve[1].IsPrime.Should().Be(false);
            sieve[2].IsPrime.Should().Be(true);
            sieve[3].IsPrime.Should().Be(true);
            sieve[9].IsPrime.Should().Be(true);
        }

        [Test]
        public void ExcludeTest()
        {
            var advSieve = new AdvancedSieve(16);
            advSieve.ResetSieve();
            advSieve.Exclude(3);
            var sieve = advSieve.Sieve;
            sieve[6].IsPrime.Should().BeFalse();
            sieve[9].IsPrime.Should().BeFalse();
            sieve[12].IsPrime.Should().BeFalse();
            sieve[15].IsPrime.Should().BeFalse();
            
            // reset to test 2
            advSieve.ResetSieve();
            advSieve.Exclude(2);
            sieve = advSieve.Sieve;
            sieve[4].IsPrime.Should().BeFalse();
            sieve[6].IsPrime.Should().BeFalse();
            sieve[8].IsPrime.Should().BeFalse();
            sieve[10].IsPrime.Should().BeFalse();
            sieve[12].IsPrime.Should().BeFalse();
            sieve[14].IsPrime.Should().BeFalse();
        }

        [Test]
        public void EratosthenesTest()
        {
            var advSieve = new AdvancedSieve(10);
            advSieve.ResetSieve();
            advSieve.GenerateEratosthenes();
            var primes = advSieve.Sieve;
            primes[0].IsPrime.Should().BeFalse();
            primes[1].IsPrime.Should().BeFalse();
            primes[2].IsPrime.Should().BeTrue();
            primes[3].IsPrime.Should().BeTrue();
            primes[4].IsPrime.Should().BeFalse();
            primes[5].IsPrime.Should().BeTrue();
            primes[6].IsPrime.Should().BeFalse();
            primes[7].IsPrime.Should().BeTrue();
            primes[8].IsPrime.Should().BeFalse();
            primes[9].IsPrime.Should().BeFalse();
        }
    }
}