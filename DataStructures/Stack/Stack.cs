using System;
using System.Linq;
using Stack.Exceptions;
using Stack.Interfaces;

namespace Stack
{
    internal class Stack<T> : IStack<T>
    {
        public int Capacity { get; }

        public int Count { get; private set; }

        public T[] StackBase { get; private set; }

        public Stack(int capacity)
        {
            Capacity = capacity;
            Count = 0;
            StackBase = new T[capacity];
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public bool IsFull()
        {
            return Count == Capacity;
        }

        public void Push(T data)
        {
            if (IsFull())
                throw new StackIsFullException("Stack is full.");

            StackBase[Count] = data;
            Count++;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new StackIsEmptyException("Stack is empty");

            return StackBase[Count - 1];
        }

        public void Pop()
        {
            if (IsEmpty())
                throw new StackIsEmptyException("Stack is empty");

            StackBase[Count - 1] = default;
            Count--;
        }

        public void Clear()
        {
            StackBase = new T[Capacity];
            Count = 0;
        }

        public bool Contains(T data)
        {
            return StackBase.Contains(data);
        }

        public void TrimExcess()
        {
            throw new NotImplementedException();
        }

        public T this[int index]
        {
            get => StackBase[index];
            set => StackBase[index] = value;
        }
    }
}
