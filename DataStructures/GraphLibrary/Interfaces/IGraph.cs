using System.Collections.Generic;

namespace GraphLibrary.Interfaces
{
    public interface IGraph<T>
    {
        /// <summary>
        /// Returns the list of all edges belong to current graph
        /// </summary>
        List<IEdge<T>> Edges { get; }
        
        /// <summary>
        /// Returns the list of all vertices belong to current graph
        /// </summary>
        List<IVertex<T>> Vertices { get; }
        
        /// <summary>
        /// Returns the total number of the vertices in graph
        /// </summary>
        int Count { get; }
        
        /// <summary>
        /// Checks whenever all vertices of graph are visited
        /// </summary>
        bool IsTraversed { get; }

        /// <summary>
        /// Returns list of all neighbor vertices of specified vertex
        /// </summary>
        List<IVertex<T>> NeighborVertices(IVertex<T> vertex);
        
        /// <summary>
        /// Returns a list of all edges in the graph, such that start from particular vertex
        /// </summary>
        List<IEdge<T>> EdgesStartWithVertex(IVertex<T> vertex);
        
        /// <summary>
        /// Returns list of all edges that contain particular vertex
        /// </summary>
        List<IEdge<T>> EdgesContainVertex(IVertex<T> vertex);
        
        /// <summary>
        /// Checks whenever there is a path between two vertices.
        /// Returns true if graph contains and edge such that start vertex and end vertex are parameters
        /// </summary>
        bool AreAdjacent(IVertex<T> startVertex, IVertex<T> endVertex);
        
        /// <summary>
        /// Adds new vertex with specified data to the graph and gives pointer to it
        /// </summary>
        IVertex<T> AddVertex(T data);

        /// <summary>
        /// Creates a new unweighted edge between two vertices, if it does not exist
        /// </summary>
        IEdge<T> AddEdge(IVertex<T> startVertex, IVertex<T> endVertex);

        /// <summary>
        /// Creates a new weighted edge between two vertices of graph, if is does not exist
        /// </summary>
        IEdge<T> AddEdge(IVertex<T> startVertex, IVertex<T> endVertex, int weight);
        
        /// <summary>
        /// Removes vertex with specified data
        /// </summary>
        void RemoveVertex(T data);

        /// <summary>
        /// Removes vertex from the graph by reference
        /// </summary>
        void RemoveVertex(IVertex<T> vertex);
        
        /// <summary>
        /// Removes an edge between two vertices, if such edge exists
        /// </summary>
        void RemoveEdge(IVertex<T> startVertex, IVertex<T> endVertex);
        
        /// <summary>
        /// Removes an edge from graph, if such edge belongs to graph
        /// </summary>
        void RemoveEdge(IEdge<T> edge);
        
        /// <summary>
        /// Checks whenever graph contains vertex with specified data 
        /// </summary>
        bool ContainsVertex(T data);

        /// <summary>
        /// Checks whenever graph contains specified vertex
        /// </summary>
        bool ContainsVertex(IVertex<T> vertex);
        
        /// <summary>
        /// Checks whenever graph contains specified edge
        /// </summary>
        bool ContainsEdge(IEdge<T> edge);
        
        /// <summary>
        /// Checks whenever graph contains an edge with specified start data and end data
        /// </summary>
        bool ContainsEdge(T startData, T endData);
        
        /// <summary>
        /// Resets all vertices of a graph to be unvisited
        /// </summary>
        void Reset();
    }
}