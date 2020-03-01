using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedList.Interfaces;

namespace LinkedList
{
    class LinkedList<T> : ILinkedList<T>
    {
        public Node<T> First { get; private set; }
        public Node<T> Last { get; private set; }
        public int Count { get; private set; }
        public LinkedList()
        {
            First = new Node<T>();
            Last = new Node<T>();
        }
        public void AddFirst(T Data)
        {
            Node<T> newNode = new Node<T>(First, Data);
            newNode.SetNext(First);
            First = newNode;
            Count++;
        }

        public void AddLast(T Data)
        {
            Node<T> newNode = new Node<T>(null, Data);
            Last.SetNext(newNode);
            Last = newNode;
            Count++;
        }

        public void RemoveFirst()
        {
            if (First != null)
                return;
            First = First.Next;
            Count--;
        }

        public void RemoveLast()
        {
            if (First != null)
                return;

            Node<T> SecondToLast = First;

            while (SecondToLast.Next != Last)
                SecondToLast = SecondToLast.Next;

            SecondToLast.SetNext(null);
            Last = SecondToLast;
            Count--;
        }

        public Node<T> Search(T Data)
        {
            Node<T> Current = First;

            while (Count > 0)
            {
                if (Current.Data.Equals(Data))
                {
                    break;
                }

                Current = Current.Next;
            }

            return Current;
        }
    }
}
