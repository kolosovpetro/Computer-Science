namespace LinkedListLibrary
{
    class Node<T> : INode<T>
    {
        public T Data { get; }

        public INode<T> Next { get; private set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }

        public void SetNext(INode<T> newNext)
        {
            Next = newNext;
        }
    }
}
