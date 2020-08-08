namespace DijkstraAlgorithm.Interfaces
{
    public interface IEdge
    {
        INode StartVertex { get; }
        INode EndVertex { get; }
        int Weight { get; }
    }
}