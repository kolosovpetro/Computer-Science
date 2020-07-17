using NUnit.Framework;
using SearchAlgorithms.SearchMethods;

namespace SearchAlgorithms.UnitTests
{
    [TestFixture]
    internal class UnitTests
    {
        private readonly int[] _array = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

        [Test]
        public void TestOfSimpleLinearSearch()
        {
            const int searchValue = 8;
            var searchMethod = new SimpleLinearSearch(_array, searchValue);
            var search = searchMethod.DoSearch();
            Assert.That(search, Is.EqualTo(true));
        }

        [Test]
        public void TestOfImprovedLinearSearch()
        {
            const int searchValue = 8;
            var searchMethod = new ImprovedLinearSearch(_array, searchValue);
            var search = searchMethod.DoSearch();
            Assert.That(search, Is.EqualTo(true));
        }

        [Test]
        public void TestOfImprovedLinearSearchWithSentinel()
        {
            int[] forSentinel = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            const int searchValue = 3;
            var searchMethod = new ImprovedLinearSearchSentinel(forSentinel, searchValue);
            var search = searchMethod.DoSearch();
            Assert.That(search, Is.EqualTo(true));
        }

        [Test]
        public void TestOfBinarySearch()
        {
            const int searchValue = 8;
            var searchMethod = new BinarySearch(_array, searchValue);
            var search = searchMethod.DoSearch();
            Assert.That(search, Is.EqualTo(true));
        }
    }
}