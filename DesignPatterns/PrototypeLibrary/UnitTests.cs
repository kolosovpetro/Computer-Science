using NUnit.Framework;

namespace PrototypeLibrary
{
    [TestFixture]
    class UnitTests
    {
        [Test]
        public void CloneTest()
        {
            IPrototypable p1 = new Prototype("T60", "Terminator228");
            IPrototypable t = p1.Clone();
            Assert.That(t.Name, Is.EqualTo("T60"));
            t.ChangeName("PetroBogMira228");
            t.ChangeModel("TerminatorRun5000");
            Assert.That(t.Name, Is.EqualTo("PetroBogMira228"));
            Assert.That(t.Model, Is.EqualTo("TerminatorRun5000"));
            Assert.That(p1.Name, Is.EqualTo("T60"));
            Assert.That(p1.Model, Is.EqualTo("Terminator228"));
        }
        
        [Test]
        public void CloneTest2()
        {
            IPrototypable p1 = new Prototype("T60", "Terminator228");
            p1.ChangeName("PetroBogMira228");
            p1.ChangeModel("TerminatorRun5000");
            IPrototypable t = p1.Clone();
            Assert.That(t.Name, Is.EqualTo("PetroBogMira228"));
            Assert.That(t.Model, Is.EqualTo("TerminatorRun5000")); 
        }
    }
}
