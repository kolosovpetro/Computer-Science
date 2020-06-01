using System.Linq;
using Trees.Interfaces;
using Trees.Exceptions;

namespace Trees.Trees
{
    internal class BinaryTree<T> : Tree<T>, IBinaryTree<T>
    {
        public BinaryTree(T[] TreeData, int[] TreeParents) : base(TreeData, TreeParents)
        {
            var groups = TreeParents.GroupBy(p => p);

            foreach (var item in groups)
            {
                if (item.Count() > 2 && item.Key != 0)
                {
                    throw new BinaryTreeInitializationException("Each node has to have most 2 children.");
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
            T leftChild;

            if (IsRoot(FatherData))
            {
                leftChild = HasLeft(FatherData) ? Children(FatherData)[1] : default;
            }

            else
            {
                leftChild = HasLeft(FatherData) ? Children(FatherData)[0] : default;
            }

            return leftChild;
        }

        public T RightChildOf(T FatherData)
        {
            T rightChild;

            if (IsRoot(FatherData))
            {
                rightChild = HasRight(FatherData) ? Children(FatherData)[2] : default;
            }

            else
            {
                rightChild = HasRight(FatherData) ? Children(FatherData)[1] : default;
            }

            return rightChild;
        }

        public bool IsRoot(T NodeData)
        {
            return TreeBase[0].Equals(NodeData);
        }
    }
}
