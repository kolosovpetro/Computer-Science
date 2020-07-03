using FluentAssertions;
using NUnit.Framework;
using static ShuntingYardAlgorithm.Implementation.PostfixEvaluator;
using static ShuntingYardAlgorithm.Implementation.ShuntingYardMethod;

namespace ShuntingYardAlgorithm.TDD
{
    [TestFixture]
    public class PostfixEvaluatorTests
    {
        [Test]
        public void EvaluatorTest()
        {
            Evaluate(2, 3, '+').Should().Be(5);
            Evaluate(2, 3, '^').Should().Be(8);
            Evaluate(10, -3, '*').Should().Be(-30);
            Evaluate(10, 5, '/').Should().Be(2);
        }

        [Test]
        public void PostfixEvaluatorTest()
        {
            // 3 + 4 * 5 = 23
            var queue = InfixToPostfix("3+4*5");
            EvaluatePostfix(queue).Should().Be(23);
            
            // 3 * (4 + 5) = 27
            queue = InfixToPostfix("3*(4+5)");
            EvaluatePostfix(queue).Should().Be(27);

        }
    }
}