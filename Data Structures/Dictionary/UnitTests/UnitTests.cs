using NUnit.Framework;

namespace Dictionary.UnitTests
{
    [TestFixture]
    class UnitTests
    {
        MyDictionary<int, string> MyDictionary = new MyDictionary<int, string>();

        [Test]
        public void TestIsEmpty()
        {
            Assert.That(MyDictionary.IsEmpty, Is.EqualTo(true));
            MyDictionary.Add(2, "Maria");
            Assert.That(MyDictionary.IsEmpty, Is.EqualTo(false));
        }
        [Test]
        public void TestElementAt()
        {
            MyDictionary.Add(0, "Andrey");
            MyDictionary.Add(1, "Eugene");
            MyDictionary.Add(2, "Maria");
            Assert.That(MyDictionary.ElementAt(0).Value, Is.EqualTo("Andrey"));
            Assert.That(MyDictionary.ElementAt(1).Value, Is.EqualTo("Eugene"));
            Assert.That(MyDictionary.ElementAt(2).Value, Is.EqualTo("Maria"));
        }
        [Test]
        public void TestContains()
        {
            MyDictionary.Add(0, "Andrey");
            MyDictionary.Add(1, "Eugene");
            MyDictionary.Add(2, "Maria");
            Assert.That(MyDictionary.Contains(0, "Andrey"), Is.EqualTo(true));
            Assert.That(MyDictionary.Contains(1, "Eugene"), Is.EqualTo(true));
            Assert.That(MyDictionary.Contains(2, "Maria"), Is.EqualTo(true));
            Assert.That(MyDictionary.Contains(3, "Misha"), Is.EqualTo(false));
        }
    }
}
