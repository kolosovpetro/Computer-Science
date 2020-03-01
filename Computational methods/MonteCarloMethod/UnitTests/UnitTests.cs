using MonteCarloMethod.Classes;
using NUnit.Framework;
using System.Linq;

namespace MonteCarloMethod.UnitTests
{
    [TestFixture]
    class UnitTests
    {
        [Test]
        public void TestLINQNumbersSelection()
        {
            LINQ<string> StringProcess = new LINQ<string>();
            string Input = "10 20 30";
            var Values = Input.Split(' ');
            var NewValues = StringProcess.NumbersFromCollection(Values);
            Assert.That(NewValues.ToArray(), Is.EqualTo(new string[] { "10", "20", "30" }));
        }
        
        [Test]
        public void TestTaskInititalization()
        {
            string Input = "10 20 30";
            Task ct = new Task(Input);
            Assert.That(ct.Estimations[0], Is.EqualTo(10));
            Assert.That(ct.Estimations[1], Is.EqualTo(20));
            Assert.That(ct.Estimations[2], Is.EqualTo(30));
        }
    }
}
