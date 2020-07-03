using System.Collections.Generic;
using System.Linq;
using DoubleLinkedListLibrary.Interfaces;

namespace DoubleLinkedListLibrary.Implementations
{
    public class LinkedList<T> : ILinkedList<T>
    {
        public int Count { get; private set; }
        public INode<T> First { get; private set; }
        public INode<T> Last { get; private set; }

        public bool IsEmpty => Count == 0;

        public void AddAfter(INode<T> node, T data)
        {
            var findNode = Find(node.Value);

            switch (findNode == null)
            {
                case true:
                    return;
                default:
                    var next = findNode.Next;
                    var inserted = new Node<T>(data);
                    findNode.Next = inserted;
                    next.Previous = inserted;
                    inserted.Next = next;
                    inserted.Previous = findNode;
                    Count++;
                    break;
            }
        }

        public void AddBefore(INode<T> node, T data)
        {
            var before = Find(node.Value);

            switch (before == null)
            {
                case true:
                    return;
                default:
                    var previous = before.Previous;
                    var inserted = new Node<T>(data);
                    previous.Next = inserted;
                    inserted.Previous = previous;
                    inserted.Next = before;
                    before.Previous = inserted;
                    Count++;
                    break;
            }
        }

        public void AddFirst(T data)
        {
            switch (IsEmpty)
            {
                case true:
                    First = new Node<T>(data);
                    Last = First;
                    Count++;
                    break;
                default:
                    var next = First.Next;
                    First = new Node<T>(data);
                    First.Next = next;
                    break;
            }
        }

        public void AddLast(T data)
        {
            switch (Count == 1)
            {
                case true:
                    Last = new Node<T>(data);
                    First.Next = Last;
                    Last.Previous = First;
                    Count++;
                    break;
                default:
                    var previous = Last.Previous;
                    Last = new Node<T>(data);
                    Last.Previous = previous;
                    previous.Next = Last;
                    break;
            }
        }

        public void Clear()
        {
            while (Count > 0)
            {
                RemoveFirst();
            }
        }

        public bool Contains(T data)
        {
            var node = First;

            while (true)
            {
                if (node.Value.Equals(data))
                {
                    return true;
                }

                if (node.Next == null)
                {
                    break;
                }

                node = node.Next;
            }

            return false;
        }

        public void CopyTo(ref T[] array, int index)
        {
            var initial = First;
            var currentCount = 0;
            var list = new List<T>();

            while (initial != null)
            {
                if (currentCount >= index)
                {
                    list.Add(initial.Value);
                }

                initial = initial.Next;
                currentCount++;
            }

            array = list.ToArray();
        }

        public INode<T> Find(T data)
        {
            var currentNode = First;

            while (true)
            {
                if (currentNode.Value.Equals(data))
                {
                    return currentNode;
                }

                if (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                    continue;
                }

                break;
            }

            return null;
        }

        public INode<T> FindLast(T data)
        {
            var initial = First;
            var items = new List<INode<T>>();

            while (initial != null)
            {
                if (initial.Value.Equals(data))
                {
                    items.Add(initial);
                }

                initial = initial.Next;
            }

            return items.Last();
        }

        public void Remove(INode<T> node)
        {
            Remove(node.Value);
        }

        public void Remove(T data)
        {
            var item = Find(data);

            switch (item == null)
            {
                case true:
                    return;
                default:
                    var next = item.Next;
                    var previous = item.Previous;
                    previous.Next = next;
                    next.Previous = previous;
                    Count--;
                    break;
            }
        }

        public void RemoveLast()
        {
            Last = Last.Previous;
            Count--;

            if (Count == 0)
            {
                First = null;
            }
        }

        public void RemoveFirst()
        {
            First = First.Next;
            Count--;

            if (Count == 0)
            {
                Last = null;
            }
        }
    }
}