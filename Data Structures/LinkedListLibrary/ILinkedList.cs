namespace LinkedListLibrary
{
    interface ILinkedList<T>
    {
        INode<T> First { get; }
        INode<T> Last { get; }
        int Count { get; }
        void AddFirst(T newFirstData);
        void AddLast(T newLastData);
        void RemoveFirst();
        void RemoveLast();
        INode<T> SearchNode(T nodeData);
        void DeleteNode(INode<T> node);
        void AddAfter(T data, INode<T> newNode);
        bool Contains(T data);
    }
}
