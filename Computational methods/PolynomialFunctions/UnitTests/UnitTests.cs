using NUnit.Framework;

namespace PolynomialFunctions
{
    [TestFixture]
    class UnitTests
    {
        [Test]
        public void TestOfOrder()
        {
            VandermondeMatrix Matrix = new VandermondeMatrix();
            Point p1 = new Point(1, -1);
            Point p2 = new Point(-2, 3);
            Point p3 = new Point(5, 1);
            Matrix.AddPoint(p1);
            Matrix.AddPoint(p2);
            Matrix.AddPoint(p3);
            Assert.That(Matrix.Order, Is.EqualTo(2));
        }
        [Test]
        public void TestOfGetPolynomialForm()
        {
            Polynomial p1 = new Polynomial(1, 2, 3, 4);
            string PolynomialForm = p1.PolynomDisplayForm("a");
            Assert.That(PolynomialForm, Is.EqualTo("f(a) = 1*a^3 + 2*a^2 + 3*a^1 + 4*a^0"));
        }
        [Test]
        public void TestOfPoynomialValue()
        {
            Polynomial p1 = new Polynomial(1, 2, 3, 4);
            Assert.That(p1.ValueInPoint(1), Is.EqualTo(10));
        }
        [Test]
        public void TestOfGetAugVanderMatrix()
        {
            VandermondeMatrix Matrix = new VandermondeMatrix();
            Point p1 = new Point(2, 5);
            Point p2 = new Point(3, 6);
            Point p3 = new Point(7, 4);
            Matrix.AddPoint(p1);
            Matrix.AddPoint(p2);
            Matrix.AddPoint(p3);
            Assert.That(Matrix.AugVanderMarix, Is.EqualTo(new double[][] { new double[] { 4, 2, 1, 5 }, new double[] { 9, 3, 1, 6 }, new double[] { 49, 7, 1, 4 } }));
        }
        [Test]
        public void TestOfGetDerivative()
        {
            Polynomial p1 = new Polynomial(1, 2, 3, 4);
            string Derivative = p1.GetDerivative("a");
            Assert.That(Derivative, Is.EqualTo("f(a) = 3*a^2 + 4*a^1 + 3*a^0"));
        }

        [Test]
        public void TestOfValueInPoint()
        {
            Polynomial p1 = new Polynomial(1, 1, 1);
            Assert.That(p1.ValueInPoint(-1), Is.EqualTo(1));
        }
    }
}
