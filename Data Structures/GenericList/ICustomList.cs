namespace GenericList
{
    internal interface ICustomList<T>
    {
        int Count { get; }
        void Add(T data);
        T ElementAt(int index);
        void RemoveAtIndex(int index);
        void Clear();
        int IndexOf(T data);
        bool Contains(T data);
    }
}
