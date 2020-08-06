using BinarySearchTree.Implementations;
using BinarySearchTree.Interfaces;
using FluentAssertions;
using NUnit.Framework;

namespace BinarySearchTree.Tests
{
    [TestFixture]
    public class TreeTests
    {
        [Test]
        public void InsertTest()
        {
            INode tree = new Node(50);
            
            // sub tree 1
            tree.Insert(72);
            tree.Insert(54);
            tree.Insert(76);
            tree.Insert(67);
            
            // sub tree 2
            tree.Insert(17);
            tree.Insert(12);
            tree.Insert(23);
            tree.Insert(9);
            tree.Insert(14);
            tree.Insert(19);

            tree.Root.Key.Should().Be(50);
            tree.Right.Key.Should().Be(72);
            tree.Count.Should().Be(10);
        }

        [Test]
        public void TreeMinTest()
        {
            INode tree = new Node(50);
            
            // sub tree 1
            tree.Insert(72);
            tree.Insert(54);
            tree.Insert(76);
            tree.Insert(67);
            
            // sub tree 2
            tree.Insert(17);
            tree.Insert(12);
            tree.Insert(23);
            tree.Insert(9);
            tree.Insert(14);
            tree.Insert(19);

            tree.Min().Key.Should().Be(9);
            tree.Min(tree).Key.Should().Be(9);
        }
        
        [Test]
        public void TreeMaxTest()
        {
            INode tree = new Node(50);
            
            // sub tree 1
            tree.Insert(72);
            tree.Insert(54);
            tree.Insert(76);
            tree.Insert(67);
            
            // sub tree 2
            tree.Insert(17);
            tree.Insert(12);
            tree.Insert(23);
            tree.Insert(9);
            tree.Insert(14);
            tree.Insert(19);

            tree.Max().Key.Should().Be(76);
        }

        [Test]
        public void TreeSearchTest()
        {
            INode tree = new Node(50);
            
            // sub tree 1
            tree.Insert(72);
            tree.Insert(54);
            tree.Insert(76);
            tree.Insert(67);
            
            // sub tree 2
            tree.Insert(17);
            tree.Insert(12);
            tree.Insert(23);
            tree.Insert(9);
            tree.Insert(14);
            tree.Insert(19);

            tree.Search(14).Should().NotBeNull();
            tree.Search(14).Key.Should().Be(14);
        }

        [Test]
        public void TreeSuccessorTest()
        {
            INode tree = new Node(50);
            
            // sub tree 1
            tree.Insert(72);
            tree.Insert(54);
            tree.Insert(76);
            tree.Insert(67);
            
            // sub tree 2
            tree.Insert(17);
            tree.Insert(12);
            tree.Insert(23);
            tree.Insert(9);
            tree.Insert(14);
            tree.Insert(19);

            tree.Successor(tree).Key.Should().Be(54);
            tree.Successor(tree.Left).Key.Should().Be(19);
        }
        
        [Test]
        public void TreeDeleteTest()
        {
            INode tree = new Node(50);
            
            // sub tree 1
            tree.Insert(72);
            tree.Insert(54);
            tree.Insert(76);
            tree.Insert(67);
            
            // sub tree 2
            tree.Insert(17);
            tree.Insert(12);
            tree.Insert(23);
            tree.Insert(9);
            tree.Insert(14);
            tree.Insert(19);

            tree.Delete(tree.Right).Key.Should().Be(76);
            tree.Count.Should().Be(9);
            tree.Right.Key.Should().Be(76);
        }
    }
}