using System;
using System.Collections.Generic;

namespace GraphLibrary.Interfaces
{
    public interface IVertex<T> : IEquatable<IVertex<T>>
    {
        /// <summary>
        /// Vertex data
        /// </summary>
        T Data { get; }

        /// <summary>
        /// Boolean, indicates whenever vertex is visited
        /// </summary>
        bool IsVisited { get; }

        /// <summary>
        /// Gives a pointer to the graph vertex belongs to
        /// </summary>
        IGraph<T> CurrentGraph { get; set; }

        /// <summary>
        /// Degree of a vertex
        /// </summary>
        int Degree { get; set; }

        /// <summary>
        /// Marks vertex as visited
        /// </summary>
        void Visit();
        
        /// <summary>
        /// Resets vertex to be unvisited
        /// </summary>
        void Reset();
        
        /// <summary>
        /// Increments vertex degree
        /// </summary>
        void IncrementDegree();
        
        /// <summary>
        /// Decrements vertex degree
        /// </summary>
        void DecrementDegree();
        
        /// <summary>
        /// Returns the list of edges which start from current vertex
        /// </summary>
        List<IEdge<T>> AdjacentEdges();
        
        /// <summary>
        /// Returns list of adjacent vertices to current vertex
        /// </summary>
        List<IVertex<T>> AdjacentVertices();
        
        /// <summary>
        /// Returns list of all adjacent and unvisited vertices
        /// </summary>
        List<IVertex<T>> AdjacentUnvisitedVertices();
    }
}