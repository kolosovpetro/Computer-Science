using System;

namespace LinkedListLibrary
{
    class LinkedList<T> : ILinkedList<T>
    {
        public INode<T> First { get; private set; }

        public INode<T> Last { get; private set; }

        public int Count { get; private set; }

        public LinkedList()
        {
            First = null;
            Last = null;
        }

        public void AddAfter(T data, INode<T> newNode)
        {
            INode<T> current = SearchNode(data);
            INode<T> nextToCurrent = current.Next;
            current.SetNext(newNode);
            newNode.SetNext(nextToCurrent);
            Count++;
        }

        public void AddFirst(T newFirstData)
        {
            Node<T> newNode = new Node<T>(newFirstData);
            newNode.SetNext(newNode);
            First = newNode;
            AddLast(newNode.Data);
            Count++;
        }

        public void AddLast(T newLastData)
        {
            Node<T> newNode = new Node<T>(newLastData);
            Last = newNode;
            Count++;
        }

        public void DeleteNode(INode<T> node)
        {
            throw new NotImplementedException();
        }

        public void RemoveFirst()
        {
            First = First.Next;
        }

        public void RemoveLast()
        {
            throw new NotImplementedException();
        }

        public INode<T> SearchNode(T nodeData)
        {
            INode<T> s = First;

            while (true)
            {
                if (s.Data.Equals(nodeData))
                {
                    return s;
                }

                if (s.Next.Equals(null))
                {
                    break;
                }

                else
                {
                    s = s.Next;
                }
            }

            throw new NodeNotFoundException("There is no such node in current linked list.");
        }
    }
}
