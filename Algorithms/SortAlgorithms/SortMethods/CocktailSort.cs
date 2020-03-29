using System.Collections.Generic;
using SortAlgorithms.Auxiliaries;
using SortAlgorithms.Arrays;

namespace SortAlgorithms.SortMethods
{
    internal class CocktailSort : AbstractSort
    {
        public CocktailSort(IEnumerable<int> Collection) : base(Collection) { }
        public CocktailSort(AbstractArray newAbsArray) : base(newAbsArray) { }

        public override void GetSortedArray()
        {
            SortedArray = DoCocktailSort(InitArray);
        }

        private int[] DoCocktailSort(int[] Array)
        {
            int Start = 0;
            int End = Array.Length - 1;

            while (true)
            {

                var Swapped = false;

                for (int i = Start; i < End; i++)
                {
                    if (Array[i] <= Array[i + 1]) continue;
                    Swap.DoSwap(ref Array[i], ref Array[i + 1]);
                    Swapped = true;
                }

                if (!Swapped)
                {
                    break;
                }

                End--;

                for (int i = End - 1; i >= Start; --i)
                {
                    if (Array[i] > Array[i + 1])
                    {
                        Swap.DoSwap(ref Array[i], ref Array[i + 1]);
                        Swapped = true;
                    }
                }

                Start++;
            }

            return Array;
        }

    }
}
