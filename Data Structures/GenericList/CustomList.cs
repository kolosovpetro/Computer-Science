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
            Count = listBase.Length;
        }

        public CustomList(int size)
        {
            listBase = new T[size];
            Capacity = size;
        }

        public void Add(T data)
        {
            if(Count == 0)
            {
                Count++;
                listBase = new T[Count];
                listBase[Count - 1] = data;
                return;
            }

            Count++;
            T[] temp = new T[Count];
            listBase.CopyTo(temp, 0);
            listBase = temp;
            listBase[Count--] = data;
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

        public T ElementAt(int index)
        {
            return listBase[index];
        }
    }
}
