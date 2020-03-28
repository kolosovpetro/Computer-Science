using System;
using System.Collections;
using System.Collections.Generic;
using Queue.Interfaces;

namespace Queue
{
    internal class Queue<T> : IQueue<T>, IEnumerable<T> where T : class
    {
        public int Capacity => QueueBase.Length;

        public int Count { get; private set; }

        public T[] QueueBase { get; private set; }

        public Queue(int newCapacity)
        {
            QueueBase = new T[newCapacity];
            Count = 0;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public bool IsFull()
        {
            return Count == Capacity;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new Exception("Queue is empty.");

            return QueueBase[0];
        }

        public void Enqueue(T data)
        {
            if (IsFull())
                throw new Exception("Queue is full.");

            QueueBase[Count] = data;
            Count++;
        }

        public void Dequeue()
        {
            if (IsEmpty())
                throw new Exception("Queue is empty.");

            var tempQueue = new T[Capacity];
            Array.Copy(QueueBase, 1, tempQueue, 0, Count - 1);
            QueueBase = tempQueue;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)QueueBase.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[int index]
        {
            get => QueueBase[index];
            set => QueueBase[index] = value;
        }
    }
}
