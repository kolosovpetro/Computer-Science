using System.Collections.Generic;

namespace WeightedGraphNodes.Interfaces
{
    interface INode<T>
    {
        T Data { get; }
        List<INode<T>> Next { get; }
        void AddNext(INode<T> newNext);
    }
}
