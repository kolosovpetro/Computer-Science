namespace GenericList
{
    interface ICustomList<T>
    {
        int Count { get; }
        void Add(T data);
        void RemoveAtIndex(int index);
        void Clear();
        int IndexOf(T data);
    }
}
