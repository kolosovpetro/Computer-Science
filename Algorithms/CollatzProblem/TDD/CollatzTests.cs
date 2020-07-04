using System;
using FluentAssertions;
using NUnit.Framework;
using static CollatzProblem.Implementation.Collatz;

namespace CollatzProblem.TDD
{
    [TestFixture]
    public class CollatzTests
    {
        [Test]
        public void GetStepsTests()
        {
            // test exception
            Action act1 = () => GetSteps(0);
            Action act2 = () => GetSteps(1);

            act1.Should().Throw<InvalidOperationException>()
                .WithMessage("Value must be greater then 1");
            act2.Should().Throw<InvalidOperationException>()
                .WithMessage("Value must be greater then 1");
            
            // test cases
            GetSteps(2).Should().Be(1);
            GetSteps(3).Should().Be(7);
            GetSteps(7).Should().Be(16);
            GetSteps(15).Should().Be(17);
            GetSteps(27).Should().Be(111);
        }
    }
}