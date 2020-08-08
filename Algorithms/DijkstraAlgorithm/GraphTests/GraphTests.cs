using DijkstraAlgorithm.Implementations;
using FluentAssertions;
using NUnit.Framework;

namespace DijkstraAlgorithm.GraphTests
{
    [TestFixture]
    public class GraphTests
    {
        [Test]
        public void EdgeTest()
        {
            var n1 = new Node("A");
            var n2 = new Node("B");
            var n3 = new Node("C");
            var n4 = new Node("D");

            var e1 = new Edge(n1, n2, 10);
            var e2 = new Edge(n2, n3, 20);
            var e3 = new Edge(n4, n1, 30);

            e1.StartVertex.Should().Be(n1);
            e1.EndVertex.Should().Be(n2);
            e1.Weight.Should().Be(10);

            e2.StartVertex.Should().Be(n2);
            e2.EndVertex.Should().Be(n3);
            e2.Weight.Should().Be(20);

            e3.StartVertex.Should().Be(n4);
            e3.EndVertex.Should().Be(n1);
            e3.Weight.Should().Be(30);
        }

        [Test]
        public void TestUnvisitedNodes()
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
        }

        [Test]
        public void DijkstraTest()
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
        }
    }
}