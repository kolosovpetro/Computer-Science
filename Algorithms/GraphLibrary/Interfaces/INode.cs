using System;

namespace GraphLibrary.Interfaces
{
    public interface INode : IEquatable<INode>
    {
        string Value { get; }
        bool IsVisited { get; }
        int Degree { get; set; }
        void Visit();
        void Reset();
    }
}