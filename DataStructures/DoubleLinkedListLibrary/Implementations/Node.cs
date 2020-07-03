using DoubleLinkedListLibrary.Interfaces;

namespace DoubleLinkedListLibrary.Implementations
{
    public class Node<T> : INode<T>
    {
        public ILinkedList<T> List { get; set; }
        public INode<T> Next { get; set; }
        public INode<T> Previous { get; set; }
        public T Value { get; }

        public Node(T value)
        {
            Value = value;
        }
    }
}