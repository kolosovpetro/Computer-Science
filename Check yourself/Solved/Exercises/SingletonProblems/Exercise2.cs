// TODO: Use injection instead of singleton pattern.

namespace Exercises.SingletonProblems
{
    using System.Collections.ObjectModel;
    using System;
    using System.Collections.Generic;

    public class Node
    {
        private Node _parent;
        private readonly IList<Node> _children;
        private readonly IList<Node> _roChildren;
        private readonly NodeManager nodereader;

        public Node()
        {
            _children = new List<Node>();
            _roChildren = new List<Node>();
            nodereader = new NodeManager();
        }

        public Node Parent
        {
            get { return _parent; }
            set
            {
                if (_parent == value)
                    return;

                if (_parent == null)
                    nodereader.RemoveRoot(this);

                if (_parent != null)
                    _parent._children.Remove(this);

                _parent = value;

                if (_parent != null)
                    _parent._children.Add(this);

                if (_parent == null)
                    nodereader.AddRoot(this);
            }
        }
        public IList<Node> Children
        {
            get { return _roChildren; }
        }
    }

    public sealed class NodeManager
    {
        private IList<Node> _roots;

        public IList<Node> Roots { get; private set; }

        public NodeManager()
        {
            _roots = new List<Node>();
            Roots = new ReadOnlyCollection<Node>(_roots);
        }

        public void AddRoot(Node node)
        {
            if (_roots.Contains(node))
                throw new ArgumentException("node");

            _roots.Add(node);
        }
        public void RemoveRoot(Node node)
        {
            if (!_roots.Contains(node))
                throw new ArgumentException("node");

            _roots.Remove(node);
        }
    }

    public class E2
    {
        public static void Init()
        {
            Node n0 = new Node();
            Node n1 = new Node();
            Node n2 = new Node();
            Node n3 = new Node();
            Node n4 = new Node();

            n1.Parent = n0;
            n2.Parent = n1;
            n3.Parent = n2;
            n4.Parent = n2;

            n2.Parent = null;
            n4.Parent = null;

            NodeManager nm = new NodeManager();
            nm.AddRoot(n0);
            nm.AddRoot(n1);
            nm.AddRoot(n2);
            nm.AddRoot(n3);
            nm.AddRoot(n4);


            Console.WriteLine(nm.Roots.Count + " roots.");
        }
    }
}
