using System;

namespace DijkstraAlgorithm.Interfaces
{
    public interface INode: IEquatable<INode>
    {
        string Value { get; }
        bool IsVisited { get; }
        void Visit();
    }
}