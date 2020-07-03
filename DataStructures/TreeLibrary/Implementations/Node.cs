using System;
using System.Collections.Generic;
using TreeLibrary.Interfaces;

namespace TreeLibrary.Implementations
{
    public class Node : INode
    {
        public string Value { get; }
        public bool Visited { get; set; }
        public IList<INode> ChildrenNodes { get; }

        public Node(string value)
        {
            Value = value;
            Visited = false;
            ChildrenNodes = new List<INode>();
        }

        public void AddChild(INode node)
        {
            if (node.Equals(this))
            {
                throw new InvalidOperationException($"{this} cannot be child of itself");
            }
            
            switch (ChildrenNodes.Contains(node))
            {
                case false:
                    ChildrenNodes.Add(node);
                    break;
                default:
                    throw new InvalidOperationException($"{node} is already a child of {this}");
            }
        }

        public void AddChildRange(params INode[] nodeSet)
        {
            foreach (var node in nodeSet)
            {
                if (node.Equals(this))
                {
                    throw new InvalidOperationException($"{this} cannot be child of itself");
                }
            
                switch (ChildrenNodes.Contains(node))
                {
                    case false:
                        ChildrenNodes.Add(node);
                        break;
                    default:
                        throw new InvalidOperationException($"{node} is already a child of {this}");
                }
            }
        }

        public void RemoveChild(INode node)
        {
            switch (ChildrenNodes.Contains(node))
            {
                case true:
                    ChildrenNodes.Remove(node);
                    break;
                default:
                    throw new InvalidOperationException($"{node} is not a child of {this}");
            }
        }

        public void RemoveChildRange(params INode[] nodeSet)
        {
            foreach (var node in nodeSet)
            {
                switch (ChildrenNodes.Contains(node))
                {
                    case true:
                        ChildrenNodes.Remove(node);
                        break;
                    default:
                        throw new InvalidOperationException($"{node} is not a child of {this}");
                }
            }
        }

        public override string ToString()
        {
            return $"Node {Value}";
        }

        public bool Equals(INode other)
        {
            return Value == other?.Value && Visited == other?.Visited;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Node) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Visited, ChildrenNodes);
        }
    }
}