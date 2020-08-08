using System.Collections.Generic;
using DijkstraAlgorithm.Interfaces;

namespace DijkstraAlgorithm.Implementations
{
    public class Graph : IGraph
    {
        public IEnumerable<IEdge> Edges { get; }
        public Graph(params IEdge[] edges)
        {
            Edges = edges;
        }
    }
}