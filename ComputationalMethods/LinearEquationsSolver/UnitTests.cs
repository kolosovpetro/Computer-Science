using NUnit.Framework;

namespace LinearEquationsSolver
{
    [TestFixture]
    internal class UnitTests
    {
        [Test]
        public void TestOfSetEquationForm()
        {
            var eq1 = new Equation("1 2 3");
            Assert.That(eq1.GetEquationForm, Is.EqualTo("1*x1 + 2*x2 = 3"));
        }

        [Test]
        public void TestOfForwardElimination()
        {
            var s1 = new SystemOfEquations();
            var eq1 = new Equation("1 2 3");
            s1.AddEquation(eq1);
            var eq2 = new Equation("4 5 6");
            s1.AddEquation(eq2);
            var test = s1.GetEliminatedMatrix;
            Assert.That(test[1], Is.EqualTo(new double[] {0, -3, -6}));
            Assert.That(test[0], Is.EqualTo(new double[] {1, 2, 3}));
        }

        [Test]
        public void TestOfSolveLinearEquations()
        {
            var s1 = new SystemOfEquations();
            var eq1 = new Equation("1 2 3");
            s1.AddEquation(eq1);
            var eq2 = new Equation("4 5 6");
            s1.AddEquation(eq2);
            var solutions = s1.GetSolutions;
            Assert.That(solutions, Is.EqualTo(new double[] {-1, 2}));
        }

        [Test]
        public void TestOfPivot()
        {
            var s1 = new SystemOfEquations();
            var eq1 = new Equation("0 2 4");
            s1.AddEquation(eq1);
            var eq2 = new Equation("1 -3 3");
            s1.AddEquation(eq2);
            var solutions = s1.GetSolutions;
            Assert.That(solutions, Is.EqualTo(new double[] {9, 2}));
        }
    }
}