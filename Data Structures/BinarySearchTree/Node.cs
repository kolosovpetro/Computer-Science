using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Node<T> : INodeable<T>
    {
        public T Key { get; }

        public int Value { get; }

        public INodeable<T> Left { get; }

        public INodeable<T> Right { get; }
    }
}
