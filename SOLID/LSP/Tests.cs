using NUnit.Framework;

namespace SOLID.LSP
{
    [TestFixture]
    internal class Tests
    {
        [Test]
        public void TestRectangle()
        {
            Rectangle rect = new Square();
            rect.Height = 5;
            rect.Width = 10;
            Assert.That(rect.GetArea(), Is.Not.EqualTo(50));    // test passes since rect.GetArea() = 100
            
            // and such class hierarchy like rectangle -> square violates LSP;
        }

        [Test]
        public void TestShape()
        {
            IPolygon s1 = new RectangleLspFriendly(10, 5);
            Assert.That(s1.GetArea(), Is.EqualTo(50));
            IPolygon s2 = new SquareLspFriendly(10);
            Assert.That(s2.GetArea(), Is.EqualTo(100));
        }
    }
}
