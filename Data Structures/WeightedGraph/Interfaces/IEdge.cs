namespace WeightedGraphNodes.Interfaces
{
    interface IEdge<T>
    {
        INode<T> Parent { get; }
        INode<T> Child { get; }
        double Weight { get; }
    }
}
