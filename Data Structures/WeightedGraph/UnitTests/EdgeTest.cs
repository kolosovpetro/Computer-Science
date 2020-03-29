using NUnit.Framework;
using WeightedGraphNodes.Interfaces;
using WeightedGraphNodes.WeightedGraph;

namespace WeightedGraphNodes.UnitTests
{
    [TestFixture]
    internal class EdgeTest
    {
        private INode<char> _n1;
        private INode<char> _n2;
        private INode<char> _n3;
        private IEdge<char> _e1;

        [Test]
        public void TestInitialization()
        {
            _n1 = new Node<char>('A');
            _n2 = new Node<char>('B');
            _e1 = new Edge<char>(_n1, _n2, 20);
            Assert.That(_n1.Next[0].Data, Is.EqualTo('B'));
            Assert.That(_e1.Weight, Is.EqualTo(20));
            _n3 = new Node<char>('C');
            new Edge<char>(_n2, _n3, 10);
            Assert.That(_n2.Next[0].Data, Is.EqualTo('C'));
        }
    }
}
