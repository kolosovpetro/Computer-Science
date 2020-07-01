using GraphLibrary.Interfaces;

namespace GraphLibrary.Implementations
{
    public class Edge : IEdge
    {
        public INode First { get; }
        public INode Last { get; }
        public int Weight { get; }

        public Edge(INode first, INode last)
        {
            First = first;
            first.Degree++;
            Last = last;
            last.Degree++;
        }

        public Edge(INode first, INode last, int weight)
        {
            First = first;
            first.Degree++;
            Last = last;
            last.Degree++;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{First} ---- {Weight} ---- {Last}";
        }
    }
}