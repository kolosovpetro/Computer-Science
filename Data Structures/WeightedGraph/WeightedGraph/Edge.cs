using WeightedGraphNodes.Interfaces;

namespace WeightedGraphNodes.WeightedGraph
{
    class Edge<T> : IEdge<T>
    {
        public INode<T> Parent { get; private set; }

        public INode<T> Child { get; private set; }

        public double Weight { get; private set; }

        public Edge(INode<T> newParent, INode<T> newChild, double newWeight)
        {
            Parent = newParent;
            Child = newChild;
            Parent.AddNext(Child);
            Weight = newWeight;
        }
    }
}
