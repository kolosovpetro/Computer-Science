using NUnit.Framework;

namespace NumericalIntegration.Tests
{
    [TestFixture]
    class UnitTests
    {
        [Test]
        public void TestOfGetPrintForm()
        {
            string input = "1 2 3 -4";
            Function f = new Function(input);
            Assert.That(f.PrintForm, Is.EqualTo("f(x) = 1x^3 + 2x^2 + 3x^1 + -4"));
        }
        [Test]
        public void TestOfGetValueInPoint()
        {
            string input = "1 2 1";
            Function f = new Function(input);
            Assert.That(f.ValueInPoint(2), Is.EqualTo(9));
        }
        [Test]
        public void TestOfInfixToPostfix()
        {
            string infix = "2 * 3 ^ 4";
            string expectedPostfix = "2 3 4 ^ *";
            string postfix = RPNCalculator.InfixToPostfix(infix);
            Assert.That(postfix, Is.EqualTo(expectedPostfix));
        }
        [Test]
        public void TestOfPostfixEvaluator()
        {
            string infix = "2 * 3 ^ 2";
            string postfix = RPNCalculator.InfixToPostfix(infix);
            double result = RPNCalculator.PostfixEvaluator(postfix);
            Assert.That(result, Is.EqualTo(18));
        }
        [Test]
        public void TestOfPostfixEvaluator2()
        {
            string infix = "2 * 3 ^ x";
            string postfix = RPNCalculator.InfixToPostfix(infix , 2);
            double result = RPNCalculator.PostfixEvaluator(postfix);
            Assert.That(result, Is.EqualTo(18));
        }
    }
}
