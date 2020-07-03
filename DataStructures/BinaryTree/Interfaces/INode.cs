namespace BinaryTree.Interfaces
{
    public interface INode<T>
    {
        T Data { get; }
        INode<T> Left { get; set; }
        INode<T> Right { get; set;  }
    }
}