using System;
using System.Collections.Generic;
using System.Linq;
using GraphLibrary.Interfaces;

namespace GraphLibrary.Implementations
{
    public class Graph<T> : IGraph<T>
    {
        public List<IEdge<T>> Edges { get; }
        public List<IVertex<T>> Vertices { get; }
        public int Count => Vertices.Count;

        public Graph()
        {
            Edges = new List<IEdge<T>>();
            Vertices = new List<IVertex<T>>();
        }

        public List<IVertex<T>> GetNeighbors(IVertex<T> vertex)
        {
            if (!ContainsVertex(vertex))
                throw new InvalidOperationException("Vertex does not belong to the graph.");

            return Edges.Where(x => x.StartVertex.Equals(vertex))
                .Select(t => t.EndVertex)
                .ToList();
        }

        public bool AreAdjacent(IVertex<T> vertexOne, IVertex<T> vertexTwo)
        {
            if (!ContainsVertex(vertexOne) || !ContainsVertex(vertexTwo))
                throw new InvalidOperationException("One or more vertex does not belong to the graph.");

            return ContainsEdge(vertexOne.Data, vertexTwo.Data) || ContainsEdge(vertexTwo.Data, vertexOne.Data);
        }

        public IVertex<T> AddVertex(T data)
        {
            if (ContainsVertex(data))
                throw new InvalidOperationException("Vertex with same data is already in graph.");

            var vertex = new Vertex<T>(data, this);
            Vertices.Add(vertex);
            return vertex;
        }

        public IEdge<T> AddEdge(IVertex<T> startVertex, IVertex<T> endVertex)
        {
            if (!ContainsVertex(startVertex) || !ContainsVertex(endVertex))
                throw new InvalidOperationException("One or more vertices does not belong to graph.");

            if (ContainsEdge(startVertex.Data, endVertex.Data))
                throw new InvalidOperationException("Graph already contains such edge.");

            var edge = new Edge<T>(startVertex, endVertex, this);
            Edges.Add(edge);
            startVertex.IncrementDegree();
            endVertex.IncrementDegree();
            return edge;
        }

        public IEdge<T> AddEdge(IVertex<T> startVertex, IVertex<T> endVertex, int weight)
        {
            if (!ContainsVertex(startVertex) || !ContainsVertex(endVertex))
                throw new InvalidOperationException("One or more vertices does not belong to graph.");

            if (ContainsEdge(startVertex.Data, endVertex.Data))
                throw new InvalidOperationException("Graph already contains such edge.");

            var edge = new Edge<T>(startVertex, endVertex, weight, this);
            Edges.Add(edge);
            startVertex.IncrementDegree();
            endVertex.IncrementDegree();
            return edge;
        }

        public void RemoveVertex(T data)
        {
            if (!ContainsVertex(data))
                throw new InvalidOperationException("There is no any vertex with such data.");

            var vertex = Vertices.First(x => x.Data.Equals(data));
            var connectedEdges = Edges
                .Where(x => x.StartVertex.Equals(vertex) || x.EndVertex.Equals(vertex))
                .ToList();

            connectedEdges.ForEach(RemoveEdge);
            Vertices.Remove(vertex);
            vertex.CurrentGraph = null;
            vertex.Degree = 0;
        }

        public void RemoveVertex(IVertex<T> vertex)
        {
            if (!ContainsVertex(vertex))
                throw new InvalidOperationException("Vertex does not belong to the graph.");

            var connectedEdges = Edges
                .Where(x => x.StartVertex.Equals(vertex) || x.EndVertex.Equals(vertex))
                .ToList();

            connectedEdges.ForEach(RemoveEdge);
            Vertices.Remove(vertex);
            vertex.CurrentGraph = null;
            vertex.Degree = 0;
        }

        public void RemoveEdge(IVertex<T> startVertex, IVertex<T> endVertex)
        {
            if (!ContainsVertex(startVertex) || !ContainsVertex(endVertex))
                throw new InvalidOperationException("One or more vertex does not belong to graph.");

            if (!ContainsEdge(startVertex.Data, endVertex.Data))
                throw new InvalidOperationException("There is no such vertex in the graph.");

            var edge = Edges.First(x => x.StartVertex.Equals(startVertex)
                                        && x.EndVertex.Equals(endVertex));
            Edges.Remove(edge);

            edge.CurrentGraph = null;
            edge.StartVertex.DecrementDegree();
            edge.EndVertex.DecrementDegree();
        }

        public void RemoveEdge(IEdge<T> edge)
        {
            if (!ContainsVertex(edge.StartVertex) || !ContainsVertex(edge.EndVertex))
                throw new InvalidOperationException("One or more vertices of edge does not belong to graph");

            if (!ContainsEdge(edge))
                throw new InvalidOperationException("Edge does not belong to the graph.");

            edge.CurrentGraph = null;
            edge.StartVertex.DecrementDegree();
            edge.EndVertex.DecrementDegree();
            Edges.Remove(edge);
        }

        public bool ContainsVertex(T data)
        {
            return Vertices.Any(x => x.Data.Equals(data));
        }

        public bool ContainsVertex(IVertex<T> vertex)
        {
            return vertex.CurrentGraph == this;
        }

        public bool ContainsEdge(IEdge<T> edge)
        {
            return edge.CurrentGraph == this;
        }

        public bool ContainsEdge(T startData, T endData)
        {
            return Edges
                .Any(x => x.StartVertex.Data.Equals(startData) && x.EndVertex.Data.Equals(endData));
        }
    }
}