using BinaryTree.Interfaces;

namespace BinaryTree.Implementations
{
    public class Node<T> : INode<T>
    {
        public T Data { get; }
        public INode<T> Left { get; set; }
        public INode<T> Right { get; set; }

        public Node(T data)
        {
            Data = data;
        }
    }
}