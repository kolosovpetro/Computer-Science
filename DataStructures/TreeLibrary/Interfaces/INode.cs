using System;
using System.Collections.Generic;

namespace TreeLibrary.Interfaces
{
    public interface INode : IEquatable<INode>
    {
        string Value { get; }
        bool Visited { get; set; }
        IList<INode> ChildrenNodes { get; }
        void AddChild(INode node);
        void AddChildRange(params INode[] nodeSet);
        void RemoveChild(INode node);
        void RemoveChildRange(params INode[] nodeSet);
    }
}