using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class BinarySearchTree<T> : IBSTable<T>
    {
        private List<INodeable<T>> Nodes { get; set; }

        public INodeable<T> Root
        {
            get
            {
                return Nodes.ElementAt(0);
            }
        }

        public BinarySearchTree()
        {
            Nodes = new List<INodeable<T>>();
        }

        public int Count
        {
            get
            {
                return Nodes.Count();
            }
        }

        public INodeable<T> Search(T key)
        {
            throw new NotImplementedException();
        }

        public void Insert(INodeable<T> newNode)
        {
            throw new NotImplementedException();
        }

        public void Delete(INodeable<T> node)
        {
            throw new NotImplementedException();
        }

        public string PrintOrdered()
        {
            throw new NotImplementedException();
        }

        public INodeable<T> Max()
        {
            throw new NotImplementedException();
        }

        public INodeable<T> Min()
        {
            throw new NotImplementedException();
        }

        public INodeable<T> Successor(INodeable<T> node)
        {
            throw new NotImplementedException();
        }

        public INodeable<T> Predecessor(INodeable<T> node)
        {
            throw new NotImplementedException();
        }
    }
}
