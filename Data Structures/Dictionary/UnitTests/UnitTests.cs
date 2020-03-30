using Dictionary.Dictionary;
using NUnit.Framework;

namespace Dictionary.UnitTests
{
    [TestFixture]
    internal class UnitTests
    {
        private readonly MyDictionary<int, string> _dictionary = new MyDictionary<int, string>();

        [Test]
        public void TestIsEmpty()
        {
            Assert.That(_dictionary.IsEmpty, Is.EqualTo(true));
            _dictionary.Add(2, "Maria");
            Assert.That(_dictionary.IsEmpty, Is.EqualTo(false));
        }

        [Test]
        public void TestElementAt()
        {
            _dictionary.Add(0, "Andrey");
            _dictionary.Add(1, "Eugene");
            _dictionary.Add(2, "Maria");
            Assert.That(_dictionary.ElementAt(0).Value, Is.EqualTo("Andrey"));
            Assert.That(_dictionary.ElementAt(1).Value, Is.EqualTo("Eugene"));
            Assert.That(_dictionary.ElementAt(2).Value, Is.EqualTo("Maria"));
        }

        [Test]
        public void TestContains()
        {
            _dictionary.Add(0, "Andrey");
            _dictionary.Add(1, "Eugene");
            _dictionary.Add(2, "Maria");
            Assert.That(_dictionary.Contains(0, "Andrey"), Is.EqualTo(true));
            Assert.That(_dictionary.Contains(1, "Eugene"), Is.EqualTo(true));
            Assert.That(_dictionary.Contains(2, "Maria"), Is.EqualTo(true));
            Assert.That(_dictionary.Contains(3, "Misha"), Is.EqualTo(false));
        }
    }
}
