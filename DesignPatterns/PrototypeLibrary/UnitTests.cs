using NUnit.Framework;

namespace PrototypeLibrary
{
    [TestFixture]
    internal class UnitTests
    {
        [Test]
        public void CloneTest()
        {
            var p1 = new ConcretePrototype("T60", "Terminator228");
            var p2 = p1.Clone();
            Assert.That(p2.Name, Is.EqualTo("T60"));
            p2.ChangeName("PetroBogMira228");
            p2.ChangeModel("TerminatorRun5000");
            Assert.That(p2.Name, Is.EqualTo("PetroBogMira228"));
            Assert.That(p2.Model, Is.EqualTo("TerminatorRun5000"));
            Assert.That(p1.Name, Is.EqualTo("T60"));
            Assert.That(p1.Model, Is.EqualTo("Terminator228"));
        }
        
        [Test]
        public void CloneTest2()
        {
            var p1 = new ConcretePrototype("T60", "Terminator228");
            p1.ChangeName("PetroBogMira228");
            p1.ChangeModel("TerminatorRun5000");
            var p2 = p1.Clone();
            Assert.That(p2.Name, Is.EqualTo("PetroBogMira228"));
            Assert.That(p2.Model, Is.EqualTo("TerminatorRun5000")); 
        }
    }
}
