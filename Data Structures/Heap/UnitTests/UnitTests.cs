using Heaps.Auxiliaries;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Heaps
{
    [TestFixture]
    class UnitTests
    {
        [Test]
        public void TestOfRoot()
        {
            Heap h1 = new Heap(5, 8, 4, 12, 11, 3, 7, 9, 0, 4, 2);
            Assert.That(h1.Root, Is.EqualTo(12));
        }
        [Test]
        public void TestOfGetNode()
        {
            Heap h1 = new Heap(5, 8, 4, 12, 11, 3, 7, 9, 0, 4, 2);
            Assert.That(h1.GetNode(3), Is.EqualTo(9));
        }
        [Test]
        public void TestOfGetParentOf()
        {
            Heap h1 = new Heap(5, 8, 4, 12, 11, 3, 7, 9, 0, 4, 2);
            Assert.That(h1.GetParentOf(4), Is.EqualTo(11));
        }
        [Test]
        public void TestOfGetLeftChildOf()
        {
            Heap h1 = new Heap(5, 8, 4, 12, 11, 3, 7, 9, 0, 4, 2);
            Assert.That(h1.GetLeftChildOf(5), Is.EqualTo(-1));
        }
        [Test]
        public void TestOfGetRightChildOf()
        {
            Heap h1 = new Heap(5, 8, 4, 12, 11, 3, 7, 9, 0, 4, 2);
            Assert.That(h1.GetRightChildOf(1), Is.EqualTo(4));
        }
        [Test]
        public void TestOfSwap()
        {
            int[] array = new int[] { 5, 8, 3, 7, 2, 1 };
            List<int> List = array.ToList();
            Swap.CollectionSwap(List, 0, 1);
            Assert.That(List[0], Is.EqualTo(8));
        }
        [Test]
        public void TestOfSiftUp()
        {
            Heap h1 = new Heap(5, 8, 4, 12, 11, 3, 7, 9, 0, 4, 2);
            h1.SiftUp(3);
            Assert.That(h1.Root, Is.EqualTo(12));
        }
        [Test]
        public void TestOfPop()
        {
            Heap h1 = new Heap(5, 8, 4, 12, 11, 3, 7, 9, 0, 4, 2);
            Assert.That(h1.Pop, Is.EqualTo(12));
            Assert.That(h1.GetNode(0), Is.EqualTo(11));
        }
        [Test]
        public void TestOfGetLeftChildIndex()
        {
            Heap h1 = new Heap(5, 8, 4, 12, 11, 3, 7, 9, 0, 4, 2);
            int ChildIndex = h1.GetLeftChildIndex(5);
            Assert.That(ChildIndex, Is.EqualTo(-1));
        }
        [Test]
        public void TestOfGetRightChildIndex()
        {
            Heap h1 = new Heap(5, 8, 4, 12, 11, 3, 7, 9, 0, 4, 2);
            int ChildIndex = h1.GetRightChildIndex(5);
            Assert.That(ChildIndex, Is.EqualTo(-1));
        }
    }
}
