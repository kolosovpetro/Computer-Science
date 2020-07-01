namespace GraphLibrary.Interfaces
{
    public interface IEdge
    {
        INode First { get; }
        INode Last { get; }
        int Weight { get; }
    }
}