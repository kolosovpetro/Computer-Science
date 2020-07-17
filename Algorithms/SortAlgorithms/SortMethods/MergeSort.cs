using System.Collections.Generic;
using System.Linq;
using SortAlgorithms.Arrays;

namespace SortAlgorithms.SortMethods
{
    internal class MergeSort : AbstractSort
    {
        public MergeSort(AbstractArray array) : base(array) { }

        public override void GetSortedArray()
        {
            SortedArray = DoMergeSort(InitArray);
        }

        private static int[] DoMergeSort(int[] array)
        {
            if (array.Length <= 1)
                return array;

            var list = array.ToList();
            var left = new List<int>();
            var right = new List<int>();

            var Middle = list.Count / 2;

            for (var i = 0; i < Middle; i++)
                left.Add(list[i]);

            for (var i = Middle; i < list.Count; i++)
                right.Add(list[i]);

            left = DoMergeSort(left.ToArray()).ToList();
            right = DoMergeSort(right.ToArray()).ToList();
            return Merge(left, right).ToArray();
        }

        private static List<int> Merge(ICollection<int> left, ICollection<int> right)
        {
            var result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())
                    {
                        result.Add(left.First());
                        left.Remove(left.First());
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }

                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }

                else if (right.Count > 0)
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }

            return result;
        }
    }
}
