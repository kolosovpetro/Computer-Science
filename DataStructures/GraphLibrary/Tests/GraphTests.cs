using System;
using System.Linq;
using FluentAssertions;
using GraphLibrary.Implementations;
using GraphLibrary.Interfaces;
using NUnit.Framework;

namespace GraphLibrary.Tests
{
    [TestFixture]
    public class GraphTests
    {
        [Test]
        public void GraphInitializationTest()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            graph.Count.Should().Be(5);
            a.CurrentGraph.Should().Be(graph);
            b.CurrentGraph.Should().Be(graph);
            c.CurrentGraph.Should().Be(graph);
            d.CurrentGraph.Should().Be(graph);
            e.CurrentGraph.Should().Be(graph);
        }

        [Test]
        public void GraphAddVertexExceptionTest()
        {
            IGraph<char> graph = new Graph<char>();
            graph.AddVertex('A');
            graph.AddVertex('B');

            Action act = () => graph.AddVertex('A');
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Vertex with same data is already in graph.");
        }

        [Test]
        public void GraphAddUnweightedEdgeTest()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            var edge = graph.AddEdge(a, b);
            edge.Weight.Should().Be(0);
            a.Degree.Should().Be(1);
            b.Degree.Should().Be(1);

            Action act1 = () => graph.AddEdge(a, b);
            act1.Should().Throw<InvalidOperationException>()
                .WithMessage("Graph already contains such edge.");

            Action act2 = () => graph.AddEdge(a, b, 20);
            act2.Should().Throw<InvalidOperationException>()
                .WithMessage("Graph already contains such edge.");

