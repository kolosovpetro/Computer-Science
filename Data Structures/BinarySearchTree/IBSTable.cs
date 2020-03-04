using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    interface IBSTable<T>
    {
        INodeable<T> Root { get; }
        int Count { get; }
        INodeable<T> Search(T key);
        void Insert(INodeable<T> newNode);
        void Delete(INodeable<T> node);
        string PrintOrdered();
        INodeable<T> Max();
        INodeable<T> Min();
        INodeable<T> Successor(INodeable<T> node);
        INodeable<T> Predecessor(INodeable<T> node);
    }
}
