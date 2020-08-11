using System;
using System.Collections.Generic;
using System.Linq;
using GraphLibrary.Interfaces;

namespace GraphLibrary.Implementations
{
    public class Vertex<T> : IVertex<T>
    {
        /// <summary>
        /// Vertex data
        /// </summary>
        public T Data { get; }

        /// <summary>
        /// Boolean, indicates whenever vertex is visited
        /// </summary>
        public bool IsVisited { get; private set; }

        /// <summary>
        /// Gives a pointer to the graph vertex belongs to
        /// </summary>
        public IGraph<T> CurrentGraph { get; set; }

        /// <summary>
        /// Degree of a vertex
        /// </summary>
        public int Degree { get; set; }

        public Vertex(T data) => Data = data;

        public Vertex(T data, IGraph<T> currentGraph)
        {
            Data = data;
            CurrentGraph = currentGraph;
        }

        /// <summary>
        /// Marks vertex as visited
        /// </summary>
        public void Visit() => IsVisited = true;

        /// <summary>
        /// Resets vertex to be unvisited
        /// </summary>
        public void Reset() => IsVisited = false;

        /// <summary>
        /// Increments vertex degree
        /// </summary>
        public void IncrementDegree() => Degree++;

        /// <summary>
        /// Decrements vertex degree
        /// </summary>
        public void DecrementDegree() => Degree--;

        /// <summary>
        /// Returns the list of edges which start from current vertex
        /// </summary>
        public List<IEdge<T>> AdjacentEdges()
        {
            if (CurrentGraph == null)
                throw new InvalidOperationException("Vertex does not belong to any graph.");
            
            return CurrentGraph.Edges.Where(x => x.StartVertex.Equals(this)).ToList();
        }

        /// <summary>
        /// Returns list of adjacent vertices to current vertex
        /// </summary>
        public List<IVertex<T>> AdjacentVertices() => AdjacentEdges().Select(t => t.EndVertex).ToList();

        /// <summary>
        /// Returns list of all adjacent and unvisited vertices
        /// </summary>
        public List<IVertex<T>> AdjacentUnvisitedVertices() => AdjacentVertices().Where(x => !x.IsVisited).ToList();

        private bool Equals(Vertex<T> other)
        {
            return EqualityComparer<T>.Default.Equals(Data, other.Data)
                   && IsVisited == other.IsVisited && Degree == other.Degree;
        }

        public bool Equals(IVertex<T> other)
        {
            return other != null
                   && IsVisited == other.IsVisited
                   && Data.Equals(other.Data)
                   && Degree == other.Degree;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Vertex<T>) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Data, IsVisited, Degree);
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}