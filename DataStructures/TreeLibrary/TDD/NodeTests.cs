using System;
using FluentAssertions;
using NUnit.Framework;
using TreeLibrary.Implementations;

namespace TreeLibrary.TDD
{
    [TestFixture]
    public class NodeTests
    {
        [Test]
        public void NodeInitializationTest()
        {
            var node = new Node("A");
            node.Value.Should().Be("A");
            node.ChildrenNodes.Should().NotBeNull();
            node.ChildrenNodes.Count.Should().Be(0);
        }

        [Test]
        public void AddNodeChildTest()
        {
            var node = new Node("A");
            node.Value.Should().Be("A");
            node.ChildrenNodes.Should().NotBeNull();
            node.ChildrenNodes.Count.Should().Be(0);
            node.AddChild(new Node("B"));
            node.AddChild(new Node("C"));
            node.ChildrenNodes.Count.Should().Be(2);
            node.ChildrenNodes[0].Value.Should().Be("B");
            node.ChildrenNodes[1].Value.Should().Be("C");
        }

        [Test]
        public void NodeChildrenContainsNodeTest()
        {
            var node = new Node("A");
            node.AddChild(new Node("B"));
            node.ChildrenNodes.Contains(new Node("B")).Should().BeTrue();
        }

        [Test]
        public void NodeAddChildExceptionTest_AlreadyChild()
        {
            var node = new Node("A");
            node.AddChild(new Node("B"));

            Action act = () => node.AddChild(new Node("B"));
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Node B is already a child of Node A");
        }
        
        [Test]
        public void NodeAddChildExceptionTest_CannotBeChildToItself()
        {
            var node = new Node("A");

            Action act = () => node.AddChild(new Node("A"));
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Node A cannot be child of itself");
        }

        [Test]
        public void NodeRemoveChildTest()
        {
            var node = new Node("A");
            node.AddChild(new Node("B"));
            node.ChildrenNodes[0].Value.Should().Be("B");
            node.RemoveChild(new Node("B"));
            node.ChildrenNodes.Contains(new Node("B")).Should().BeFalse();
            node.ChildrenNodes.Count.Should().Be(0);
        }

        [Test]
        public void NodeRemoveChildExceptionTest_NodeIsNotAChild()
        {
            var node = new Node("A");
            node.AddChild(new Node("B"));
            node.RemoveChild(new Node("B"));

            Action act = () => node.RemoveChild(new Node("B"));
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Node B is not a child of Node A");
        }
    }
}