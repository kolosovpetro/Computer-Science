using System;
using FluentAssertions;
using NUnit.Framework;

namespace ClosesPairProblem
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void CalculateDistanceTest()
        {
            var a = new Point(1, 2);
            var b = new Point(5, 5);
            Distance.CalculateDistance(a, b).Should().Be(5);
        }

        [Test]
        public void EqualityTest()
        {
            var p1 = new Point(1, 1);
            var p2 = new Point(2, 3);

            p1.Should().NotBe(p2);
            new Point(1, 1).Should().Be(new Point(1, 1));
            new Point(1, 1).Should().NotBe(new Point(2, 1));
        }

        [Test]
        public void ShortestDistanceTest()
        {
            var p1 = new Point(1, 2);
            var p2 = new Point(5, 5);
            var p3 = new Point(10, 20);

            var distanceFinder = new ShortDistanceFinder(p1, p2, p3);
            distanceFinder.ShortestDistance().Should().Be(5);
        }
    }
}