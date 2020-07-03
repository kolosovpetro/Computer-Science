using System;
using System.Collections.Generic;
using System.Linq;
using StackLibrary.Interfaces;

namespace StackLibrary.Implementation
{
    public class Stack<T> : IStack<T>
    {
        public int Capacity { get; }
        public int Count => _stackBase.Count;

        private List<T> _stackBase;

        public Stack(int capacity)
        {
            Capacity = capacity;
            _stackBase = new List<T>(capacity);
        }

        public T Peek()
        {
            return IsEmpty() switch
            {
                false => _stackBase.Last(),
                _ => throw new InvalidOperationException("Stack is empty")
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
            _stackBase = new List<T>();
        }

        public bool Contains(T data)
        {
            return _stackBase.Contains(data);
        }

        public void CopyTo(ref T[] array, int index)
        {
            array = _stackBase.Skip(index).ToArray();
        }

        public T Pop()
        {
            switch (IsEmpty())
            {
                case true:
                    throw new InvalidOperationException("Stack is empty");
                default:
                    var last = _stackBase.Last();
                    _stackBase.Remove(last);
                    return last;
            }
        }

        public void Push(T data)
        {
            switch (IsFull())
            {
                case true:
                    throw new InvalidOperationException("Stack is full");
                default:
                    _stackBase.Add(data);
                    break;
            }
        }

        public T[] ToArray()
        {
            return _stackBase.ToArray();
        }
    }
}