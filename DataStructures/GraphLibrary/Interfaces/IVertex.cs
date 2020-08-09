using System;

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
        /// Increments vertex degree
        /// </summary>
        void IncrementDegree();
        
        /// <summary>
        /// Decrements vertex degree
        /// </summary>
        void DecrementDegree();
    }
}