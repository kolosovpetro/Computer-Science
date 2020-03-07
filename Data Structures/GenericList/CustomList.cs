using System;

namespace GenericList
{
    class CustomList<T> : ICustomList<T>
    {
        private T[] listBase;
        public int Count { get; private set; }
        public int Capacity { get; private set; }

        public CustomList()
        {
            Count = 0;
        }

        public CustomList(params T[] listBase)
        {
            this.listBase = listBase;
        }

        public CustomList(int size)
        {
            listBase = new T[size];
            Capacity = size;
        }

        public void Add(T data)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T data)
        {
            throw new NotImplementedException();
        }

        public void RemoveAtIndex(int index)
        {
            throw new NotImplementedException();
        }
    }
}
