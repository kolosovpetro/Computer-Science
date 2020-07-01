using System;
using GraphLibrary.Interfaces;

namespace GraphLibrary.Implementations
{
    public class Node : INode
    {
        public string Value { get; }
        public bool IsVisited { get; private set; }
        public int Degree { get; set; }

        public Node(string value)
        {
            Value = value;
            IsVisited = false;
        }
        
        public void Visit()
        {
            IsVisited = true;
        }

        public void Reset()
        {
            IsVisited = false;
        }

        public override string ToString()
        {
            return $"Node {Value}";
        }

        public bool Equals(INode other)
        {
            return other != null && Value == other.Value && IsVisited == other.IsVisited;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Node) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, IsVisited);
        }
    }
}