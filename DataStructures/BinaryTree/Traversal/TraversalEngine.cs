using System;
using System.Collections.Generic;
using System.Linq;
using BinaryTree.Interfaces;

namespace BinaryTree.Traversal
{
    public class TraversalEngine<T>
    {
        public void InOrderTraversal(INode<T> node)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left);
                Console.Write(node.Data + " ");
                InOrderTraversal(node.Right);
            }
        }

        public void PreOrderTraversal(INode<T> node)
        {
            if (node != null)
            {
                Console.Write(node.Data + " ");
                PreOrderTraversal(node.Left);
                PreOrderTraversal(node.Right);
            }
        }

        public void PostOrderTraversal(INode<T> node)
        {
            if (node != null)
            {
                PostOrderTraversal(node.Left);
                PostOrderTraversal(node.Right);
                Console.Write(node.Data + " ");
            }
        }

        public void LevelOrderTraversal(INode<T> node)
        {
            if (node == null)
                return;

            var queue = new Queue<INode<T>>();

            queue.Enqueue(node);

            while (queue.Any())
            {
                var currentNode = queue.Dequeue();

                Console.WriteLine(currentNode.Data + " ");

                if (currentNode.Left != null)
                {
                    queue.Enqueue(currentNode.Left);
                }

                if (currentNode.Right != null)
                {
                    queue.Enqueue(currentNode.Right);
                }
            }
        }
    }
}