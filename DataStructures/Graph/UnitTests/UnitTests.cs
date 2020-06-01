using Graph.Exceptions;
using Graph.Graph;
using NUnit.Framework;

namespace Graph.UnitTests
{
    [TestFixture]
    internal class UnitTests
    {
        private Graph<char> _graph;

        [Test]
        public void TestIsEmpty()
        {
            _graph = new Graph<char>();
            Assert.That(_graph.IsEmpty(), Is.EqualTo(true));
        }
        [Test]
        public void TestAddVertex()
        {
            _graph = new Graph<char>();
            _graph.AddVertex('N', 20);
            Assert.That(_graph.IsEmpty(), Is.EqualTo(false));
        }
        [Test]
        public void TestVertexIndex()
        {
            _graph = new Graph<char>();
            _graph.AddVertex('N', 20);
            _graph.AddVertex('B', 30);
            _graph.AddVertex('A', 40);
            _graph.AddVertex('F', 50);
            _graph.AddVertex('D', 60);
            Assert.That(_graph.VertexIndex('A'), Is.EqualTo(2));
            Assert.That(_graph.VertexIndex('С'), Is.EqualTo(-1));
        }
        [Test]
        public void TestAddEdge()
        {
            _graph = new Graph<char>();
            _graph.AddVertex('N', 20);
            _graph.AddVertex('B', 30);
            _graph.AddVertex('A', 40);
            _graph.AddVertex('F', 50);
            _graph.AddVertex('D', 60);
            _graph.AddEdge('N', 'B');
            Assert.That(_graph.AreConnected('N', 'B'), Is.EqualTo(true));
            Assert.That(_graph.AreConnected('N', 'A'), Is.EqualTo(false));
            Assert.Throws<VertexConnectionException>(() => _graph.AddEdge('A', 'S'));
        }
        [Test]
        public void TestAreConnected()
        {
            _graph = new Graph<char>();
            _graph.AddVertex('N', 20);
            _graph.AddVertex('B', 30);
            _graph.AddVertex('A', 40);
            _graph.AddVertex('F', 50);
            _graph.AddVertex('D', 60);
            _graph.AddEdge('N', 'B');
            Assert.That(_graph.AreConnected('N', 'B'), Is.EqualTo(true));
            Assert.That(_graph.AreConnected('N', 'A'), Is.EqualTo(false));
        }

        [Test]
        public void TestRemoveEdge()
        {
            _graph = new Graph<char>();
            _graph.AddVertex('N', 20);
            _graph.AddVertex('B', 30);
            _graph.AddVertex('A', 40);
            _graph.AddVertex('F', 50);
            _graph.AddVertex('D', 60);
            _graph.AddEdge('N', 'B');
            Assert.That(_graph.AreConnected('N', 'B'), Is.EqualTo(true));
            _graph.RemoveEdge('N', 'B');
            Assert.That(_graph.AreConnected('N', 'B'), Is.EqualTo(false));
            Assert.Throws<VertexConnectionException>(() => _graph.RemoveEdge('N', 'B'));
        }
        [Test]
        public void TestContains()
        {
            _graph = new Graph<char>();
            _graph.AddVertex('N', 20);
            _graph.AddVertex('B', 30);
            _graph.AddVertex('A', 40);
            _graph.AddVertex('F', 50);
            _graph.AddVertex('D', 60);
            Assert.That(_graph.Contains('F'), Is.EqualTo(true));
            Assert.That(_graph.Contains('S'), Is.EqualTo(false));
            _graph.Contains('S', out int index);
            Assert.That(index, Is.EqualTo(-1));
        }
    }
}
