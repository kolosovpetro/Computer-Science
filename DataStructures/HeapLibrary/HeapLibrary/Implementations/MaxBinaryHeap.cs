using System;
using System.Collections.Generic;
using HeapLibrary.Interfaces;

namespace HeapLibrary.Implementations
{
    public class MaxBinaryHeap : IBinaryHeap
    {
        public List<int> HeapBase { get; set; } = new List<int>();
        public int Length => HeapBase.Count;
        public bool IsEmpty => Length == 0;
        public int Root => HeapBase[0];
        private int GetParentIndex(int childIndex) => (childIndex - 1) / 2;
        private int GetLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;
        private int GetRightChildIndex(int parentIndex) => 2 * parentIndex + 2;
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

        public void IncreaseKey(int index, int value)
        {
            if (value < HeapBase[index])
            {
                throw new InvalidOperationException("New key cannot be lesser than actual.");
            }

            HeapBase[index] = value;

            while (index > 1 && HeapBase[GetParentIndex(index)] < HeapBase[index])
            {
                Swap(index, GetParentIndex(index));
                index = GetParentIndex(index);
            }
        }

        public void DecreaseKey(int index, int value)
        {
            throw new NotImplementedException();
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
            if (IsEmpty)
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
                    biggerIndex = GetRightChildIndex(index);

                if (HeapBase[biggerIndex] < HeapBase[index])
                    break;

                Swap(biggerIndex, index);
                index = biggerIndex;
            }
        }

        public int Peek()
        {
            if (IsEmpty)
                throw new IndexOutOfRangeException();

            return Root;
        }

        private void Swap(int elementIndex, int parentIndex)
        {
            var temp = HeapBase[parentIndex];
            HeapBase[parentIndex] = HeapBase[elementIndex];
            HeapBase[elementIndex] = temp;
        }
    }
}