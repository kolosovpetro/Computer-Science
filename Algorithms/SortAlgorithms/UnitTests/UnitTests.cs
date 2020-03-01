using NUnit.Framework;
using SortAlgorithms.Auxiliaries;
using SortAlgorithms.SortMethods;

namespace SortAlgorithms.UnitTests
{
    [TestFixture]
    class UnitTests
    {
        int[] array = new int[] { 0, 9, 8, 7, 6, 5, 3, 4, 2, 1 };

        [Test]
        public void TestOfInsertionSort()
        {
            InsertionSort ins = new InsertionSort(array);
            ins.GetSortedArray();
            Assert.That(ins.SortedArray, Is.EqualTo(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
        }
        [Test]
        public void TestOfSelectionSort()
        {
            SelectionSort ss = new SelectionSort(array);
            ss.GetSortedArray();
            Assert.That(ss.SortedArray, Is.EqualTo(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
        }
        [Test]
        public void TestOfBubbleSort()
        {
            BubbleSort bs = new BubbleSort(array);
            bs.GetSortedArray();
            Assert.That(bs.SortedArray, Is.EqualTo(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
        }
        [Test]
        public void TestOfCocktailSort()
        {
            CocktailSort cs = new CocktailSort(array);
            cs.GetSortedArray();
            Assert.That(cs.SortedArray, Is.EqualTo(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
        }
        [Test]
        public void TestOfCountingSort()
        {
            CountingSort cs = new CountingSort(array);
            cs.GetSortedArray();
            Assert.That(cs.SortedArray, Is.EqualTo(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
        }
        [Test]
        public void TestOfSwap()
        {
            int A = 10;
            int B = 20;
            Swap.DoSwap(ref A, ref B);
            Assert.That(A, Is.EqualTo(20));
            Assert.That(B, Is.EqualTo(10));
        }
    }
}
