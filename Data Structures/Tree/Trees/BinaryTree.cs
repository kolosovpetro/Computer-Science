using System;
using System.Collections.Generic;
using System.Linq;
using Trees.Interfaces;
using Trees.Exceptions;

namespace Trees.Trees
{
    class BinaryTree<T> : Tree<T>, IBinaryTree<T>
    {
        public BinaryTree(params int[] TreeParents) : base(TreeParents)
        {
            var Groups = TreeParents.GroupBy(p => p);
            foreach (var item in Groups)
            {
                if (item.Count() > 2 && item.Key != 0)
                {
                    throw new BinaryTreeCreationException("Each node has to have atmost 2 children.");
                }
            }
        }

        public BinaryTree(T[] TreeData, int[] TreeParents) : base(TreeData, TreeParents)
        {
            var Groups = TreeParents.GroupBy(p => p);
            foreach (var item in Groups)
            {
                if (item.Count() > 2 && item.Key != 0)
                {
                    throw new BinaryTreeCreationException("Each node has to have atmost 2 children.");
                }
            }
        }
        public bool HasLeft(T FatherData)
        {
            return Children(FatherData).Count > 0;
        }

        public bool HasRight(T FatherData)
        {
            return Children(FatherData).Count > 1;
        }

        public T LeftChildOf(T FatherData)
        {
            T LeftChild;

            if (IsRoot(FatherData))
            {
                LeftChild = HasLeft(FatherData) ? Children(FatherData)[1] : default;
            }

            else
            {
                LeftChild = HasLeft(FatherData) ? Children(FatherData)[0] : default;
            }

            return LeftChild;
        }

        public T RightChildOf(T FatherData)
        {
            T RightChild;

            if (IsRoot(FatherData))
            {
                RightChild = HasRight(FatherData) ? Children(FatherData)[2] : default;
            }

            else
            {
                RightChild = HasRight(FatherData) ? Children(FatherData)[1] : default;
            }

            return RightChild;
        }

        public bool IsRoot(T NodeData)
        {
            return TreeBase[0].Equals(NodeData);
        }
    }
}
