using System.Collections.Generic;
using WeightedGraphNodes.Interfaces;

namespace WeightedGraphNodes.WeightedGraph
{
    class Node<T> : INode<T>
    {
        public T Data { get; private set; }

        public List<INode<T>> Next { get; private set; }

        public Node(T newData)
        {
            Data = newData;
            Next = new List<INode<T>>();
        }

        public void AddNext(INode<T> newNext)
        {
            Next.Add(newNext);
        }
    }
}
