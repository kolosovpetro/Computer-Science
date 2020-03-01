namespace Stack
{
    interface IStack<T>
    {
        bool IsEmpty();
        bool IsFull();
        void Push(T Data);
        T Peek();
        void Pop();
        void Clear();
        bool Contains(T Data);
        void TrimExcess();
    }
}
