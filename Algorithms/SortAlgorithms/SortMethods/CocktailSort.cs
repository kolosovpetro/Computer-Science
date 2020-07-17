using System.Collections.Generic;
using SortAlgorithms.Auxiliaries;
using SortAlgorithms.Arrays;

namespace SortAlgorithms.SortMethods
{
    internal class CocktailSort : AbstractSort
    {
        public CocktailSort(IEnumerable<int> collection) : base(collection) { }
        public CocktailSort(AbstractArray array) : base(array) { }

        public override void GetSortedArray()
        {
            SortedArray = DoCocktailSort(InitArray);
        }

        private static int[] DoCocktailSort(int[] array)
        {
            var start = 0;
            var end = array.Length - 1;

            while (true)
            {
                var Swapped = false;

                for (var i = start; i < end; i++)
                {
                    if (array[i] <= array[i + 1]) continue;
                    Swap.DoSwap(ref array[i], ref array[i + 1]);
                    Swapped = true;
                }

                if (!Swapped) break;

                end--;

                for (var i = end - 1; i >= start; --i)
                {
                    if (array[i] <= array[i + 1]) continue;
                    Swap.DoSwap(ref array[i], ref array[i + 1]);
                }

                start++;
            }
            
            return array;
        }

    }
}
