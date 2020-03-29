using System.Collections.Generic;
using Trees.Auxiliaries;
using Trees.Interfaces;

namespace Trees.Trees
{
    internal class Tree<T> : ITree<T>
    {
        public List<Node<T>> TreeBase { get; protected set; }
        public Iterator<T> Iterator { get; }
        public int Size { get; protected set; }

        // initialization of empty Tree with given structure
        // it can be filled after initialization of an object

        public Tree(params int[] treeParents)
        {
            Size = treeParents.Length;
            TreeBase = new List<Node<T>>();

            for (int i = 0; i < Size; i++)
                TreeBase.Add(new Node<T>());

            for (int j = 0; j < Size; j++)
            {
                int parentIndex = treeParents[j];

                TreeBase[j].SetParentIndex(parentIndex);
            }

            Iterator = new Iterator<T>(this);
        }

        // initialization of Data Filled Tree with given structure

        public Tree(T[] treeData, int[] treeParents)
        {
            Size = treeParents.Length;
            TreeBase = new List<Node<T>>();

            for (int i = 0; i < Size; i++)
                TreeBase.Add(new Node<T>());

            for (int j = 0; j < Size; j++)
            {
                T data = treeData[j];
                int parentIndex = treeParents[j];

                TreeBase[j].SetData(data);
                TreeBase[j].SetParentIndex(parentIndex);
            }

            Iterator = new Iterator<T>(this);
        }

        public T Root()
        {
            return TreeBase[0].Data;
        }

        public bool IsEmpty()
        {
            return Size < 0;
        }

        public T ParentOf(T Child)
        {
            if (Iterator.TreeConsist(Child, out Node<T> nodeOfChild))
            {
                int parentIndex = nodeOfChild.ParentIndex;
                return TreeBase[parentIndex].Data;
            }

            return default;
        }

        public List<T> Children(T FatherData)
        {
            List<T> childrenList = new List<T>();

            if (IsInternal(FatherData) && Iterator.TreeConsist(FatherData, out Node<T> parent))
            {
                int parentIndex = TreeBase.IndexOf(parent);

                foreach (var node in TreeBase)
                {
                    if (node.ParentIndex == parentIndex)
                    {
                        childrenList.Add(node.Data);
                    }
                }
            }

            return childrenList;
        }

        public void SetData(int NodeIndex, T Data)
        {
            TreeBase[NodeIndex].SetData(Data);
        }

        public T GetNodeByIndex(int NodeIndex)
        {
            return TreeBase[NodeIndex].Data;
        }

        public bool IsInternal(T NodeData)
        {
            return !IsExternal(NodeData);
        }

        public bool IsExternal(T NodeData)
        {
            if (Iterator.TreeConsist(NodeData, out Node<T> newNode))
            {
                int indexOfNode = TreeBase.IndexOf(newNode);

                foreach (Node<T> node in TreeBase)
                {
                    if (node.ParentIndex == indexOfNode)
                        return false;
                }
            }

            return true;
        }
    }
}
