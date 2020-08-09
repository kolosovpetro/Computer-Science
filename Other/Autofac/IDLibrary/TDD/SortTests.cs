using FluentAssertions;
using IDLibrary.Implementations;
using IDLibrary.Interfaces;
using NUnit.Framework;

namespace IDLibrary.TDD
{
    [TestFixture]
    public class SortTests
    {
        private ISortMethod _sortMethod;

        [Test]
        public void BubbleTest()
        {
            _sortMethod = new BubbleSort();
            var array = new[] {5, 6, 2, 8, 1, 3, 9};
            _sortMethod.Sort(array);
            array[0].Should().Be(1);
            array[1].Should().Be(2);
            array[2].Should().Be(3);
            array[3].Should().Be(5);
            array[4].Should().Be(6);
            array[5].Should().Be(8);
            array[6].Should().Be(9);
        }

        [Test]
        public void InsertionTest()
        {
            _sortMethod = new InsertionSort();
            var array = new[] {5, 6, 2, 8, 1, 3, 9};
            _sortMethod.Sort(array);
            array[0].Should().Be(1);
            array[1].Should().Be(2);
            array[2].Should().Be(3);
            array[3].Should().Be(5);
            array[4].Should().Be(6);
            array[5].Should().Be(8);
            array[6].Should().Be(9);
        }

        [Test]
        public void SelectionTest()
        {
            _sortMethod = new SelectionSort();
            var array = new[] {5, 6, 2, 8, 1, 3, 9};
            _sortMethod.Sort(array);
            array[0].Should().Be(1);
            array[1].Should().Be(2);
            array[2].Should().Be(3);
            array[3].Should().Be(5);
            array[4].Should().Be(6);
            array[5].Should().Be(8);
            array[6].Should().Be(9);
        }
    }
}