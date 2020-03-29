using NUnit.Framework;
using SearchAlgorithms.SearchMethods;

namespace SearchAlgorithms.UnitTests
{
    [TestFixture]
    internal class UnitTests
    {
        readonly int[] _array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        [Test]
        public void TestOfSimpleLinearSearch()
        {
            int SearchValue = 8;
            var sls1 = new SimpleLinearSearchMethod(_array, SearchValue);
            bool search = sls1.DoSearch();
            Assert.That(search, Is.EqualTo(true));
        }
        
        [Test]
        public void TestOfImprovedLinearSearch()
        {
            int SearchValue = 8;
            ImprovedLinearSearchMethod ils1 = new ImprovedLinearSearchMethod(_array, SearchValue);
            bool search = ils1.DoSearch();
            Assert.That(search, Is.EqualTo(true));
        }
        
        [Test]
        public void TestOfImprovedLinearSearchWithSentinel()
        {
            int[] forSentinel = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int SearchValue = 3;
            var ilsws1 = new ImprovedLinearSearchWithSentinelMethod(forSentinel, SearchValue);
            bool search = ilsws1.DoSearch();
            Assert.That(search, Is.EqualTo(true));
        }

        [Test]
        public void TestOfBinarySearch()
        {
            int SearchValue = 8;
            var bs1 = new BinarySearchMethod(_array, SearchValue);
            bool search = bs1.DoSearch();
            Assert.That(search, Is.EqualTo(true));
        }
    }
}
