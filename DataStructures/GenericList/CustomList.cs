using System;

namespace GenericList
{
    internal class CustomList<T> : ICustomList<T>
    {
        private T[] _listBase;
        public int Count { get; private set; }
        public int Capacity { get; }

        public CustomList()
        {
            Count = 0;
        }

        public CustomList(params T[] listBase)
        {
            _listBase = listBase;
            Count = listBase.Length;
        }

        public CustomList(int size)
        {
            _listBase = new T[size];
            Capacity = size;
        }

        public void Add(T data)
        {
            if (Count == 0)
            {
                Count++;
                _listBase = new T[Count];
                _listBase[Count - 1] = data;
                return;
            }

            Count++;
            T[] temp = new T[Count];
            _listBase.CopyTo(temp, 0);
            _listBase = new T[temp.Length];
            temp.CopyTo(_listBase, 0);
            _listBase[Count - 1] = data;
        }

        public void Clear()
        {
            Count = 0;
            _listBase = null;
        }

        public int IndexOf(T data)
        {
            Contains(data, out int index);
            return index;
        }

        public void RemoveAtIndex(int index)
        {
            throw new NotImplementedException();
        }

        public T ElementAt(int index)
        {
            return _listBase[index];
        }

        public bool Contains(T data)
        {
            for (int i = 0; i < _listBase.Length; i++)
            {
                if (_listBase[i].Equals(data))
                {
                    return true;
                }
            }

            return false;
        }
        
        private bool Contains(T data, out int index)
        {
            for (int i = 0; i < _listBase.Length; i++)
            {
                if (_listBase[i].Equals(data))
                {
                    index = i;
                    return true;
                }
            }

            index = -1;
            return false;
        }
    }
}
