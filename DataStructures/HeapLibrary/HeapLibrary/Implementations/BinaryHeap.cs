using System;
using System.Collections.Generic;
using HeapLibrary.Interfaces;

namespace HeapLibrary.Implementations
{
    public class BinaryHeap : IBinaryHeap
    {
        public List<int> HeapBase { get; } = new List<int>();
        public int Length => HeapBase.Count;
        private static int GetParentIndex(int childIndex) => (childIndex - 1) / 2;
        private static int GetLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;
        private static int GetRightChildIndex(int parentIndex) => 2 * parentIndex + 2;
        private bool HasLeftChild(int parentIndex) => 2 * parentIndex + 1 < Length;
        private bool HasRightChild(int parentIndex) => 2 * parentIndex + 2 < Length;
        private int GetLeftChild(int parentIndex) => HeapBase[GetLeftChildIndex(parentIndex)];
        private int GetRightChild(int parentIndex) => HeapBase[GetRightChildIndex(parentIndex)];

        public void Push(int value)
        {
            HeapBase.Add(value);
            SiftUp(Length - 1);
        }

        public void PushRange(params int[] values)
        {
            foreach (var value in values)
                Push(value);
        }

        private void SiftUp(int elementIndex)
        {
            if (elementIndex == 0) return;
            var parentIndex = GetParentIndex(elementIndex);

            if (HeapBase[elementIndex] > HeapBase[parentIndex])
            {
                Swap(parentIndex, elementIndex);
                SiftUp(parentIndex);
            }
        }

        public int Pop()
        {
            if (Length == 0)
                throw new IndexOutOfRangeException();

            var output = HeapBase[0];
            HeapBase[0] = HeapBase[Length - 1];
            HeapBase.RemoveAt(Length - 1);
            SiftDown(0);
            return output;
        }

        private void SiftDown(int index)
        {
            while (HasLeftChild(index))
            {
                var biggerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index) > GetLeftChild(index))
                {
                    biggerIndex = GetRightChildIndex(index);
                }

                if (HeapBase[biggerIndex] < HeapBase[index])
                {
                    break;
                }

                Swap(biggerIndex, index);
                index = biggerIndex;
            }
        }

        public int Peek()
        {
            throw new NotImplementedException();
        }

        private void Swap(int elementIndex, int parentIndex)
        {
            var temp = HeapBase[parentIndex];
            HeapBase[parentIndex] = HeapBase[elementIndex];
            HeapBase[elementIndex] = temp;
        }
    }
}