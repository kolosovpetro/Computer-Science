using Dictionary.Dictionary;

namespace Dictionary.Interfaces
{
    internal interface IMyDictionary<TKey, TValue>
    {
        void Add(TKey key, TValue value);
        void Remove(TKey key, TValue value);
        void RemoveAt(int index);
        bool Contains(TKey key, TValue value);
        Node<TKey, TValue> ElementAt(int index);
        bool IsEmpty();
    }
}
