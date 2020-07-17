using SortAlgorithms.Auxiliaries;
using SortAlgorithms.Arrays;

namespace SortAlgorithms.SortMethods
{
    internal class QuickSort : AbstractSort
    {
        private readonly int _left;
        private readonly int _right;

        public QuickSort(AbstractArray array) : base(array)
        {
            _left = 0;
            _right = InitArray.Length - 1;
        }

        public override void GetSortedArray()
        {
            SortedArray = DoQuickSort(InitArray, _left, _right);
        }

        private static int[] DoQuickSort(int[] array, int left, int right)
        {
            if (left > right || left < 0 || right < 0)
                return array;

            var index = Partition(array, left, right);

            if (index == -1) return array;

            DoQuickSort(array, left, index - 1);
            DoQuickSort(array, index + 1, right);
            return array;
        }

        private static int Partition(int[] array, int left, int right)
        {
            if (left > right) return -1;

            var end = left;

            var pivot = array[right];

            for (var i = left; i < right; i++)
            {
                if (array[i] >= pivot) continue;

                Swap.DoSwap(ref array[i], ref array[end]);

                end++;
            }

            Swap.DoSwap(ref array[end], ref array[right]);

            return end;
        }
    }
}