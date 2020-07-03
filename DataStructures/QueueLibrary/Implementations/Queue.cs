using System;
using System.Collections.Generic;
using System.Linq;
using QueueLibrary.Interfaces;

namespace QueueLibrary.Implementations
{
    public class Queue<T> : IQueue<T>
    {
        private readonly List<T> _queueBase;
        public int Count => _queueBase.Count;
        public int Capacity { get; }

        public Queue(int capacity)
        {
            Capacity = capacity;
            _queueBase = new List<T>(capacity);
        }

        public T Peek()
        {
            return IsEmpty() switch
            {
                false => _queueBase.First(),
                _ => throw new InvalidOperationException("Queue is empty")
            };
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public bool IsFull()
        {
            return Count >= Capacity;
        }

        public void Clear()
        {
            _queueBase.Clear();
        }

        public bool Contains(T data)
        {
            return _queueBase.Contains(data);
        }

        public void CopyTo(ref T[] array, int startIndex)
        {
            array = _queueBase.Skip(startIndex).ToArray();
        }

        public T Dequeue()
        {
            switch (IsEmpty())
            {
                case false:
                    var first = _queueBase.First();
                    _queueBase.Remove(first);
                    return first;
                default:
                    throw new InvalidOperationException("Queue is empty");
            }
        }

        public void Enqueue(T data)
        {
            switch (IsFull())
            {
                case false:
                    _queueBase.Add(data);
                    break;
                default:
                    throw new InvalidOperationException("Queue is full");
            }
        }

        public T[] ToArray()
        {
            return _queueBase.ToArray();
        }
    }
}