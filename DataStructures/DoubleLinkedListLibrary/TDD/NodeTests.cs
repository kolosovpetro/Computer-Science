using DoubleLinkedListLibrary.Implementations;
using DoubleLinkedListLibrary.Interfaces;
using FluentAssertions;
using NUnit.Framework;

namespace DoubleLinkedListLibrary.TDD
{
    [TestFixture]
    public class NodeTests
    {
        [Test]
        public void NodeInitializationTest()
        {
            INode<string> node = new Node<string>("A");
            node.Value.Should().Be("A");
            node.Next.Should().BeNull();
            node.Previous.Should().BeNull();
            node.List.Should().BeNull();
            node.Next = new Node<string>("B")
            {
                Next = new Node<string>("C")
            };

            node.Next.Value.Should().Be("B");
            node.Next.Next.Value.Should().Be("C");
        }
    }
}