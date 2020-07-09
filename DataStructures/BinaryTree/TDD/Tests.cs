using BinaryTree.Implementations;
using BinaryTree.Traversal;
using NUnit.Framework;

namespace BinaryTree.TDD
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void InOrderTraversalTest()
        {
            var root = new Node<string>("A");
            var n1 = new Node<string>("B");
            var n2 = new Node<string>("C");
            var n3 = new Node<string>("D");
            var n4 = new Node<string>("E");

            root.Left = n1;
            root.Right = n2;
            n1.Left = n3;
            n1.Right = n4;
            
            var traversalEngine = new TraversalEngine<string>();
        }
    }
}