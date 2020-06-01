namespace Stack.Interfaces
{
    internal interface IStack<T>
    {
        int Capacity { get; }
        int Count { get; }
        bool IsEmpty();
        bool IsFull();
        void Push(T data);
        T Peek();
        void Pop();
        void Clear();
        bool Contains(T data);
        void TrimExcess();
    }
}
