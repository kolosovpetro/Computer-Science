using NUnit.Framework;
using WeightedGraphNodes.Interfaces;
using WeightedGraphNodes.WeightedGraph;

namespace WeightedGraphNodes.UnitTests
{
    [TestFixture]
    internal class GraphTests
    {
        private IGraph<char> _g1;

        [Test]
        public void TestIsEmpty()
        {
            _g1 = new Graph<char>();
            Assert.That(_g1.IsEmpty, Is.EqualTo(true));
        }

        [Test]
        public void TestAddNode()
        {
            _g1 = new Graph<char>();
            _g1.AddNode('A');
            Assert.That(_g1.IsEmpty, Is.EqualTo(false));
            Assert.That(_g1.Nodes[0].Data, Is.EqualTo('A'));
        }

        [Test]
        public void TestContainsNode()
        {
            _g1 = new Graph<char>();
            _g1.AddNode('A');
            Assert.That(_g1.ContainsNode('A'), Is.EqualTo(true));
            Assert.That(_g1.ContainsNode('J'), Is.EqualTo(false));
        }

        [Test]
        public void TestOutContainsNode()
        {
            _g1 = new Graph<char>();
            _g1.AddNode('A');
            _g1.ContainsNode('A', out int NodeIndex);
            Assert.That(NodeIndex, Is.EqualTo(0));
            _g1.ContainsNode('J', out int NodeIndex2);
            Assert.That(NodeIndex2, Is.EqualTo(-1));

        }

        [Test]
        public void TestRemoveNode()
        {
            _g1 = new Graph<char>();
            _g1.AddNode('A');
            _g1.AddNode('B');
            _g1.AddNode('C');
            _g1.AddEdge('A', 'B', 10);
            _g1.AddEdge('A', 'C', 20);
            Assert.That(_g1.AreConnected('A', 'B'), Is.EqualTo(true));
            Assert.That(_g1.AreConnected('A', 'C'), Is.EqualTo(true));
            _g1.RemoveNode('B');
            Assert.That(_g1.ContainsNode('B'), Is.EqualTo(false));
            Assert.That(_g1.Nodes[0].Next[0].Data.Equals('C'), Is.EqualTo(true));
            Assert.That(_g1.AreConnected('A', 'B'), Is.EqualTo(false));
        }

        [Test]
        public void TestAddEdge()
        {
            _g1 = new Graph<char>();
            _g1.AddNode('A');
            _g1.AddNode('B');
            _g1.AddNode('C');
            _g1.AddNode('D');
            _g1.AddEdge('A', 'B', 10);
            _g1.AddEdge('A', 'C', 20);
            Assert.That(_g1.AreConnected('A', 'B'), Is.EqualTo(true));
            Assert.That(_g1.AreConnected('A', 'C'), Is.EqualTo(true));
        }
    }
}
