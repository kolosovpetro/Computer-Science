using System.Linq;
using HeapLibrary.Interfaces;

namespace HeapLibrary.Implementations
{
    public static class Auxiliary
    {
        private static int GetLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;
        private static int GetRightChildIndex(int parentIndex) => 2 * parentIndex + 2;
        private static bool HasLeftChild(int parentIndex, int[] array) => 2 * parentIndex + 1 < array.Length;
        private static bool HasRightChild(int parentIndex, int[] array) => 2 * parentIndex + 2 < array.Length;
        private static int GetLeftChild(int parentIndex, int[] array) => array[GetLeftChildIndex(parentIndex)];
        private static int GetRightChild(int parentIndex, int[] array) => array[GetRightChildIndex(parentIndex)];

        public static void SiftDown(int index, int[] array)
        {
            while (HasLeftChild(index, array))
            {
                var biggerIndex = GetLeftChildIndex(index);

                if (HasRightChild(index, array) && GetRightChild(index, array) > GetLeftChild(index, array))
                    biggerIndex = GetRightChildIndex(index);

                if (array[biggerIndex] < array[index])
                    break;

                Swap(biggerIndex, index, array);
                index = biggerIndex;
            }
        }

        private static void Swap(int elementIndex, int parentIndex, int[] heapBase)
        {
            var temp = heapBase[parentIndex];
            heapBase[parentIndex] = heapBase[elementIndex];
            heapBase[elementIndex] = temp;
        }
        
        public static IBinaryHeap FloydAlgorithm(params int[] array)
        {
            var arr = array.Select(x => x).ToArray();
            var count = arr.Length;

            for (int i = count / 2 - 1; i >= 0; i--)
            {
                SiftDown(i, arr);
            }

            return new MaxBinaryHeap
            {
                HeapBase = arr.ToList()
            };
        }

        public static int[] HeapSort(params int[] array)
        {
            var arr = array.Select(x => x).ToArray();
            var heap = FloydAlgorithm(array);
            while (heap.Length > 0)
            {
                var currentMax = heap.Pop();
                arr[heap.Length] = currentMax;
            }

            return arr;
        }
    }
}