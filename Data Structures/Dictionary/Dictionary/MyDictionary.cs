using System.Collections;
using System.Collections.Generic;
using Dictionary.Interfaces;

namespace Dictionary
{
    class MyDictionary<TKey, TValue> : IMyDictionary<TKey, TValue>, IEnumerable<Node<TKey, TValue>>
    {
        public List<Node<TKey, TValue>> DictBase { get; private set; }
        public int Count { get; private set; }

        public MyDictionary()
        {
            DictBase = new List<Node<TKey, TValue>>();
        }

        public void Add(TKey newKey, TValue newValue)
        {
            Node<TKey, TValue> NewNode = new Node<TKey, TValue>(newKey, newValue);
            DictBase.Add(NewNode);
            Count++;
        }

        public void Remove(TKey Key, TValue Value)
        {
            if (Contains(Key, Value, out int Index))
            {
                DictBase.RemoveAt(Index);
            }
        }

        public void RemoveAt(int Index)
        {
            if (Index < Count)
                DictBase.RemoveAt(Index);
            else
                return;
        }

        public bool Contains(TKey newKey, TValue newValue)
        {
            foreach (var Node in DictBase)
            {
                if (Node.Key.Equals(newKey) && Node.Value.Equals(newValue))
                    return true;
            }

            return false;
        }
        public bool Contains(TKey newKey, TValue newValue, out int Index)
        {
            Index = -1;
            for (int i = 0; i < Count; i++)
            {
                if (Contains(newKey, newValue))
                {
                    Index = i;
                    return true;
                }
            }

            return false;
        }

        public Node<TKey, TValue> ElementAt(int Index)
        {
            if (Index < Count)
            {
                return DictBase[Index];
            }

            return default;
        }

        public bool IsEmpty()
        {
            if (Count == 0)
                return true;
            return false;
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
            get
            {
                return DictBase[index];
            }
        }
    }
}
