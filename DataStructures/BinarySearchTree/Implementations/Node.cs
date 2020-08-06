using System;
using BinarySearchTree.Interfaces;

namespace BinarySearchTree.Implementations
{
    public class Node : INode
    {
        public int Key { get; set; }
        public INode Parent { get; set; }
        public INode Left { get; set; }
        public INode Right { get; set; }
        public int Count { get; private set; }
        public INode Root { get; set; }

        public Node(int key)
        {
            Key = key;
            Root = this;
        }

        public INode Search(int key)
        {
            var currentNode = Root;

            while (currentNode != null && currentNode.Key != key)
            {
                currentNode = key < currentNode.Key ? currentNode.Left : currentNode.Right;
            }

            return currentNode;
        }

        public INode Insert(int key)
        {
            INode currentParent = null;
            var currentNode = Root;

            while (currentNode != null)
            {
                currentParent = currentNode;
                currentNode = key <= currentNode.Key ? currentNode.Left : currentNode.Right;
            }

            currentNode = new Node(key) {Parent = currentParent};

            if (currentParent == null)
            {
                Root = currentNode;
            }
            else if (key <= currentParent.Key)
            {
                currentParent.Left = currentNode;
            }
            else
            {
                currentParent.Right = currentNode;
            }

            Count++;
            return currentNode;
        }

        public INode Delete(INode node)
        {
            if (node.Left == null)
            {
                return Transplant(node, node.Right);
            }
            if (node.Right == null)
            {
                return Transplant(node, node.Right);
            }

            var successor = Min(node.Right);

            if (successor.Parent != node)
            {
                Transplant(successor, successor.Right);
                successor.Right = node.Right;
                successor.Right.Parent = successor;
            }

            Transplant(node, successor);
            successor.Left = node.Left;
            successor.Left.Parent = successor;
            Count--;
            return successor;
        }

        public INode Max()
        {
            var node = Root;
            while (node.Right != null)
            {
                node = node.Right;
            }

            return node;
        }

        public INode Min()
        {
            var node = Root;
            while (node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }

        public INode Min(INode node)
        {
            var currentNode = node;
            while (currentNode.Left != null)
            {
                currentNode = currentNode.Left;
            }

            return currentNode;
        }

        public INode Successor(INode node)
        {
            if (node.Right != null)
            {
                return Min(node.Right);
            }

            var currentParent = node.Parent;

            while (currentParent != null && node == currentParent.Right)
            {
                node = currentParent;
                currentParent = currentParent.Parent;
            }

            return currentParent;
        }

        private static void InOrder(INode node)
        {
            if (node == null) return;
            InOrder(node.Left);
            Console.Write($"{node.Key} ");
            InOrder(node.Right);
        }

        public void PrintSorted()
        {
            InOrder(Root);
        }

        private INode Transplant(INode originalNode, INode replacementNode)
        {
            if (originalNode.Parent == null)
            {
                Root = replacementNode;
            }

            else if (originalNode == originalNode.Parent.Left)
            {
                originalNode.Parent.Left = replacementNode;
            }
            else
            {
                originalNode.Parent.Right = replacementNode;
            }

            if (replacementNode != null)
            {
                replacementNode.Parent = originalNode.Parent;
            }

            return replacementNode;
        }
    }
}