using NUnit.Framework;
using PolynomialFunctions.Polynomials;

namespace PolynomialFunctions.UnitTests
{
    [TestFixture]
    internal class UnitTests
    {
        [Test]
        public void TestOfOrder()
        {
            var matrix = new VandermondeMatrix();
            var p1 = new Point(1, -1);
            var p2 = new Point(-2, 3);
            var p3 = new Point(5, 1);
            matrix.AddPoint(p1);
            matrix.AddPoint(p2);
            matrix.AddPoint(p3);
            Assert.That(matrix.Order, Is.EqualTo(2));
        }

        [Test]
        public void TestOfGetPolynomialForm()
        {
            var p1 = new Polynomial(1, 2, 3, 4);
            var polynomialForm = p1.DisplayPolynomialForm("a");
            Assert.That(polynomialForm, Is.EqualTo("f(a) = 1*a^3 + 2*a^2 + 3*a^1 + 4*a^0"));
        }

        [Test]
        public void TestOfPolynomialValue()
        {
            var p1 = new Polynomial(1, 2, 3, 4);
            Assert.That(p1.ValueInPoint(1), Is.EqualTo(10));
        }

        [Test]
        public void TestOfGetAugmentedMatrix()
        {
            var matrix = new VandermondeMatrix();
            var p1 = new Point(2, 5);
            var p2 = new Point(3, 6);
            var p3 = new Point(7, 4);
            matrix.AddPoint(p1);
            matrix.AddPoint(p2);
            matrix.AddPoint(p3);
            Assert.That(matrix.AugmentedMatrix, Is.EqualTo(new[] { new double[] { 4, 2, 1, 5 }, new double[] { 9, 3, 1, 6 }, new double[] { 49, 7, 1, 4 } }));
        }

        [Test]
        public void TestOfGetDerivative()
        {
            var p1 = new Polynomial(1, 2, 3, 4);
            var derivative = p1.GetDerivative("a");
            Assert.That(derivative, Is.EqualTo("f(a) = 3*a^2 + 4*a^1 + 3*a^0"));
        }

        [Test]
        public void TestOfValueInPoint()
        {
            var p1 = new Polynomial(1, 1, 1);
            Assert.That(p1.ValueInPoint(-1), Is.EqualTo(1));
        }
    }
}
