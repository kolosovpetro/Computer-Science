using FluentAssertions;
using NUnit.Framework;
using TreeLibrary.Implementations;

namespace TreeLibrary.TDD
{
    [TestFixture]
    public class TreeTests
    {
        [Test]
        public void TreeRootTest()
        {
            var root = new Node("Root");
            var tree = new Tree(root);
            tree.Root().Should().Be(root);
        }

        [Test]
        public void TreeCountTest()
        {
            var n1 = new Node("A");
            var n2 = new Node("B");
            var n3 = new Node("C");
            var n4 = new Node("D");
            var n5 = new Node("E");

            n1.AddChild(n2);
            n1.AddChild(n3);
            n2.AddChild(n4);
            n3.AddChild(n5);

            var tree = new Tree(n1);
            tree.Count().Should().Be(5);
        }

        [Test]
        public void TreeIsEmptyTest()
        {
            var n1 = new Node("A");
            var n2 = new Node("B");
            var n3 = new Node("C");
            var n4 = new Node("D");
            var n5 = new Node("E");

            n1.AddChild(n2);
            n1.AddChild(n3);
            n2.AddChild(n4);
            n3.AddChild(n5);

            var tree = new Tree(n1);
            tree.IsEmpty().Should().BeFalse();
        }

        [Test]
        public void TreeParentTest()
        {
            var n1 = new Node("A");
            var n2 = new Node("B");
            var n3 = new Node("C");
            var n4 = new Node("D");
            var n5 = new Node("E");

            n1.AddChildRange(n2, n3);
            n3.AddChildRange(n4, n5);
            
            var tree = new Tree(n1);
            tree.Parent(n4).Should().Be(n3);
            tree.Parent(n5).Should().Be(n3);
            tree.Parent(n2).Should().Be(n1);
            tree.Parent(n3).Should().Be(n1);
        }

        [Test]
        public void TreeNodeDepthTest()
        {
            var n1 = new Node("A");
            var n2 = new Node("B");
            var n3 = new Node("C");
            var n4 = new Node("D");
            var n5 = new Node("E");

            n1.AddChildRange(n2, n3);
            n3.AddChildRange(n4, n5);
            
            var tree = new Tree(n1);
            tree.Depth(n5).Should().Be(2);
            tree.Depth(n2).Should().Be(1);
        }

        [Test]
        public void TreeHeightTest()
        {
            var n1 = new Node("A");
            var n2 = new Node("B");
            var n3 = new Node("C");
            var n4 = new Node("D");
            var n5 = new Node("E");
            var n6 = new Node("F");
            var n7 = new Node("G");

            n1.AddChildRange(n2, n3);
            n3.AddChildRange(n4, n5);
            n5.AddChild(n6);
            n6.AddChild(n7);
            
            var tree = new Tree(n1);
            tree.Height(n1).Should().Be(4);
        }
    }
}