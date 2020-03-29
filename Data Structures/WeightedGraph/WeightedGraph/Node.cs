using System.Collections.Generic;
using WeightedGraphNodes.Interfaces;

namespace WeightedGraphNodes.WeightedGraph
{
    internal class Node<T> : INode<T>
    {
        public T Data { get; }

        public List<INode<T>> Next { get; }

        public Node(T data)
        {
            Data = data;
            Next = new List<INode<T>>();
        }

        public void AddNext(INode<T> next)
        {
            Next.Add(next);
        }
    }
}
