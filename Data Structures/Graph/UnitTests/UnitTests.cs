using NUnit.Framework;

namespace Graph
{
    [TestFixture]
    class UnitTests
    {
        Graph<char> g1;

        [Test]
        public void TestIsEmpty()
        {
            g1 = new Graph<char>();
            Assert.That(g1.IsEmpty(), Is.EqualTo(true));
        }
        [Test]
        public void TestAddVertex()
        {
            g1 = new Graph<char>();
            g1.AddVertex('N', 20);
            Assert.That(g1.IsEmpty(), Is.EqualTo(false));
        }
        [Test]
        public void TestVertexIndex()
        {
            g1 = new Graph<char>();
            g1.AddVertex('N', 20);
            g1.AddVertex('B', 30);
            g1.AddVertex('A', 40);
            g1.AddVertex('F', 50);
            g1.AddVertex('D', 60);
            Assert.That(g1.VertexIndex('A'), Is.EqualTo(2));
            Assert.That(g1.VertexIndex('С'), Is.EqualTo(-1));
        }
        [Test]
        public void TestAddEdge()
        {
            g1 = new Graph<char>();
            g1.AddVertex('N', 20);
            g1.AddVertex('B', 30);
            g1.AddVertex('A', 40);
            g1.AddVertex('F', 50);
            g1.AddVertex('D', 60);
            g1.AddEdge('N', 'B');
            Assert.That(g1.AreConnected('N', 'B'), Is.EqualTo(true));
            Assert.That(g1.AreConnected('N', 'A'), Is.EqualTo(false));
            Assert.Throws<VertexConnectionException>(() => g1.AddEdge('A', 'S'));
        }
        [Test]
        public void TestAreConnected()
        {
            g1 = new Graph<char>();
            g1.AddVertex('N', 20);
            g1.AddVertex('B', 30);
            g1.AddVertex('A', 40);
            g1.AddVertex('F', 50);
            g1.AddVertex('D', 60);
            g1.AddEdge('N', 'B');
            Assert.That(g1.AreConnected('N', 'B'), Is.EqualTo(true));
            Assert.That(g1.AreConnected('N', 'A'), Is.EqualTo(false));
        }

        [Test]
        public void TestRemoveEdge()
        {
            g1 = new Graph<char>();
            g1.AddVertex('N', 20);
            g1.AddVertex('B', 30);
            g1.AddVertex('A', 40);
            g1.AddVertex('F', 50);
            g1.AddVertex('D', 60);
            g1.AddEdge('N', 'B');
            Assert.That(g1.AreConnected('N', 'B'), Is.EqualTo(true));
            g1.RemoveEdge('N', 'B');
            Assert.That(g1.AreConnected('N', 'B'), Is.EqualTo(false));
            Assert.Throws<VertexConnectionException>(() => g1.RemoveEdge('N', 'B'));
        }
        [Test]
        public void TestContains()
        {
            g1 = new Graph<char>();
            g1.AddVertex('N', 20);
            g1.AddVertex('B', 30);
            g1.AddVertex('A', 40);
            g1.AddVertex('F', 50);
            g1.AddVertex('D', 60);
            Assert.That(g1.Contains('F'), Is.EqualTo(true));
            Assert.That(g1.Contains('S'), Is.EqualTo(false));
            g1.Contains('S', out int Index);
            Assert.That(Index, Is.EqualTo(-1));
        }
    }
}
