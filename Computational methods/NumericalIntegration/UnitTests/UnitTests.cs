using NumericalIntegration.RPN;
using NUnit.Framework;

namespace NumericalIntegration.UnitTests
{
    [TestFixture]
    internal class UnitTests
    {
        [Test]
        public void TestOfGetPrintForm()
        {
            const string input = "1 2 3 -4";
            Function f = new Function(input);
            Assert.That(f.PrintForm, Is.EqualTo("f(x) = 1x^3 + 2x^2 + 3x^1 + -4"));
        }

        [Test]
        public void TestOfGetValueInPoint()
        {
            const string input = "1 2 1";
            Function f = new Function(input);
            Assert.That(f.ValueInPoint(2), Is.EqualTo(9));
        }

        [Test]
        public void TestOfInfixToPostfix()
        {
            const string infix = "2 * 3 ^ 4";
            const string expectedPostfix = "2 3 4 ^ *";
            string postfix = RpnCalculator.InfixToPostfix(infix);
            Assert.That(postfix, Is.EqualTo(expectedPostfix));
        }

        [Test]
        public void TestOfPostfixEvaluator()
        {
            const string infix = "2 * 3 ^ 2";
            string postfix = RpnCalculator.InfixToPostfix(infix);
            double result = RpnCalculator.PostfixEvaluator(postfix);
            Assert.That(result, Is.EqualTo(18));
        }

        [Test]
        public void TestOfPostfixEvaluator2()
        {
            const string infix = "2 * 3 ^ x";
            string postfix = RpnCalculator.InfixToPostfix(infix, 2);
            double result = RpnCalculator.PostfixEvaluator(postfix);
            Assert.That(result, Is.EqualTo(18));
        }
    }
}
