using GraphLibrary.Interfaces;

namespace GraphLibrary.Implementations
{
    public class Edge<T> : IEdge<T>
    {
        public IVertex<T> StartVertex { get; }
        public IVertex<T> EndVertex { get; }
        public int Weight { get; }
        
        public IGraph<T> CurrentGraph { get; }

        public Edge(IVertex<T> startVertex, IVertex<T> endVertex, int weight)
        {
            StartVertex = startVertex;
            EndVertex = endVertex;
            Weight = weight;
        }

        public Edge(IVertex<T> startVertex, IVertex<T> endVertex, int weight, IGraph<T> currentGraph)
        {
            StartVertex = startVertex;
            EndVertex = endVertex;
            Weight = weight;
            CurrentGraph = currentGraph;
        }

        public Edge(IVertex<T> startVertex, IVertex<T> endVertex)
        {
            StartVertex = startVertex;
            EndVertex = endVertex;
        }

        public Edge(IVertex<T> startVertex, IVertex<T> endVertex, IGraph<T> currentGraph)
        {
            StartVertex = startVertex;
            EndVertex = endVertex;
            CurrentGraph = currentGraph;
        }
    }
}