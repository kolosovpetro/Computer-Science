using NUnit.Framework;

namespace SingletonLibrary
{
    [TestFixture]
    class UnitTests
    {
        Singleton obj = Singleton.GetInstance();

        [Test]
        public void TestTimeCreated()
        {
            Singleton obj1 = Singleton.GetInstance();
            Assert.That(obj.TimeCreated, Is.EqualTo(obj1.TimeCreated));
        }
        
        [Test]
        public void TestInstanceMethods()
        {
            Assert.That(obj.CountLetters("Postgres"), Is.EqualTo(8));
            Assert.That(obj.Repeat("Postgres"), Is.EqualTo("Postgres"));
        }
    }
}
