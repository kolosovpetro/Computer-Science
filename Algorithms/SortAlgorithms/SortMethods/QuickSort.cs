using System.Collections.Generic;
using SortAlgorithms.Auxiliaries;
using SortAlgorithms.Arrays;

namespace SortAlgorithms.SortMethods
{
    class QuickSort : AbstractSort
    {
        int Left;
        int Right;
        public QuickSort(IEnumerable<int> Collection) : base(Collection) 
        {
            Left = 0;
            Right = InitArray.Length - 1;
        }
        public QuickSort(AbstractArray newAbsArray) : base(newAbsArray)
        {
            Left = 0;
            Right = InitArray.Length - 1;
        }
        public override void GetSortedArray()
        {
            SortedArray = DoQuickSort(InitArray, Left, Right);
        }
        private int[] DoQuickSort(int[] Array, int Left, int Right)
        {
            if (Left > Right || Left < 0 || Right < 0)
                return Array;

            int index = Partition(Array, Left, Right);

            if (index != -1)
            {
                DoQuickSort(Array, Left, index - 1);
                DoQuickSort(Array, index + 1, Right);
            }
            return Array;
        }

        private int Partition(int[] Array, int Left, int Right)
        {
            if (Left > Right) return -1;

            int End = Left;

            int Pivot = Array[Right];
            for (int i = Left; i < Right; i++)
            {
                if (Array[i] < Pivot)
                {
                    Swap.DoSwap(ref Array[i], ref Array[End]);
                    End++;
                }
            }

            Swap.DoSwap(ref Array[End], ref Array[Right]);

            return End;
        }
    }
}
