using System;
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
        public void AddVertexExceptionTest()
        {
            IGraph<char> graph = new Graph<char>();
            graph.AddVertex('A');
            graph.AddVertex('B');

            Action act = () => graph.AddVertex('A');
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Vertex with same data is already in graph.");
        }

        [Test]
        public void AddNotWeightedEdgeTest()
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
            graph.AreAdjacent(a, b).Should().BeTrue();
            graph.AreAdjacent(b, a).Should().BeFalse();
            graph.AreAdjacent(b, c).Should().BeFalse();
            var vertex = new Vertex<char>('F');
            Action act = () => graph.AreAdjacent(vertex, d);

            act.Should().Throw<InvalidOperationException>()
                .WithMessage("One or more vertex does not belong to the graph.");
        }

        [Test]
        public void AddWeightedEdgeTest()
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
        public void GetVertexNeighborsTest()
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

            var adjacentVertices = graph.NeighborVertices(a);
            a.Degree.Should().Be(4);
            adjacentVertices.Count.Should().Be(4);
            adjacentVertices[0].Should().Be(b);
            adjacentVertices[1].Should().Be(c);
            adjacentVertices[2].Should().Be(d);
            adjacentVertices[3].Should().Be(e);

            var vertex = new Vertex<char>('F');

            Action act = () => graph.NeighborVertices(vertex);
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Vertex does not belong to the graph.");
        }

        [Test]
        public void RemoveEdgeByEdgeReferenceTest()
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
            graph.ContainsEdge(e1).Should().BeFalse();
            graph.ContainsEdge('A', 'B').Should().BeFalse();
            a.Degree.Should().Be(3);
            e1.CurrentGraph.Should().BeNull();
            graph.AreAdjacent(a, b).Should().BeFalse();

            graph.RemoveEdge(e2);
            graph.ContainsEdge(e2).Should().BeFalse();
            graph.ContainsEdge('A', 'C').Should().BeFalse();
            a.Degree.Should().Be(2);
            e2.CurrentGraph.Should().BeNull();
            graph.AreAdjacent(a, c).Should().BeFalse();

            Action act1 = () => graph.RemoveEdge(e1);
            act1.Should().Throw<InvalidOperationException>()
                .WithMessage("Edge does not belong to the graph.");

            var vertex1 = new Vertex<char>('F');
            var vertex2 = new Vertex<char>('G');

            var edge1 = new Edge<char>(vertex1, e);
            var edge2 = new Edge<char>(d, vertex1);
            var edge3 = new Edge<char>(vertex1, vertex2);

            Action act2 = () => graph.RemoveEdge(edge1);
            act2.Should().Throw<InvalidOperationException>()
                .WithMessage("One or more vertices of edge does not belong to graph");

            Action act3 = () => graph.RemoveEdge(edge2);
            act3.Should().Throw<InvalidOperationException>()
                .WithMessage("One or more vertices of edge does not belong to graph");

            Action act4 = () => graph.RemoveEdge(edge3);
            act4.Should().Throw<InvalidOperationException>()
                .WithMessage("One or more vertices of edge does not belong to graph");
        }

        [Test]
        public void RemoveEdgeByVerticesReferencesTest()
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
            graph.ContainsEdge(e1).Should().BeFalse();
            graph.ContainsEdge('A', 'B').Should().BeFalse();
            a.Degree.Should().Be(3);
            e1.CurrentGraph.Should().BeNull();
            graph.AreAdjacent(a, b).Should().BeFalse();

            graph.RemoveEdge(a, c);
            graph.ContainsEdge(e2).Should().BeFalse();
            graph.ContainsEdge('A', 'C').Should().BeFalse();
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
        public void RemoveVertexByDataTest()
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
            graph.ContainsVertex(a).Should().BeFalse();
            graph.ContainsVertex('A').Should().BeFalse();
            a.CurrentGraph.Should().BeNull();
            a.Degree.Should().Be(0);

            Action act = () => graph.RemoveVertex('A');
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("There is no any vertex with such data.");
        }

        [Test]
        public void RemoveVertexByReferenceTest()
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
            graph.ContainsVertex(a).Should().BeFalse();
            graph.ContainsVertex('A').Should().BeFalse();
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

        [Test]
        public void GetEdgesStartsWithVertexTest()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            var e1 = graph.AddEdge(a, b, 5);
            var e2 = graph.AddEdge(a, d, 7);
            var e3 = graph.AddEdge(d, a, 8);
            var e4 = graph.AddEdge(c, e, 9);

            var edgesStartsWith = graph.EdgesStartWithVertex(a);
            edgesStartsWith.Count.Should().Be(2);
            edgesStartsWith[0].Should().Be(e1);
            edgesStartsWith[1].Should().Be(e2);

            edgesStartsWith = graph.EdgesStartWithVertex(b);
            edgesStartsWith.Should().BeEmpty();

            var vertex = new Vertex<char>('F');
            Action act = () => graph.EdgesStartWithVertex(vertex);
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Vertex does not belong to the graph.");
        }

        [Test]
        public void EdgesContainVertexTest()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            var e1 = graph.AddEdge(a, b, 5);
            var e2 = graph.AddEdge(a, d, 7);
            var e3 = graph.AddEdge(d, b, 8);
            var e4 = graph.AddEdge(c, a, 9);

            var containVertex = graph.EdgesContainVertex(a);
            containVertex.Count.Should().Be(3);
            containVertex[0].Should().Be(e1);
            containVertex[1].Should().Be(e2);
            containVertex[2].Should().Be(e4);

            var vertex = new Vertex<char>('F');
            Action act = () => graph.EdgesContainVertex(vertex);
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Vertex does not belong to the graph.");
        }

        [Test]
        public void VertexAdjacentEdgesTest()
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

            var adjacentEdges = a.AdjacentEdges();
            adjacentEdges.Count.Should().Be(4);
            adjacentEdges[0].Should().Be(e1);
            adjacentEdges[1].Should().Be(e2);
            adjacentEdges[2].Should().Be(e3);
            adjacentEdges[3].Should().Be(e4);

            Action act = () => new Vertex<char>('F').AdjacentEdges();
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Vertex does not belong to any graph.");
        }

        [Test]
        public void VertexAdjacentVerticesTest()
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

            var adjacentEdges = a.AdjacentVertices();
            adjacentEdges.Count.Should().Be(4);
            adjacentEdges[0].Should().Be(b);
            adjacentEdges[1].Should().Be(c);
            adjacentEdges[2].Should().Be(d);
            adjacentEdges[3].Should().Be(e);

            Action act = () => new Vertex<char>('F').AdjacentVertices();
            
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Vertex does not belong to any graph.");
        }

        [Test]
        public void VertexAdjacentUnvisitedVerticesTest()
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

            var adjacentEdges = a.AdjacentUnvisitedVertices();
            adjacentEdges.Count.Should().Be(4);
            adjacentEdges[0].Should().Be(b);
            adjacentEdges[1].Should().Be(c);
            adjacentEdges[2].Should().Be(d);
            adjacentEdges[3].Should().Be(e);
            
            b.Visit();
            c.Visit();
            
            adjacentEdges = a.AdjacentUnvisitedVertices();
            adjacentEdges.Count.Should().Be(2);
            adjacentEdges[0].Should().Be(d);
            adjacentEdges[1].Should().Be(e);

            Action act = () => new Vertex<char>('F').AdjacentVertices();
            
            act.Should().Throw<InvalidOperationException>()
                .WithMessage("Vertex does not belong to any graph.");
        }

        [Test]
        public void GraphResetTest()
        {
            IGraph<char> graph = new Graph<char>();
            var a = graph.AddVertex('A');
            var b = graph.AddVertex('B');
            var c = graph.AddVertex('C');
            var d = graph.AddVertex('D');
            var e = graph.AddVertex('E');

            foreach (var vertex in graph.Vertices) 
                vertex.Visit();

            graph.IsTraversed.Should().BeTrue();
            graph.Reset();
            graph.IsTraversed.Should().BeFalse();
        }
    }
}