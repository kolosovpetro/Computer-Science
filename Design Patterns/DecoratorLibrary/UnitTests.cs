using NUnit.Framework;

namespace DecoratorLibrary
{
    [TestFixture]
    class UnitTests
    {
        [Test]
        public void TestWhite()
        {
            IComponent c1 = new Component();
            Assert.That(c1.WriteColor(), Is.EqualTo("White "));
        }
        
        [Test]
        public void TestWhiteRed()
        {
            IComponent c1 = new Component();
            IComponent c2 = new DecoratorA(c1);
            Assert.That(c2.WriteColor(), Is.EqualTo("White Red "));
        }
        
        [Test]
        public void TestWhiteRedBlack()
        {
            IComponent c1 = new Component();
            IComponent c2 = new DecoratorA(c1);
            IComponent c3 = new DecoratorB(c2);
            Assert.That(c3.WriteColor(), Is.EqualTo("White Red Black "));
        }
        
        [Test]
        public void TestWhiteRedBlackBlue()
        {
            IComponent c1 = new Component();
            IComponent c2 = new DecoratorA(c1);
            IComponent c3 = new DecoratorB(c2);
            IComponent c4 = new DecoratorC(c3);
            Assert.That(c4.WriteColor(), Is.EqualTo("White Red Black Blue "));
        }
    }
}
