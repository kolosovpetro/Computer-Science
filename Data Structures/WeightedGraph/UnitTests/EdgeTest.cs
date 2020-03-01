using NUnit.Framework;
using WeightedGraphNodes.Interfaces;
using WeightedGraphNodes.WeightedGraph;

namespace WeightedGraphNodes.UnitTests
{
    [TestFixture]
    class EdgeTest
    {
        INode<char> n1;
        INode<char> n2;
        INode<char> n3;
        IEdge<char> e1;
        IEdge<char> e2;

        [Test]
        public void TestInitialization()
        {
            n1 = new Node<char>('A');
            n2 = new Node<char>('B');
            e1 = new Edge<char>(n1, n2, 20);
            Assert.That(n1.Next[0].Data, Is.EqualTo('B'));
            Assert.That(e1.Weight, Is.EqualTo(20));
            n3 = new Node<char>('C');
            e2 = new Edge<char>(n2, n3, 10);
            Assert.That(n2.Next[0].Data, Is.EqualTo('C'));
        }
    }
}
