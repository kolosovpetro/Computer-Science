using NUnit.Framework;
using WeightedGraphNodes.GraphSearching;
using WeightedGraphNodes.Interfaces;
using WeightedGraphNodes.WeightedGraph;

namespace WeightedGraphNodes.UnitTests
{
    [TestFixture]
    internal class GraphSearchTests
    {
        [Test]
        public void TestDoSearch()
        {
            IGraph<char> g1 = new Graph<char>();
            g1.AddNode('A');
            g1.AddNode('B');
            g1.AddNode('C');
            g1.AddNode('D');
            g1.AddNode('E');
            g1.AddNode('F');

            g1.AddEdge('A', 'B', 10);
            g1.AddEdge('A', 'C', 20);
            g1.AddEdge('A', 'D', 30);
            g1.AddEdge('A', 'E', 40);

            GraphSearch<char> s1 = new GraphSearch<char>(g1);
            Assert.That(s1.Search('E'), Is.EqualTo(true));
            Assert.That(s1.Search('F'), Is.EqualTo(false)); // this test to be false, since any Edge leads to Node F
        }
    }
}
