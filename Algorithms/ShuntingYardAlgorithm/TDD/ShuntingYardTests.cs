using System;
using FluentAssertions;
using NUnit.Framework;
using static ShuntingYardAlgorithm.Implementation.Operator;
using static ShuntingYardAlgorithm.Implementation.ShuntingYardMethod;


namespace ShuntingYardAlgorithm.TDD
{
    [TestFixture]
    public class ShuntingYardTests
    {
        [Test]
        public void OperatorPrecedenceTest()
        {
            Precedence('^').Should().Be(4);
            Precedence('*').Should().Be(3);
            Precedence('/').Should().Be(3);
            Precedence('+').Should().Be(2);
            Precedence('-').Should().Be(2);
            Precedence('a').Should().Be(0);
        }

        [Test]
        public void OperatorAssociativityTest()
        {
            Associativity('^').Should().Be("Right");
            Associativity('*').Should().Be("Left");
            Associativity('/').Should().Be("Left");
            Associativity('+').Should().Be("Left");
            Associativity('-').Should().Be("Left");

            Action act = () => Associativity('a');
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Char a is not an operator");
        }

        [Test]
        public void IsOperatorTest()
        {
            IsOperator('a').Should().BeFalse();
            IsOperator('(').Should().BeFalse();
            IsOperator(')').Should().BeFalse();
        }

        [Test]
        public void InfixToPostfixTest()
        {
            var queue = InfixToPostfix("2-2*3");
            queue.Dequeue().Should().Be('2');
            queue.Dequeue().Should().Be('2');
            queue.Dequeue().Should().Be('3');
            queue.Dequeue().Should().Be('*');
            queue.Dequeue().Should().Be('-');

            queue = InfixToPostfix("3+4*5");
            queue.Dequeue().Should().Be('3');
            queue.Dequeue().Should().Be('4');
            queue.Dequeue().Should().Be('5');
            queue.Dequeue().Should().Be('*');
            queue.Dequeue().Should().Be('+');

            queue = InfixToPostfix("3*(4+5)");
            queue.Dequeue().Should().Be('3');
            queue.Dequeue().Should().Be('4');
            queue.Dequeue().Should().Be('5');
            queue.Dequeue().Should().Be('+');
            queue.Dequeue().Should().Be('*');

            queue = InfixToPostfix("3+4*2/(1-5)^2^3");
            // 3 4 2 × 1 5 − 2 3 ^ ^ ÷ +
            queue.Dequeue().Should().Be('3');
            queue.Dequeue().Should().Be('4');
            queue.Dequeue().Should().Be('2');
            queue.Dequeue().Should().Be('*');
            queue.Dequeue().Should().Be('1');
            queue.Dequeue().Should().Be('5');
            queue.Dequeue().Should().Be('-');
            queue.Dequeue().Should().Be('2');
            queue.Dequeue().Should().Be('3');
            queue.Dequeue().Should().Be('^');
            queue.Dequeue().Should().Be('^');
            queue.Dequeue().Should().Be('/');
            queue.Dequeue().Should().Be('+');

            queue = InfixToPostfix("3-2+1");
            queue.Dequeue().Should().Be('3');
            queue.Dequeue().Should().Be('2');
            queue.Dequeue().Should().Be('-');
            queue.Dequeue().Should().Be('1');
            queue.Dequeue().Should().Be('+');
        }
    }
}