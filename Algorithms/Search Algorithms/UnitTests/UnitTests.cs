using NUnit.Framework;
using SearchAlgorithms.SearchMethods;

namespace SearchAlgorithms.UnitTests
{
    [TestFixture]
    class UnitTests
    {
        int[] Array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        [Test]
        public void TestOfSimpleLinearSearch()
        {
            int SearchValue = 8;
            SimpleLinearSearch sls1 = new SimpleLinearSearch(Array, SearchValue);
            bool Search = sls1.DoSearch();
            Assert.That(Search, Is.EqualTo(true));
        }
        
        [Test]
        public void TestOfImprovedLinearSearch()
        {
            int SearchValue = 8;
            ImprovedLimearSearch ils1 = new ImprovedLimearSearch(Array, SearchValue);
            bool Search = ils1.DoSearch();
            Assert.That(Search, Is.EqualTo(true));
        }
        
        [Test]
        public void TestOfImprovedLinearSearchWithSentinel()
        {
            int[] ForSentinel = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int SearchValue = 3;
            ImprovedLinearSearchWithSentinel ilsws1 = new ImprovedLinearSearchWithSentinel(ForSentinel, SearchValue);
            bool Search = ilsws1.DoSearch();
            Assert.That(Search, Is.EqualTo(true));
        }

        [Test]
        public void TestOfBinarySearch()
        {
            int SearchValue = 8;
            BinarySearch bs1 = new BinarySearch(Array, SearchValue);
            bool Search = bs1.DoSearch();
            Assert.That(Search, Is.EqualTo(true));
        }
    }
}
