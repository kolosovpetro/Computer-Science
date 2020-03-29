using WeightedGraphNodes.Interfaces;

namespace WeightedGraphNodes.WeightedGraph
{
    internal class Edge<T> : IEdge<T>
    {
        public INode<T> Parent { get; }

        public INode<T> Child { get; }

        public double Weight { get; }

        public Edge(INode<T> parent, INode<T> child, double weight)
        {
            Parent = parent;
            Child = child;
            Parent.AddNext(Child);
            Weight = weight;
        }
    }
}
