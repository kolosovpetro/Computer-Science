namespace Dictionary.Interfaces
{
    interface IMyDictionary<TKey, TValue>
    {
        void Add(TKey Key, TValue Value);
        void Remove(TKey Key, TValue Value);
        void RemoveAt(int Index);
        bool Contains(TKey Key, TValue Value);
        Node<TKey, TValue> ElementAt(int Index);
        bool IsEmpty();
    }
}
