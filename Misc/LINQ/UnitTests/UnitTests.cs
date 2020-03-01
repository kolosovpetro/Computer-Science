using NUnit.Framework;

namespace LINQ_Practice
{
    [TestFixture]
    class UnitTests
    {
        LINQ<string> NumberParsing = new LINQ<string>();
        [Test]
        public void TestOfNumbersFromCollection()
        {
            string[] Collection = new string[]
            {
                "A", "1", "B", "2", "C", "3", "D", "4", "E", "5", "F", "6", "G", "7", "H", "8"
            };

            var Numbers = NumberParsing.NumbersFromCollection(Collection);
            Assert.That(Numbers, Is.EqualTo(new string[] { "1", "2", "3", "4", "5", "6", "7", "8" }));
        }
        [Test]
        public void TestOfEvenNumbersFromCollection()
        {
            string[] Collection = new string[]
            {
                "A", "1", "B", "2", "C", "3", "D", "4", "E", "5", "F", "6", "G", "7", "H", "8"
            };

            var Numbers = NumberParsing.EvenNumbersFromCollection(Collection);
            Assert.That(Numbers, Is.EqualTo(new string[] { "2", "4", "6", "8" }));
        }
        [Test]
        public void TestOfOddNumbersFromCollection()
        {
            string[] Collection = new string[]
            {
                "A", "1", "B", "2", "C", "3", "D", "4", "E", "5", "F", "6", "G", "7", "H", "8"
            };

            var Numbers = NumberParsing.OddNumbersFromCollection(Collection);
            Assert.That(Numbers, Is.EqualTo(new string[] { "1", "3", "5", "7" }));
        }
        [Test]
        public void TestOfCollectionSubset()
        {
            string[] Collection = new string[]
            {
                "A", "1", "B", "2", "C", "3", "D", "4", "E", "5", "F", "6", "G", "7", "H", "8"
            };

            var Numbers = NumberParsing.CollectionSubset(Collection, 3, 3);
            Assert.That(Numbers, Is.EqualTo(new string[] { "2", "C", "3" }));
        }
        [Test]
        public void TestOfSubsetThatConsist()
        {
            string[] Collection = new string[]
            {
                "Nissan", "Aston Martin", "Chevrolet", "Alfa Romeo", "Chrysler", "Dodge", "BMW",
                "Ferrari", "Audi", "Bentley", "Ford", "Lexus", "Mercedes", "Toyota", "Volvo",
                "Subaru", "Жигули :)"
            };

            var Numbers = NumberParsing.SubsetThatConsist(Collection, "udi");
            Assert.That(Numbers, Is.EqualTo(new string[] { "Audi" }));
        }
    }
}
