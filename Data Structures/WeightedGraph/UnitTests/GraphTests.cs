using NUnit.Framework;
using WeightedGraphNodes.Interfaces;
using WeightedGraphNodes.WeightedGraph;

namespace WeightedGraphNodes.UnitTests
{
    [TestFixture]
    class GraphTests
    {
        IGraph<char> g1;

        [Test]
        public void TestIsEmpty()
        {
            g1 = new Graph<char>();
            Assert.That(g1.IsEmpty, Is.EqualTo(true));
        }
        [Test]
        public void TestAddNode()
        {
            g1 = new Graph<char>();
            g1.AddNode('A');
            Assert.That(g1.IsEmpty, Is.EqualTo(false));
            Assert.That(g1.Nodes[0].Data, Is.EqualTo('A'));
        }
        [Test]
        public void TestContainsNode()
        {
            g1 = new Graph<char>();
            g1.AddNode('A');
            Assert.That(g1.ContainsNode('A'), Is.EqualTo(true));
            Assert.That(g1.ContainsNode('J'), Is.EqualTo(false));
        }
        [Test]
        public void TestOutContainsNode()
        {
            g1 = new Graph<char>();
            g1.AddNode('A');
            g1.ContainsNode('A', out int NodeIndex);
            Assert.That(NodeIndex, Is.EqualTo(0));
            g1.ContainsNode('J', out int NodeIndex2);
            Assert.That(NodeIndex2, Is.EqualTo(-1));

        }
        [Test]
        public void TestRemoveNode()
        {
            g1 = new Graph<char>();
            g1.AddNode('A');
            g1.AddNode('B');
            g1.AddNode('C');
            g1.AddEdge('A', 'B', 10);
            g1.AddEdge('A', 'C', 20);
            Assert.That(g1.AreConnected('A', 'B'), Is.EqualTo(true));
            Assert.That(g1.AreConnected('A', 'C'), Is.EqualTo(true));
            g1.RemoveNode('B');
            Assert.That(g1.ContainsNode('B'), Is.EqualTo(false));
            Assert.That(g1.Nodes[0].Next[0].Data.Equals('C'), Is.EqualTo(true));
            Assert.That(g1.AreConnected('A', 'B'), Is.EqualTo(false));
        }
        [Test]
        public void TestAddEdge()
        {
            g1 = new Graph<char>();
            g1.AddNode('A');
            g1.AddNode('B');
            g1.AddNode('C');
            g1.AddNode('D');
            g1.AddEdge('A', 'B', 10);
            g1.AddEdge('A', 'C', 20);
            Assert.That(g1.AreConnected('A', 'B'), Is.EqualTo(true));
            Assert.That(g1.AreConnected('A', 'C'), Is.EqualTo(true));
        }
    }
}
