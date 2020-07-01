using DijkstraAlgorithm.Interfaces;

namespace DijkstraAlgorithm.Implementations
{
    public class Edge : IEdge
    {
        public INode First { get; }
        public INode Last { get; }
        public int Weight { get; }

        public Edge(INode first, INode last, int weight)
        {
            First = first;
            Last = last;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{First} ---- {Weight} ---- {Last}";
        }
    }
}