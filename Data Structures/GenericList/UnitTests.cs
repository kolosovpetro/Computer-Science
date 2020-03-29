using NUnit.Framework;
using System;

namespace GenericList
{
    [TestFixture]
    internal class UnitTests
    {
        [Test]
        public void InitializationTest()
        {
            var list = new CustomList<string>("Cat", "Dog", "Frog");
            Assert.That(list.Count, Is.EqualTo(3));
            list.Add("Lion");
            Assert.That(list.Count, Is.EqualTo(4));
            Assert.That(list.ElementAt(0), Is.EqualTo("Cat"));
            Assert.That(list.ElementAt(1), Is.EqualTo("Dog"));
            Assert.That(list.ElementAt(2), Is.EqualTo("Frog"));
            Assert.That(list.ElementAt(3), Is.EqualTo("Lion"));
            list.Add("Tiger");
            Assert.That(list.Count, Is.EqualTo(5));
            Assert.That(list.ElementAt(0), Is.EqualTo("Cat"));
            Assert.That(list.ElementAt(1), Is.EqualTo("Dog"));
            Assert.That(list.ElementAt(2), Is.EqualTo("Frog"));
            Assert.That(list.ElementAt(3), Is.EqualTo("Lion"));
            Assert.That(list.ElementAt(4), Is.EqualTo("Tiger"));
        }

        [Test]
        public void ClearTest()
        {
            var list = new CustomList<string>("Cat", "Dog", "Frog");
            Assert.That(list.Count, Is.EqualTo(3));
            list.Add("Lion");
            Assert.That(list.Count, Is.EqualTo(4));
            Assert.That(list.ElementAt(0), Is.EqualTo("Cat"));
            Assert.That(list.ElementAt(1), Is.EqualTo("Dog"));
            Assert.That(list.ElementAt(2), Is.EqualTo("Frog"));
            Assert.That(list.ElementAt(3), Is.EqualTo("Lion"));
            list.Add("Tiger");
            Assert.That(list.Count, Is.EqualTo(5));
            Assert.That(list.ElementAt(0), Is.EqualTo("Cat"));
            Assert.That(list.ElementAt(1), Is.EqualTo("Dog"));
            Assert.That(list.ElementAt(2), Is.EqualTo("Frog"));
            Assert.That(list.ElementAt(3), Is.EqualTo("Lion"));
            Assert.That(list.ElementAt(4), Is.EqualTo("Tiger"));
            list.Clear();
            Assert.That(list.Count, Is.EqualTo(0));
            Assert.Throws<NullReferenceException>(() => list.ElementAt(0));
            Assert.Throws<NullReferenceException>(() => list.ElementAt(1));
            Assert.Throws<NullReferenceException>(() => list.ElementAt(2));
        }

        [Test]
        public void AddTest()
        {
            var list = new CustomList<string>();
            list.Add("First item");
            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list.ElementAt(0), Is.EqualTo("First item"));
            list.Add("Second item");
            Assert.That(list.Count, Is.EqualTo(2));
            Assert.That(list.ElementAt(1), Is.EqualTo("Second item"));
        }

        [Test]
        public void ContainsTest()
        {
            var list = new CustomList<string>("Cat", "Dog", "Frog");
            list.Add("Lion");
            list.Add("Tiger");
            Assert.That(list.Contains("Tiger"), Is.EqualTo(true));
            Assert.That(list.Contains("Fox"), Is.EqualTo(false));
        }

        [Test]
        public void IndexOfTest()
        {
            var list = new CustomList<string>("Cat", "Dog", "Frog");
            list.Add("Lion");
            list.Add("Tiger");
            Assert.That(list.IndexOf("Tiger"), Is.EqualTo(4));
            Assert.That(list.IndexOf("Fox"), Is.EqualTo(-1));
        }
    }
}
