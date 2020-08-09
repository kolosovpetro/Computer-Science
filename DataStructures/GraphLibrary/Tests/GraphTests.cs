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
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');

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

            var vertex = new Vertex<char>('F');
            Action act2 = () => graph.AddEdge(vertex, c);
            act2.Should().Throw<InvalidOperationException>()
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
            Action act = () => graph.AreAdjacent(vertex, d);

            act.Should().Throw<InvalidOperationException>()
                .WithMessage("One or more vertex does not belong to the graph.");
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
        public void GraphRemoveEdgeTest()
        {
        }
    }
}