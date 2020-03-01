using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees.Auxiliaries;

namespace Trees
{
    class Tree<T> : ITree<T>
    {
        public List<Node<T>> TreeBase { get; protected set; }
        public Iterator<T> Iterator { get; private set; }
        public int Size { get; protected set; }

        // initialization of Dataless Tree with given structure
        // it can be filled after initialization of an object
        public Tree(params int[] TreeParents)
        {
            Size = TreeParents.Length;
            TreeBase = new List<Node<T>>();

            for (int i = 0; i < Size; i++)
                TreeBase.Add(new Node<T>());

            for (int j = 0; j < Size; j++)
            {
                int ParentIndex = TreeParents[j];
                TreeBase[j].SetParantIndex(ParentIndex);
            }

            Iterator = new Iterator<T>(this);
        }

        // initialization of Data Filled Tree with given structure
        public Tree(T[] TreeData, int[] TreeParents)
        {
            Size = TreeParents.Length;
            TreeBase = new List<Node<T>>();

            for (int i = 0; i < Size; i++)
                TreeBase.Add(new Node<T>());

            for (int j = 0; j < Size; j++)
            {
                T Data = TreeData[j];
                int ParentIndex = TreeParents[j];
                TreeBase[j].SetData(Data);
                TreeBase[j].SetParantIndex(ParentIndex);
            }

            Iterator = new Iterator<T>(this);
        }

        public T Root()
        {
            return TreeBase[0].Data;
        }
        public bool IsEmpty()
        {
            if (Size < 0)
                return true;
            return false;
        }
        public T ParentOf(T Child)
        {
            if (Iterator.TreeConsist(Child, out Node<T> NodeOfChild))
            {
                int ParentIndex = NodeOfChild.ParentIndex;
                return TreeBase[ParentIndex].Data;
            }

            return default;
        }
        public List<T> Children(T FatherData)
        {
            List<T> ChildrenList = new List<T>();

            if (IsInternal(FatherData) && Iterator.TreeConsist(FatherData, out Node<T> Father))
            {
                int FatherIndex = TreeBase.IndexOf(Father);

                foreach (Node<T> node in TreeBase)
                {
                    if (node.ParentIndex == FatherIndex)
                    {
                        ChildrenList.Add(node.Data);
                    }
                }
            }

            return ChildrenList;
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
            if (Iterator.TreeConsist(NodeData, out Node<T> Node))
            {
                int IndexOfNode = TreeBase.IndexOf(Node);

                foreach (Node<T> node in TreeBase)
                {
                    if (node.ParentIndex == IndexOfNode)
                        return false;
                }
            }

            return true;
        }
    }
}
