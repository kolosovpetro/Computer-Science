using System;
using System.Collections.Generic;
using System.Linq;
using Heaps.Auxiliaries;

namespace Heaps
{
    class Heap : IHeap
    {
        public List<int> HeapBase { get; }
        public List<int> HeapParents { get; }
        public int Size { get; private set; }

        public Heap(params int[] newHeapBase)
        {
            HeapParents = new List<int>();
            HeapBase = newHeapBase.ToList();
            Size = HeapBase.Count;

            for (int i = 0; i < Size; i++)
            {
                SiftUp(i);
            }

            for (int j = 0; j < Size; j++)
            {
                HeapParents.Add(GenerateParentIndex(j));
            }
        }
        private int GenerateParentIndex(int n)
        {
            if (n == 0) return 0;
            else return (n - 1) / 2;
        }
        public int Root()
        {
            return HeapBase[0];
        }
        public int GetNode(int NodeIndex)
        {
            try
            {
                return HeapBase[NodeIndex];
            }
            catch (IndexOutOfRangeException)
            {
                return 0;
            }
        }
        public int GetParentOf(int ChildIndex)
        {
            try
            {
                int ParentIndex = (ChildIndex - 1) / 2;
                return HeapBase[ParentIndex];
            }
            catch (IndexOutOfRangeException)
            {
                return 0;
            }
        }
        public int GetLeftChildOf(int ParentIndex)
        {
            try
            {
                return HeapBase[2 * ParentIndex + 1];
            }
            catch (ArgumentOutOfRangeException)
            {
                return 0;
            }
        }
        public int GetRightChildOf(int Parent)
        {
            try
            {
                return HeapBase[2 * Parent + 2];
            }
            catch (ArgumentOutOfRangeException)
            {
                return 0;
            }
        }
        public void SiftUp(int Index)
        {
            if (Index == 0) return;

            int ParentIndex = Index / 2;

            if (HeapBase[Index] > HeapBase[ParentIndex])
            {
                Swap.CollectionSwap(HeapBase, ParentIndex, Index);
                SiftUp(ParentIndex);
            }
        }

        public int Pop()
        {
            int Result = Root();
            int LastIndex = HeapBase.Count - 1;
            HeapBase[0] = HeapBase[LastIndex];
            HeapBase.RemoveAt(LastIndex);
            SiftDown(0);
            return Result;
        }
        public void SiftDown(int Index)
        {
            int MaxIndex;
            int LeftChildIndex = GetLeftChildIndex(Index);
            int RightChildIndex = GetRightChildIndex(Index);

            if (LeftChildIndex == -1 && RightChildIndex == -1)
                return;

            if (LeftChildIndex < HeapBase.Count)
                MaxIndex = LeftChildIndex;

            else
                MaxIndex = RightChildIndex;

            if (HeapBase[Index] < HeapBase[MaxIndex])
            {
                Swap.CollectionSwap(HeapBase, Index, MaxIndex);
                SiftDown(MaxIndex);
            }
        }
        public int GetLeftChildIndex(int ParentIndex)
        {
            int t = GetLeftChildOf(ParentIndex);
            return HeapBase.IndexOf(t);
        }
        public int GetRightChildIndex(int ParentIndex)
        {

            int t = GetRightChildOf(ParentIndex);
            return HeapBase.IndexOf(t);
        }

        public List<int> HeapSort()
        {
            List<int> temp = HeapBase;
            List<int> Sorted = new List<int>();

            while (true)
            {
                try
                {
                    int Size = temp.Count;
                    Heap h1 = new Heap(temp.ToArray());
                    Sorted.Add(h1.Pop());
                    temp = h1.HeapBase;
                }
                catch (Exception)
                {
                    break;
                }
            }

            return Sorted;
        }
    }
}