            var vertex = new Vertex<char>('F');
            Action act3 = () => graph.AddEdge(vertex, c);
            act3.Should().Throw<InvalidOperationException>()
                .WithMessage("One or more vertices does not belong to graph.");
        }

        [Test]
        public void VerticesAreAdjacentTest()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            var e1 = graph.AddEdge(a, b);
            var e2 = graph.AddEdge(b, a);
            graph.AreAdjacent(a, b).Should().BeTrue();
            graph.AreAdjacent(b, a).Should().BeTrue();
            graph.AreAdjacent(b, c).Should().BeFalse();
            var vertex = new Vertex<char>('F');
            Action act = () => graph.AreAdjacent(vertex, d);

            act.Should().Throw<InvalidOperationException>()
                .WithMessage("One or more vertex does not belong to the graph.");
        }

        [Test]
        public void GraphAddWeightedEdgeTest()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            var e1 = graph.AddEdge(a, b, 30);
            var e2 = graph.AddEdge(b, a, 30);
            graph.AreAdjacent(a, b).Should().BeTrue();
            graph.AreAdjacent(b, a).Should().BeTrue();
            graph.AreAdjacent(b, c).Should().BeFalse();
            var vertex = new Vertex<char>('F');

            Action act1 = () => graph.AreAdjacent(vertex, d);
            act1.Should().Throw<InvalidOperationException>()
                .WithMessage("One or more vertex does not belong to the graph.");

            Action act2 = () => graph.AddEdge(a, b);
            act2.Should().Throw<InvalidOperationException>()
                .WithMessage("Graph already contains such edge.");

            Action act3 = () => graph.AddEdge(a, b, 20);
            act3.Should().Throw<InvalidOperationException>()
                .WithMessage("Graph already contains such edge.");
        }

        [Test]
        public void GraphGetVertexNeighborsTest()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            var e1 = graph.AddEdge(a, b, 5);
            var e2 = graph.AddEdge(a, c, 7);
            var e3 = graph.AddEdge(a, d, 8);
            var e4 = graph.AddEdge(a, e, 9);

            var adjacentVertices = graph.GetNeighbors(a);
            a.Degree.Should().Be(4);
            adjacentVertices.Count.Should().Be(4);
            adjacentVertices[0].Should().Be(b);
            adjacentVertices[1].Should().Be(c);
            adjacentVertices[2].Should().Be(d);
            adjacentVertices[3].Should().Be(e);

            var vertex = new Vertex<char>('F');

            Action act = () => graph.GetNeighbors(vertex);
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Vertex does not belong to the graph.");
        }

        [Test]
        public void GraphRemoveVertexByDataTest()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            graph.RemoveVertex('A');
            a.CurrentGraph.Should().BeNull();
            graph.Vertices.Any(x => x.Data.Equals('A')).Should().BeFalse();
        }

        [Test]
        public void GraphRemoveEdgeByReference()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            var e1 = graph.AddEdge(a, b, 5);
            var e2 = graph.AddEdge(a, c, 7);
            var e3 = graph.AddEdge(a, d, 8);
            var e4 = graph.AddEdge(a, e, 9);

            a.Degree.Should().Be(4);
            graph.RemoveEdge(e1);
            a.Degree.Should().Be(3);
            e1.CurrentGraph.Should().BeNull();
            graph.AreAdjacent(a, b).Should().BeFalse();
            graph.RemoveEdge(e2);
            a.Degree.Should().Be(2);
            e2.CurrentGraph.Should().BeNull();
            graph.AreAdjacent(a, c).Should().BeFalse();

            Action act = () => graph.RemoveEdge(e1);
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Edge does not belong to the graph.");
        }

        [Test]
        public void GraphRemoveEdgeByTwoVerticesTest()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            var e1 = graph.AddEdge(a, b, 5);
            var e2 = graph.AddEdge(a, c, 7);
            var e3 = graph.AddEdge(a, d, 8);
            var e4 = graph.AddEdge(a, e, 9);

            graph.RemoveEdge(a, b);
            a.Degree.Should().Be(3);
            e1.CurrentGraph.Should().BeNull();
            graph.AreAdjacent(a, b).Should().BeFalse();

            graph.RemoveEdge(a, c);
            a.Degree.Should().Be(2);
            e2.CurrentGraph.Should().BeNull();
            graph.AreAdjacent(a, c).Should().BeFalse();

            Action act1 = () => graph.RemoveEdge(a, b);
            act1.Should().Throw<InvalidOperationException>()
                .WithMessage("There is no such vertex in the graph.");

            var vertex = new Vertex<char>('F');
            Action act2 = () => graph.RemoveEdge(vertex, d);
            act2.Should().Throw<InvalidOperationException>()
                .WithMessage("One or more vertex does not belong to graph.");
        }

        [Test]
        public void GraphRemoveVertexByData()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            var e1 = graph.AddEdge(a, b, 5);
            var e2 = graph.AddEdge(e, d, 7);
            var e3 = graph.AddEdge(d, a, 8);
            var e4 = graph.AddEdge(c, e, 9);

            graph.RemoveVertex('A');
            graph.Count.Should().Be(4);
            graph.Edges.Count.Should().Be(2);
            a.CurrentGraph.Should().BeNull();
            a.Degree.Should().Be(0);

            Action act = () => graph.RemoveVertex('A');
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("There is no any vertex with such data.");
        }

        [Test]
        public void RemoveVertexByReference()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            var e1 = graph.AddEdge(a, b, 5);
            var e2 = graph.AddEdge(e, d, 7);
            var e3 = graph.AddEdge(d, a, 8);
            var e4 = graph.AddEdge(c, e, 9);

            graph.RemoveVertex(a);
            graph.Count.Should().Be(4);
            graph.Edges.Count.Should().Be(2);
            a.CurrentGraph.Should().BeNull();
            a.Degree.Should().Be(0);

            Action act = () => graph.RemoveVertex(a);
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Vertex does not belong to the graph.");
        }

        [Test]
        public void GraphContainsVertexTest()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            graph.ContainsVertex(a).Should().BeTrue();
            graph.ContainsVertex('A').Should().BeTrue();
            graph.ContainsVertex('F').Should().BeFalse();
            var vertex = new Vertex<char>('T');
            graph.ContainsVertex(vertex).Should().BeFalse();
        }

        [Test]
        public void GraphContainsEdgeTest()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            var e1 = graph.AddEdge(a, b, 5);
            var e2 = graph.AddEdge(e, d, 7);
            var e3 = graph.AddEdge(d, a, 8);
            var e4 = graph.AddEdge(c, e, 9);

            graph.ContainsEdge(e1).Should().BeTrue();
            graph.ContainsEdge('A', 'B').Should().BeTrue();
            graph.ContainsEdge('B', 'A').Should().BeFalse();
            var edge = new Edge<char>(b, a);
            graph.ContainsEdge(edge).Should().BeFalse();
        }
    }
}