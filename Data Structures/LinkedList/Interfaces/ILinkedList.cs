using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Interfaces
{
    interface ILinkedList<T>
    {
        void AddFirst(T Data);
        void AddLast(T Data);
        void RemoveFirst();
        void RemoveLast();
        Node<T> Search(T Data);
    }
}
