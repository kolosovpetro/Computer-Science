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
            if (vertex.CurrentGraph != this)
                throw new InvalidOperationException("Vertex does not belong to the graph.");

            return Edges.Where(x => x.StartVertex.Equals(vertex))
                .Select(t => t.EndVertex)
                .ToList();
        }

        public bool AreAdjacent(IVertex<T> vertexOne, IVertex<T> vertexTwo)
        {
            if (vertexOne.CurrentGraph != this || vertexTwo.CurrentGraph != this)
                throw new InvalidOperationException("One or more vertex does not belong to the graph.");

            if (Edges.Any(x => x.StartVertex.Equals(vertexOne) && x.EndVertex.Equals(vertexTwo)))
                return true;

            if (Edges.Any(x => x.StartVertex.Equals(vertexTwo) && x.EndVertex.Equals(vertexOne)))
                return true;

            return false;
        }

        public IVertex<T> AddVertex(T data)
        {
            if (Vertices.Any(x => x.Data.Equals(data)))
                throw new InvalidOperationException("Vertex with same data is already in graph.");
            var vertex = new Vertex<T>(data, this);
            Vertices.Add(vertex);
            return vertex;
        }

        public IEdge<T> AddEdge(IVertex<T> startVertex, IVertex<T> endVertex)
        {
            if (startVertex.CurrentGraph != this || endVertex.CurrentGraph != this)
                throw new InvalidOperationException("One or more vertices does not belong to graph.");

            if (Edges.Any(x => x.StartVertex.Equals(startVertex) && x.EndVertex.Equals(endVertex)))
                throw new InvalidOperationException("Graph already contains such edge.");

            var edge = new Edge<T>(startVertex, endVertex, this);
            Edges.Add(edge);
            startVertex.IncrementDegree();
            endVertex.IncrementDegree();
            return edge;
        }

        public IEdge<T> AddEdge(IVertex<T> startVertex, IVertex<T> endVertex, int weight)
        {
            if (startVertex.CurrentGraph != this || endVertex.CurrentGraph != this)
                throw new InvalidOperationException("One or more vertices does not belong to graph.");

            if (Edges.Any(x => x.StartVertex.Equals(startVertex) && x.EndVertex.Equals(endVertex)))
                throw new InvalidOperationException("Graph already contains such edge.");

            var edge = new Edge<T>(startVertex, endVertex, weight, this);
            Edges.Add(edge);
            startVertex.IncrementDegree();
            endVertex.IncrementDegree();
            return edge;
        }

        public void RemoveVertex(T data)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveVertex(IVertex<T> vertex)
        {
            throw new NotImplementedException();
        }

        public void RemoveEdge(IVertex<T> startVertex, IVertex<T> endVertex)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveEdge(IEdge<T> edge)
        {
            throw new NotImplementedException();
        }
    }
}