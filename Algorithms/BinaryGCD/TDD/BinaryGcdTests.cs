using FluentAssertions;
using NUnit.Framework;
using static BinaryGCD.Implementation.BinaryGcd;

namespace BinaryGCD.TDD
{
    [TestFixture]
    public class BinaryGcdTests
    {
        [Test]
        public void GetGcdTest()
        {
            // simple cases
            GetGcd(0, 4).Should().Be(4);
            GetGcd(10, 0).Should().Be(10);
            GetGcd(10, 10).Should().Be(10);
            GetGcd(0, 0).Should().Be(0);

            // both even
            GetGcd(4, 22).Should().Be(2);
            GetGcd(12, 6).Should().Be(6);
            
            // even and odd
            GetGcd(6, 9).Should().Be(3);
            GetGcd(81, 18).Should().Be(9);
        }
    }
}