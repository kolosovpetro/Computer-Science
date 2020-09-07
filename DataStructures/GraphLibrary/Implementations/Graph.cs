using System;
using System.Collections.Generic;
using System.Linq;
using GraphLibrary.Interfaces;

namespace GraphLibrary.Implementations
{
    public class Graph<T> : IGraph<T>
    {
        /// <summary>
        /// Returns the list of all edges belong to current graph
        /// </summary>
        public List<IEdge<T>> Edges { get; }

        /// <summary>
        /// Returns the list of all vertices belong to current graph
        /// </summary>
        public List<IVertex<T>> Vertices { get; }

        /// <summary>
        /// Returns the total number of the vertices in graph
        /// </summary>
        public int Count => Vertices.Count;

        /// <summary>
        /// Checks whenever all vertices of graph are visited
        /// </summary>
        public bool IsTraversed => Vertices.All(x => x.IsVisited);

        public Graph()
        {
            Edges = new List<IEdge<T>>();
            Vertices = new List<IVertex<T>>();
        }

        /// <summary>
        /// Returns list of all neighbor vertices of specified vertex
        /// </summary>
        public List<IVertex<T>> NeighborVertices(IVertex<T> vertex)
        {
            if (!ContainsVertex(vertex))
                throw new InvalidOperationException("Vertex does not belong to the graph.");

            return EdgesStartWithVertex(vertex).Select(t => t.EndVertex).ToList();
        }

        /// <summary>
        /// Returns a list of all edges in the graph, such that start from particular vertex
        /// </summary>
        public List<IEdge<T>> EdgesStartWithVertex(IVertex<T> vertex)
        {
            if (!ContainsVertex(vertex))
                throw new InvalidOperationException("Vertex does not belong to the graph.");

            return Edges.Where(x => x.StartVertex.Equals(vertex)).ToList();
        }

        /// <summary>
        /// Returns list of all edges that contain particular vertex
        /// </summary>
        public List<IEdge<T>> EdgesContainVertex(IVertex<T> vertex)
        {
            if (!ContainsVertex(vertex))
                throw new InvalidOperationException("Vertex does not belong to the graph.");

            return Edges.Where(x => x.StartVertex.Equals(vertex) || x.EndVertex.Equals(vertex)).ToList();
        }

        /// <summary>
        /// Checks whenever there is a path between two vertices.
        /// Returns true if graph contains and edge such that start vertex and end vertex are parameters
        /// </summary>
        public bool AreAdjacent(IVertex<T> startVertex, IVertex<T> endVertex)
        {
            if (!ContainsVertex(startVertex) || !ContainsVertex(endVertex))
                throw new InvalidOperationException("One or more vertex does not belong to the graph.");

            return ContainsEdge(startVertex.Data, endVertex.Data);
        }

        /// <summary>
        /// Adds new vertex with specified data to the graph and gives pointer to it
        /// </summary>
        public IVertex<T> AddVertex(T data)
        {
            if (ContainsVertex(data))
                throw new InvalidOperationException("Vertex with same data is already in graph.");

            var vertex = new Vertex<T>(data, this);
            Vertices.Add(vertex);
            return vertex;
        }

        /// <summary>
        /// Creates a new unweighted edge between two vertices, if it does not exist
        /// </summary>
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

        /// <summary>
        /// Creates a new weighted edge between two vertices of graph, if is does not exist
        /// </summary>
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

        /// <summary>
        /// Removes vertex with specified data
        /// </summary>
        public void RemoveVertex(T data)
        {
            if (!ContainsVertex(data))
                throw new InvalidOperationException("There is no any vertex with such data.");

            var vertex = Vertices.First(x => x.Data.Equals(data));
            var connectedEdges = EdgesContainVertex(vertex);

            connectedEdges.ForEach(RemoveEdge);
            Vertices.Remove(vertex);
            vertex.CurrentGraph = null;
            vertex.Degree = 0;
        }

        /// <summary>
        /// Removes vertex from the graph by reference
        /// </summary>
        public void RemoveVertex(IVertex<T> vertex)
        {
            if (!ContainsVertex(vertex))
                throw new InvalidOperationException("Vertex does not belong to the graph.");

            var connectedEdges = EdgesContainVertex(vertex);

            connectedEdges.ForEach(RemoveEdge);
            Vertices.Remove(vertex);
            vertex.CurrentGraph = null;
            vertex.Degree = 0;
        }

        /// <summary>
        /// Removes an edge between two vertices, if such edge exists
        /// </summary>
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

        /// <summary>
        /// Removes an edge from graph, if such edge belongs to graph
        /// </summary>
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

        /// <summary>
        /// Checks whenever graph contains vertex with specified data 
        /// </summary>
        public bool ContainsVertex(T data) => Vertices.Any(x => x.Data.Equals(data));

        /// <summary>
        /// Checks whenever graph contains specified vertex
        /// </summary>
        public bool ContainsVertex(IVertex<T> vertex) => vertex.CurrentGraph == this;

        /// <summary>
        /// Checks whenever graph contains specified edge
        /// </summary>
        public bool ContainsEdge(IEdge<T> edge) => edge.CurrentGraph == this;

        /// <summary>
        /// Checks whenever graph contains an edge with specified start data and end data
        /// </summary>
        public bool ContainsEdge(T startData, T endData)
        {
            return Edges.Any(x => x.StartVertex.Data.Equals(startData)
                                  && x.EndVertex.Data.Equals(endData));
        }

        /// <summary>
        /// Indicates whenever current graph has Eulerian path.
        /// </summary>
        public bool HasEulerianPath()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Indicates whenever current graph has Eulerian circuit.
        /// </summary>
        public bool HasEulerianCircuit()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Resets all vertices of a graph to be unvisited
        /// </summary>
        public void Reset()
        {
            foreach (var vertex in Vertices)
                vertex.Reset();
        }
    }
}