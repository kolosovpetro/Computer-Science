using NUnit.Framework;

namespace GenericList
{
    [TestFixture]
    class UnitTests
    {
        [Test]
        public void AddTest()
        {
            CustomList<string> list = new CustomList<string>();
            list.Add("First item");
            Assert.That(list.Count, Is.EqualTo(1));
            Assert.That(list.ElementAt(0), Is.EqualTo("First item"));
        }
    }
}
