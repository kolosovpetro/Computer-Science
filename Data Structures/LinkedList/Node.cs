using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Node<T>
    {
        public T Data { get; private set; }
        public Node<T> Next { get; private set; }
        public Node()
        {

        }
        public Node(Node<T> newNext, T newData)
        {
            this.Data = newData;
            this.Next = newNext;
        }
        public void SetData(T newData)
        {
            this.Data = newData;
        }
        public void SetNext(Node<T> Next)
        {
            this.Next = Next;
        }
    }
}
