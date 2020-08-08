using DijkstraAlgorithm.Interfaces;

namespace DijkstraAlgorithm.Implementations
{
    public class Edge : IEdge
    {
        public INode StartVertex { get; }
        public INode EndVertex { get; }
        public int Weight { get; }

        public Edge(INode first, INode last, int weight)
        {
            StartVertex = first;
            EndVertex = last;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{StartVertex} ---- {Weight} ---- {EndVertex}";
        }
    }
}