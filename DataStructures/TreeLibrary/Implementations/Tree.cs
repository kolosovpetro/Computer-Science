using System.Collections.Generic;
using System.Linq;
using TreeLibrary.Interfaces;

namespace TreeLibrary.Implementations
{
    public class Tree : ITree
    {
        private readonly INode _root;

        public Tree(INode root)
        {
            _root = root;
        }

        public INode Root()
        {
            return _root;
        }

        public int Count()
        {
            var children = _root.ChildrenNodes;
            var count = 0;

            while (children.Any())
            {
                var currentNodeChildren = new List<INode>();

                foreach (var child in children)
                {
                    currentNodeChildren.AddRange(child.ChildrenNodes);
                    count++;
                }
                
                children = currentNodeChildren;
            }

            return count + 1;
        }

        public bool IsEmpty()
        {
            return Count() == 0;
        }

        public INode Parent(INode child)
        {
            if (child.Equals(_root))
            {
                return null;
            }

            if (_root.ChildrenNodes.Contains(child))
            {
                return _root;
            }

            var nodes = _root.ChildrenNodes;

            while (nodes.Any())
            {
                var currentChildren = new List<INode>();

                foreach (var node in nodes)
                {
                    if (node.ChildrenNodes.Contains(child))
                    {
                        return node;
                    }

                    currentChildren.AddRange(node.ChildrenNodes);
                }

                nodes = currentChildren;
            }

            return null;
        }

        public IEnumerable<INode> Children(INode parent)
        {
            return parent.ChildrenNodes;
        }

        public bool IsInternal(INode node)
        {
            return node.ChildrenNodes.Count > 0;
        }

        public bool IsExternal(INode node)
        {
            return !IsInternal(node);
        }

        public int Depth(INode node)
        {
            if (node.Equals(_root))
            {
                return 0;
            }

            return 1 + Depth(Parent(node));
        }

        public int Height(INode node)
        {
            var children = node.ChildrenNodes;
            var heightList = new List<int>();

            while (children.Any())
            {
                var currentChildren = new List<INode>();
                foreach (var child in children)
                {
                    heightList.Add(Depth(child));
                    currentChildren.AddRange(child.ChildrenNodes);
                }

                children = currentChildren;
            }

            return heightList.Max();
        }
    }
}