using System.Collections.Generic;
using System.Linq;
using SortAlgorithms.Arrays;

namespace SortAlgorithms.SortMethods
{
    class MergeSort : AbstractSort
    {
        public MergeSort(IEnumerable<int> Collection) : base(Collection) { }
        public MergeSort(AbstractArray newAbsArray) : base(newAbsArray) { }
        public override void GetSortedArray()
        {
            SortedArray = DoMergeSort(InitArray);
        }
        private int[] DoMergeSort(int[] Array)
        {
            if (Array.Length <= 1)
                return Array;

            List<int> SortedArray = Array.ToList();
            List<int> Left = new List<int>();
            List<int> Right = new List<int>();

            int Middle = SortedArray.Count / 2;
            for (int i = 0; i < Middle; i++)
                Left.Add(SortedArray[i]);
            for (int i = Middle; i < SortedArray.Count; i++)
                Right.Add(SortedArray[i]);

            Left = this.DoMergeSort(Left.ToArray()).ToList();
            Right = this.DoMergeSort(Right.ToArray()).ToList();
            return Merge(Left, Right).ToArray();
        }

        private List<int> Merge(List<int> Left, List<int> Right)
        {
            List<int> Result = new List<int>();

            while (Left.Count > 0 || Right.Count > 0)
            {
                if (Left.Count > 0 && Right.Count > 0)
                {
                    if (Left.First() <= Right.First())
                    {
                        Result.Add(Left.First());
                        Left.Remove(Left.First());
                    }
                    else
                    {
                        Result.Add(Right.First());
                        Right.Remove(Right.First());
                    }
                }
                else if (Left.Count > 0)
                {
                    Result.Add(Left.First());
                    Left.Remove(Left.First());
                }
                else if (Right.Count > 0)
                {
                    Result.Add(Right.First());
                    Right.Remove(Right.First());
                }
            }
            return Result;
        }
    }
}
