using System.Linq;
using DijkstraAlgorithm.Implementations;
using FluentAssertions;
using NUnit.Framework;

namespace DijkstraAlgorithm.DijkstraTDD
{
    [TestFixture]
    public class DijkstraTests
    {
        [Test]
        public void TestDijkstraUnvisitedUpdated()
        {
            var n1 = new Node("A");
            var n2 = new Node("B");
            var n3 = new Node("C");
            var n4 = new Node("D");
            var n5 = new Node("E");
            var n6 = new Node("F");

            var e1 = new Edge(n1, n2, 10);
            var e2 = new Edge(n2, n3, 20);
            var e3 = new Edge(n2, n4, 30);
            var e4 = new Edge(n4, n5, 30);
            var e5 = new Edge(n5, n6, 30);

            var graph = new Graph(e1, e2, e3, e4, e5);
            var dijkstra = new DijkstraMethod(graph);
            dijkstra.UpdateUnvisitedNodes();
            dijkstra.UpdateVisitedNodes();
            var unvisited = dijkstra.UnvisitedNodes;
            unvisited[0].Should().Be(n1);
            unvisited[1].Should().Be(n2);
            unvisited[2].Should().Be(n3);
            unvisited[3].Should().Be(n4);
            unvisited[4].Should().Be(n5);
            unvisited[5].Should().Be(n6);
            dijkstra.UnvisitedNodes.Count().Should().Be(6);
            dijkstra.VisitedNodes.Count().Should().Be(0);
            graph.Edges.ElementAt(0).First.Visit();
            dijkstra.UpdateUnvisitedNodes();
            dijkstra.UpdateVisitedNodes();
            dijkstra.UnvisitedNodes.Count.Should().Be(5);
            dijkstra.VisitedNodes.Count().Should().Be(1);
        }

        [Test]
        public void NeighborsTest()
        {
            var n1 = new Node("A");
            var n2 = new Node("B");
            var n3 = new Node("C");
            var n4 = new Node("D");
            var n5 = new Node("E");

            var e1 = new Edge(n1, n2, 6); // A - B
            var e2 = new Edge(n1, n4, 1); // A - D
            var e3 = new Edge(n4, n2, 2); // D - B
            var e4 = new Edge(n4, n5, 1); // D - E
            var e5 = new Edge(n5, n2, 2); // E - B
            var e6 = new Edge(n5, n3, 5); // E - C
            var e7 = new Edge(n3, n2, 5); // C - B

            var graph = new Graph(e1, e2, e3, e4, e5, e6, e7);
            var dijkstra = new DijkstraMethod(graph);
            n2.Visit();
            var neighbors = dijkstra.NeighborEdges(n1).ToList();
            neighbors.Count.Should().Be(1);
            neighbors.ElementAt(0).Last.Should().Be(n4);
        }

        [Test]
        public void TestDijkstraPathNoArgument()
        {
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");
            var e = new Node("E");

            var ab = new Edge(a, b, 6); // A - B
            var ba = new Edge(b, a, 6); // A - B
            
            var ad = new Edge(a, d, 1); // A - D
            var da = new Edge(d, a, 1); // A - D
            
            var db = new Edge(d, b, 2); // D - B
            var bd = new Edge(b, d, 2); // D - B
            
            var de = new Edge(d, e, 1); // D - E
            var ed = new Edge(e, d, 1); // D - E
            
            var eb = new Edge(e, b, 2); // E - B
            var be = new Edge(b, e, 2); // E - B
            
            var ec = new Edge(e, c, 5); // E - C
            var ce = new Edge(c, e, 5); // E - C
            
            var cb = new Edge(c, b, 5); // C - B
            var bc = new Edge(b, c, 5); // C - B

            var graph = new Graph(ab, ba, ad, da, db, bd, ed, de, eb, be, ec, ce, cb, bc);
            var dijkstra = new DijkstraMethod(graph);
            dijkstra.BuildShortPathTable(a);
            var patches = dijkstra.DistancesList;
            patches.Count.Should().NotBe(0);
            patches.FirstOrDefault(x => x.CurrentNode.Equals(c))?.Distance.Should().Be(7);
        }
    }
}