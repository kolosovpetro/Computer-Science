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

        public Node Parent
        {
            get { return _parent; }
            set
            {
                if (_parent == value)
                    return;

                if(_parent == null)
                    NodeManager.Instance.RemoveRoot(this);

                if (_parent != null)
                    _parent._children.Remove(this);

                _parent = value;

                if(_parent != null)
                    _parent._children.Add(this);

                if (_parent == null)
                    NodeManager.Instance.AddRoot(this);
            }
        }
        public IList<Node> Children
        {
            get { return _roChildren; }
        }

        public Node()
        {
            _children = new List<Node>();
            _roChildren = new ReadOnlyCollection<Node>(_children);
        }
    }

    public class NodeManager
    {
        private static NodeManager _instance;

        private IList<Node> _roots;

        public static NodeManager Instance
        {
            get { return _instance ?? (_instance = new NodeManager()); }
        }

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
            var n0 = new Node();
            var n1 = new Node();
            var n2 = new Node();
            var n3 = new Node();
            var n4 = new Node();

            n1.Parent = n0;
            n2.Parent = n1;
            n3.Parent = n2;
            n4.Parent = n2;

            n2.Parent = null;
            n4.Parent = null;

            Console.WriteLine(NodeManager.Instance.Roots.Count + " roots.");
        }
    }
}
