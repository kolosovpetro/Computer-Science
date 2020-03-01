using System.Collections;
using System.Collections.Generic;
using Stack.Exceptions;

namespace Stack
{
    class Stack<T> : IStack<T>, IEnumerable<T>
    {
        public int Count { get; private set; }
        public List<T> StackBase { get; private set; }
        public Stack(int newSize)
        {
            Count = newSize;
            this.StackBase = new List<T>();
        }
        public bool IsEmpty()
        {
            if (StackBase.Count == 0)
                return true;
            return false;
        }
        public bool IsFull()
        {
            if (StackBase.Count >= Count)
                return true;
            return false;
        }
        public void Push(T Data)
        {
            if (!IsFull())
                StackBase.Add(Data);
            else throw new StackIsFullException("Stack is full.");

        }
        public T Peek()
        {
            if (!IsEmpty())
            {
                int Last = StackBase.Count - 1;
                T Data = StackBase[Last];
                return Data;
            }

            else throw new StackIsEmptyException("Stack is empty.");
        }
        public void Pop()
        {
            if (!IsEmpty())
            {
                int Last = StackBase.Count - 1;
                StackBase.RemoveAt(Last);
            }

            else throw new StackIsEmptyException("Stack is empty.");
        }

        public void Clear()
        {
            StackBase.Clear();
        }

        public bool Contains(T Data)
        {
            if (StackBase.IndexOf(Data) != -1)
                return true;
            return false;
        }

        public void TrimExcess()
        {
            Count = StackBase.Count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return StackBase.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public T this[int index]
        {
            get
            {
                return StackBase[index];
            }

            private set
            {
                StackBase[index] = value;
            }
        }
    }
}
