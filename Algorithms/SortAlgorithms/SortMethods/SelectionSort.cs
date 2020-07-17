using System.Collections.Generic;
using SortAlgorithms.Auxiliaries;
using SortAlgorithms.Arrays;

namespace SortAlgorithms.SortMethods
{
    internal class SelectionSort : AbstractSort
    {
        public SelectionSort(IEnumerable<int> collection) : base(collection) { }
        public SelectionSort(AbstractArray array) : base(array) { }

        public override void GetSortedArray()
        {
            SortedArray = DoSelectionSort(InitArray);
        }

        private static int[] DoSelectionSort(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                var MinIndex = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    MinIndex = array[MinIndex] < array[j] ? MinIndex : j;
                }

                Swap.DoSwap(ref array[i], ref array[MinIndex]);
            }

            return array;
        }
    }
}
