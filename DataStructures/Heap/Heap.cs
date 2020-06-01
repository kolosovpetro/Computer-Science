using System;
using System.Collections.Generic;
using System.Linq;
using Heaps.Auxiliaries;
using Heaps.Interfaces;

namespace Heaps
{
    internal class Heap : IHeap
    {
        public List<int> HeapBase { get; }
        public List<int> HeapParents { get; }
        public int Size { get; }

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
            if (n == 0) 
                return 0;

            return (n - 1) / 2;
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
                int parentIndex = (ChildIndex - 1) / 2;
                return HeapBase[parentIndex];
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

            int parentIndex = Index / 2;

            if (HeapBase[Index] > HeapBase[parentIndex])
            {
                Swap.CollectionSwap(HeapBase, parentIndex, Index);
                SiftUp(parentIndex);
            }
        }

        public int Pop()
        {
            int result = Root();
            int lastIndex = HeapBase.Count - 1;
            HeapBase[0] = HeapBase[lastIndex];
            HeapBase.RemoveAt(lastIndex);
            SiftDown(0);
            return result;
        }

        public void SiftDown(int Index)
        {
            int leftChildIndex = GetLeftChildIndex(Index);
            int rightChildIndex = GetRightChildIndex(Index);

            if (leftChildIndex == -1 && rightChildIndex == -1)
                return;

            var maxIndex = leftChildIndex < HeapBase.Count ? leftChildIndex : rightChildIndex;

            if (HeapBase[Index] < HeapBase[maxIndex])
            {
                Swap.CollectionSwap(HeapBase, Index, maxIndex);
                SiftDown(maxIndex);
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
            List<int> sorted = new List<int>();

            while (true)
            {
                try
                {
                    Heap h1 = new Heap(temp.ToArray());
                    sorted.Add(h1.Pop());
                    temp = h1.HeapBase;
                }
                catch (Exception)
                {
                    break;
                }
            }

            return sorted;
        }
    }
}
