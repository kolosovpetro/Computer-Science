using NUnit.Framework;
using WeightedGraphNodes.Interfaces;
using WeightedGraphNodes.WeightedGraph;

namespace WeightedGraphNodes.UnitTests
{
    [TestFixture]
    class NodeTests
    {
        INode<char> TestNode;

        [Test]
        public void TestInitialization()
        {
            TestNode = new Node<char>('A');
            Assert.That(TestNode.Data, Is.EqualTo('A'));
        }
        [Test]
        public void TestSetNext()
        {
            TestNode = new Node<char>('A');
            INode<char> NextNode = new Node<char>('B');
            TestNode.AddNext(NextNode);
            Assert.That(TestNode.Next[0].Data, Is.EqualTo('B'));
        }
    }
}
