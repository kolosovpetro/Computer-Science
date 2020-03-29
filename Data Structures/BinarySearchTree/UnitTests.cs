using NUnit.Framework;

namespace BinarySearchTree
{
    [TestFixture]
    internal class UnitTests
    {
        [Test]
        public void InsertTest()
        {
            var bst = new BinSearchTree(20);
            bst.Insert(new BinSearchTree(10));
            bst.Insert(new BinSearchTree(30));
            bst.Insert(new BinSearchTree(40));

            Assert.That(bst.Left.Value, Is.EqualTo(10));
            Assert.That(bst.Right.Value, Is.EqualTo(30));
            Assert.That(bst.Right.Right.Value, Is.EqualTo(40));
        }

        [Test]
        public void SuccessorTest()
        {
            var bst = new BinSearchTree(20);
            bst.Insert(new BinSearchTree(10));
            bst.Insert(new BinSearchTree(30));
            bst.Insert(new BinSearchTree(25));

            Assert.That(bst.Successor(bst).Value, Is.EqualTo(25));
        }
    }
}
