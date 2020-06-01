using NUnit.Framework;
using WeightedGraphNodes.Interfaces;
using WeightedGraphNodes.WeightedGraph;

namespace WeightedGraphNodes.UnitTests
{
    [TestFixture]
    internal class NodeTests
    {
        private INode<char> _testNode;

        [Test]
        public void TestInitialization()
        {
            _testNode = new Node<char>('A');
            Assert.That(_testNode.Data, Is.EqualTo('A'));
        }

        [Test]
        public void TestSetNext()
        {
            _testNode = new Node<char>('A');
            INode<char> nextNode = new Node<char>('B');
            _testNode.AddNext(nextNode);
            Assert.That(_testNode.Next[0].Data, Is.EqualTo('B'));
        }
    }
}
