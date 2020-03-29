using NUnit.Framework;
using Trees.Trees;

namespace Trees.UnitTests
{
    [TestFixture]
    internal class BinaryTreeTests
    {
        private readonly char[] _binaryData = { 'A', 'B', 'C', 'E', 'F', 'G', 'H', 'I', 'J' };
        private readonly int[] _binaryParents = { 0, 0, 0, 1, 1, 2, 2, 5, 5 };

        [Test]
        public void TestOfHasLeft()
        {
            var binaryTree = new BinaryTree<char>(_binaryData, _binaryParents);
            Assert.That(binaryTree.HasLeft('A'), Is.EqualTo(true));
        }

        [Test]
        public void TestOfIsRoot()
        {
            var binaryTree = new BinaryTree<char>(_binaryData, _binaryParents);
            Assert.That(binaryTree.IsRoot('B'), Is.EqualTo(false));
        }

        [Test]
        public void TestOfHasRight()
        {
            var binaryTree = new BinaryTree<char>(_binaryData, _binaryParents);
            Assert.That(binaryTree.HasRight('C'), Is.EqualTo(true));
        }

        [Test]
        public void TestOfLeftChildOf()
        {
            var binaryTree = new BinaryTree<char>(_binaryData, _binaryParents);
            Assert.That(binaryTree.LeftChildOf('C'), Is.EqualTo('G'));
        }

        [Test]
        public void TestOfRightChildOf()
        {
            var binaryTree = new BinaryTree<char>(_binaryData, _binaryParents);
            Assert.That(binaryTree.RightChildOf('C'), Is.EqualTo('H'));
        }

        [Test]
        public void TestOfChildBinaryTree()
        {
            var binaryTree = new BinaryTree<char>(_binaryData, _binaryParents);
            var children = binaryTree.Children('C');
            Assert.That(children.Count, Is.EqualTo(2));
            Assert.That(children[0], Is.EqualTo('G'));
            Assert.That(children[1], Is.EqualTo('H'));
        }
    }
}
