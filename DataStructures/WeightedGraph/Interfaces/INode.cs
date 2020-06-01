using System.Collections.Generic;

namespace WeightedGraphNodes.Interfaces
{
    internal interface INode<T>
    {
        T Data { get; }
        List<INode<T>> Next { get; }
        void AddNext(INode<T> next);
    }
}
