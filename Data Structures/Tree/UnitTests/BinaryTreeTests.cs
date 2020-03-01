using NUnit.Framework;
using Trees.Trees;
using Trees.Interfaces;

namespace Trees.UnitTests
{
    [TestFixture]
    class BinaryTreeTests
    {
        char[] BinaryData = new char[] { 'A', 'B', 'C', 'E', 'F', 'G', 'H', 'I', 'J' };
        int[] BinaryParents = new int[] { 0, 0, 0, 1, 1, 2, 2, 5, 5 };

        [Test]
        public void TestOfHasLeft()
        {
            IBinaryTree<char> BinaryTree = new BinaryTree<char>(BinaryData, BinaryParents);
            Assert.That(BinaryTree.HasLeft('A'), Is.EqualTo(true));
        }
        [Test]
        public void TestOfIsRoot()
        {
            BinaryTree<char> BinaryTree = new BinaryTree<char>(BinaryData, BinaryParents);
            Assert.That(BinaryTree.IsRoot('B'), Is.EqualTo(false));
        }
        [Test]
        public void TestOfHasRight()
        {
            IBinaryTree<char> BinaryTree = new BinaryTree<char>(BinaryData, BinaryParents);
            Assert.That(BinaryTree.HasRight('C'), Is.EqualTo(true));
        }
        [Test]
        public void TestOfLeftChildOf()
        {
            IBinaryTree<char> BinaryTree = new BinaryTree<char>(BinaryData, BinaryParents);
            Assert.That(BinaryTree.LeftChildOf('C'), Is.EqualTo('G'));
        }
        [Test]
        public void TestOfRightChildOf()
        {
            IBinaryTree<char> BinaryTree = new BinaryTree<char>(BinaryData, BinaryParents);
            Assert.That(BinaryTree.RightChildOf('C'), Is.EqualTo('H'));
        }
        [Test]
        public void TestOfChildrenBT()
        {
            BinaryTree<char> BinaryTree = new BinaryTree<char>(BinaryData, BinaryParents);
            var Children = BinaryTree.Children('C');
            Assert.That(Children.Count, Is.EqualTo(2));
            Assert.That(Children[0], Is.EqualTo('G'));
            Assert.That(Children[1], Is.EqualTo('H'));
        }
    }
}
