namespace LinkedListLibrary
{
    interface INode<T>
    {
        T Data { get; }
        INode<T> Next { get; }

        void SetNext(INode<T> newNext);
    }
}
