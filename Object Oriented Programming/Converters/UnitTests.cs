using NUnit.Framework;

namespace Converters
{
    [TestFixture]
    class UnitTests
    {
        [Test]
        public void CatTest()
        {
            Cat c = new Cat("Barsik", "22");
            Assert.That(c.Eat, Is.EqualTo("I'm Cat and I'm eating... omnomonom"));
            Animal d = (Dog)c;
            Assert.That(d.Eat, Is.EqualTo("I'm Dog and I'm eating... omnomonom"));
        }
    }
}
