using NUnit.Framework;

namespace LinearEquationsSolver
{
    [TestFixture]
    internal class UnitTests
    {
        [Test]
        public void TestOfSetEquationForm()
        {
            Equation eq1 = new Equation("1 2 3");
            Assert.That(eq1.GetEquationForm, Is.EqualTo("1*x1 + 2*x2 = 3"));
        }

        [Test]
        public void TestOfForwardElimination()
        {
            SystemOfEquations s1 = new SystemOfEquations();
            Equation eq1 = new Equation("1 2 3");
            s1.AddEquation(eq1);
            Equation eq2 = new Equation("4 5 6");
            s1.AddEquation(eq2);
            double[][] test = s1.GetEliminatedMatrix;
            Assert.That(test[1], Is.EqualTo(new double[] { 0, -3, -6 }));
            Assert.That(test[0], Is.EqualTo(new double[] { 1, 2, 3 }));
        }

        [Test]
        public void TestOfSolveLinearEquations()
        {
            SystemOfEquations s1 = new SystemOfEquations();
            Equation eq1 = new Equation("1 2 3");
            s1.AddEquation(eq1);
            Equation eq2 = new Equation("4 5 6");
            s1.AddEquation(eq2);
            double[] solutions = s1.GetSolutions;
            Assert.That(solutions, Is.EqualTo(new double[] { -1, 2 }));
        }

        [Test]
        public void TestOfPivot()
        {
            SystemOfEquations s1 = new SystemOfEquations();
            Equation eq1 = new Equation("0 2 4");
            s1.AddEquation(eq1);
            Equation eq2 = new Equation("1 -3 3");
            s1.AddEquation(eq2);
            double[] solutions = s1.GetSolutions;
            Assert.That(solutions, Is.EqualTo(new double[] { 9, 2 }));
        }
    }
}
