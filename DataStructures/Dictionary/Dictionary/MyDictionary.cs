using System.Collections;
using System.Collections.Generic;
using Dictionary.Interfaces;

namespace Dictionary.Dictionary
{
    internal class MyDictionary<TKey, TValue> : IMyDictionary<TKey, TValue>,
        IEnumerable<Node<TKey, TValue>>
    {
        public List<Node<TKey, TValue>> DictBase { get; }
        public int Count { get; private set; }

        public MyDictionary()
        {
            DictBase = new List<Node<TKey, TValue>>();
            Count = 0;
        }

        public void Add(TKey newKey, TValue newValue)
        {
            var newNode = new Node<TKey, TValue>(newKey, newValue);
            DictBase.Add(newNode);
            Count++;
        }

        public void Remove(TKey key, TValue value)
        {
            if (Contains(key, value, out int index))
            {
                DictBase.RemoveAt(index);
            }
        }

        public void RemoveAt(int index)
        {
            if (index < Count)
                DictBase.RemoveAt(index);
        }

        public bool Contains(TKey key, TValue value)
        {
            foreach (var node in DictBase)
            {
                if (node.Key.Equals(key) && node.Value.Equals(value))
                    return true;
            }

            return false;
        }

        public bool Contains(TKey key, TValue value, out int index)
        {
            index = -1;

            for (int i = 0; i < Count; i++)
            {
                if (!Contains(key, value)) continue;

                index = i;
                return true;
            }

            return false;
        }

        public Node<TKey, TValue> ElementAt(int index)
        {
            return index < Count ? DictBase[index] : default;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public IEnumerator<Node<TKey, TValue>> GetEnumerator()
        {
            return DictBase.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Node<TKey, TValue> this[int index]
        {
            get => DictBase[index];
            set => DictBase[index] = value;
        }
    }
}
