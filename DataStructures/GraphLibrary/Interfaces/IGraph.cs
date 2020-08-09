using System.Collections.Generic;

namespace GraphLibrary.Interfaces
{
    public interface IGraph<T>
    {
        /// <summary>
        /// Returns all the edges of the graph
        /// </summary>
        List<IEdge<T>> Edges { get; }
        
        /// <summary>
        /// Returns the vertices of the graph
        /// </summary>
        List<IVertex<T>> Vertices { get; }
        
        /// <summary>
        /// Returns total number of vertices in graph
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Returns list of all neighbors of specified vertex
        /// </summary>
        List<IVertex<T>> GetNeighbors(IVertex<T> vertex);
        
        /// <summary>
        /// Checks whenever vertices are adjacent (connected)
        /// </summary>
        bool AreAdjacent(IVertex<T> vertexOne, IVertex<T> vertexTwo);
        
        /// <summary>
        /// Adds new vertex to the graph and gives pointer to it
        /// </summary>
        IVertex<T> AddVertex(T data);

        /// <summary>
        /// Creates a new unweighted edge between two vertices
        /// </summary>
        IEdge<T> AddEdge(IVertex<T> startVertex, IVertex<T> endVertex);

        /// <summary>
        /// Creates a new weighted edge between two vertices of graph
        /// </summary>
        IEdge<T> AddEdge(IVertex<T> startVertex, IVertex<T> endVertex, int weight);
        
        /// <summary>
        /// Removes vertex with specified data
        /// </summary>
        void RemoveVertex(T data);

        /// <summary>
        /// Removes vertex from the graph
        /// </summary>
        void RemoveVertex(IVertex<T> vertex);
        
        /// <summary>
        /// Removes an edge between two vertices, if such edge exists
        /// </summary>
        void RemoveEdge(IVertex<T> startVertex, IVertex<T> endVertex);
        
        /// <summary>
        /// Removes an edge from graph, if such edge exists
        /// </summary>
        /// <param name="edge"></param>
        void RemoveEdge(IEdge<T> edge);
    }
}