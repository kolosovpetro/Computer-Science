using SortAlgorithms.Auxiliaries;
using SortAlgorithms.Arrays;

namespace SortAlgorithms.SortMethods
{
    internal class QuickSort : AbstractSort
    {
        readonly int _left;
        readonly int _right;

        public QuickSort(AbstractArray newAbsArray) : base(newAbsArray)
        {
            _left = 0;
            _right = InitArray.Length - 1;
        }

        public override void GetSortedArray()
        {
            SortedArray = DoQuickSort(InitArray, _left, _right);
        }

        private int[] DoQuickSort(int[] Array, int Left, int Right)
        {
            if (Left > Right || Left < 0 || Right < 0)
                return Array;

            int index = Partition(Array, Left, Right);

            if (index == -1) return Array;

            DoQuickSort(Array, Left, index - 1);
            DoQuickSort(Array, index + 1, Right);
            return Array;
        }

        private int Partition(int[] Array, int Left, int Right)
        {
            if (Left > Right) return -1;

            int End = Left;

            int Pivot = Array[Right];

            for (int i = Left; i < Right; i++)
            {
                if (Array[i] >= Pivot) continue;

                Swap.DoSwap(ref Array[i], ref Array[End]);

                End++;
            }

            Swap.DoSwap(ref Array[End], ref Array[Right]);

            return End;
        }
    }
}
